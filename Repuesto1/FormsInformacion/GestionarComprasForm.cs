using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Repuesto1
{
    public partial class GestionarComprasForm : Form
    {
        private readonly CompraServices _compraServices;
        private List<DetalleCompraTemp> detalles = new List<DetalleCompraTemp>();

        public GestionarComprasForm()
        {
            InitializeComponent();
            _compraServices = Program.ServiceProvider.GetRequiredService<CompraServices>();
            CargarCompras();
        }

        // 📊 CARGAR COMPRAS
        private async void CargarCompras()
        {
            var compras = await _compraServices.GetList(c => true);

            dgvCompras.DataSource = compras
                .OrderByDescending(c => c.Fecha)
                .Select(c => new
                {
                    c.Id,
                    c.NumeroFactura,
                    c.Fecha,
                    c.SubTotal,
                    c.Iva,
                    c.Total,
                    c.Estado
                })
                .ToList();

            lblInfo.Text = $"Total: {compras.Sum(c => c.Total):C2}";
        }

        // ➕ AGREGAR COMPRA (VENTANA DINÁMICA)
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(700, 550);
            frm.Text = "Nueva Compra";
            frm.StartPosition = FormStartPosition.CenterParent;

            var lblProveedor = new Label() { Text = "Proveedor:", Location = new System.Drawing.Point(10, 20) };
            var cbProveedor = new ComboBox() { Location = new System.Drawing.Point(100, 17), Width = 200 };

            var lblProducto = new Label() { Text = "Producto:", Location = new System.Drawing.Point(10, 60) };
            var cbProducto = new ComboBox() { Location = new System.Drawing.Point(100, 57), Width = 200 };

            var lblCant = new Label() { Text = "Cantidad:", Location = new System.Drawing.Point(320, 60) };
            var txtCant = new TextBox() { Location = new System.Drawing.Point(390, 57), Width = 80 };

            var lblPrecio = new Label() { Text = "Precio:", Location = new System.Drawing.Point(480, 60) };
            var txtPrecio = new TextBox() { Location = new System.Drawing.Point(530, 57), Width = 80 };

            var btnAgregarProd = new Button() { Text = "Agregar", Location = new System.Drawing.Point(620, 55) };

            var dgvDetalles = new DataGridView()
            {
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(660, 250),
                AutoGenerateColumns = true
            };

            var lblTotal = new Label()
            {
                Text = "Total: $0.00",
                Location = new System.Drawing.Point(10, 360),
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            };

            var btnGuardar = new Button()
            {
                Text = "Guardar Compra",
                Location = new System.Drawing.Point(10, 400),
                Width = 150,
                Height = 40
            };

            frm.Controls.AddRange(new Control[]
            {
                lblProveedor, cbProveedor,
                lblProducto, cbProducto,
                lblCant, txtCant,
                lblPrecio, txtPrecio,
                btnAgregarProd,
                dgvDetalles,
                lblTotal,
                btnGuardar
            });

            // 📦 CARGAR COMBOS
            using (var db = new RepuestoContext())
            {
                cbProveedor.DataSource = db.TblProveedores.Where(p => p.Inactivo == false).ToList();
                cbProveedor.DisplayMember = "Nombre";
                cbProveedor.ValueMember = "Id";

                cbProducto.DataSource = db.TblProductos.Where(p => p.Inactivo == false).ToList();
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "Id";
            }

            // 🔄 ACTUALIZAR TOTAL
            void ActualizarTotal()
            {
                decimal total = detalles.Sum(d => d.SubTotal);
                lblTotal.Text = $"Total: {total:C2}";
                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = detalles.ToList();
            }

            // ➕ AGREGAR DETALLE
            btnAgregarProd.Click += (s, ev) =>
            {
                if (cbProducto.SelectedValue == null) return;

                int idProducto = (int)cbProducto.SelectedValue;
                string nombre = cbProducto.Text;
                int cantidad = int.Parse(txtCant.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);

                detalles.Add(new DetalleCompraTemp
                {
                    IdProducto = idProducto,
                    ProductoNombre = nombre,
                    Cantidad = cantidad,
                    PrecioCompra = precio,
                    SubTotal = cantidad * precio
                });

                ActualizarTotal();

                txtCant.Clear();
                txtPrecio.Clear();
            };

            // 💾 GUARDAR COMPRA CON SERVICE
            btnGuardar.Click += async (s, ev) =>
            {
                if (cbProveedor.SelectedValue == null || detalles.Count == 0)
                {
                    MessageBox.Show("Complete los datos");
                    return;
                }

                decimal subtotal = detalles.Sum(d => d.SubTotal);
                decimal iva = subtotal * 0.18m;
                decimal total = subtotal + iva;

                var compra = new TblCompra()
                {
                    NumeroFactura = $"C-{DateTime.Now.Ticks}",
                    Fecha = DateTime.Now,
                    IdProveedor = (int)cbProveedor.SelectedValue,
                    SubTotal = subtotal,
                    Iva = iva,
                    Total = total,
                    Estado = "PAGADA"
                };

                await _compraServices.Guardar(compra);

                using (var db = new RepuestoContext())
                {
                    foreach (var item in detalles)
                    {
                        db.TblDetalleCompras.Add(new TblDetalleCompra
                        {
                            IdCompra = compra.Id,
                            IdProducto = item.IdProducto,
                            Cantidad = item.Cantidad,
                            PrecioCompra = item.PrecioCompra,
                            SubTotal = item.SubTotal
                        });

                        var prod = db.TblProductos.Find(item.IdProducto);
                        prod.Cantidad += item.Cantidad;
                    }

                    await db.SaveChangesAsync();
                }

                MessageBox.Show("Compra guardada correctamente");

                detalles.Clear();
                frm.Close();
                CargarCompras();
            };

            frm.ShowDialog();
        }
    }

    // 📌 MODELO TEMPORAL
    public class DetalleCompraTemp
    {
        public int IdProducto { get; set; }
        public string ProductoNombre { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal SubTotal { get; set; }
    }
}