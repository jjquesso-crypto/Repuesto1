using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Data;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;

namespace Repuesto1
{
    public partial class GestionarComprasForm : Form
    {
        private List<DetalleCompraTemp> detalles = new List<DetalleCompraTemp>();

        public GestionarComprasForm()
        {
            InitializeComponent();
            CargarCompras();
        }

        private void CargarCompras()
        {
            using (var db = new RepuestoContext())
            {
                var compras = db.TblCompras
                    .OrderByDescending(c => c.Fecha)
                    .Select(c => new
                    {
                        c.Id,
                        c.NumeroFactura,
                        c.Fecha,
                        //Proveedor = c.Proveedore.Nombre, // ← une con la tabla Proveedores
                        c.SubTotal,
                        c.Iva,
                        c.Total,
                        c.Estado
                    })
                    .ToList();

                dgvCompras.DataSource = compras;
                lblInfo.Text = $"Total: {compras.Sum(c => c.Total):C2}";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(700, 550);
            frm.Text = "Nueva Compra";
            frm.StartPosition = FormStartPosition.CenterParent;

            // Proveedor
            var lblProveedor = new Label() { Text = "Proveedor:", Location = new System.Drawing.Point(10, 20), Width = 80 };
            var cbProveedor = new ComboBox() { Location = new System.Drawing.Point(100, 17), Width = 200 };

            // Producto
            var lblProducto = new Label() { Text = "Producto:", Location = new System.Drawing.Point(10, 60), Width = 80 };
            var cbProducto = new ComboBox() { Location = new System.Drawing.Point(100, 57), Width = 150 };

            // Cantidad
            var lblCant = new Label() { Text = "Cantidad:", Location = new System.Drawing.Point(260, 60), Width = 60 };
            var txtCant = new TextBox() { Location = new System.Drawing.Point(320, 57), Width = 80 };

            // Precio
            var lblPrecio = new Label() { Text = "Precio:", Location = new System.Drawing.Point(410, 60), Width = 50 };
            var txtPrecio = new TextBox() { Location = new System.Drawing.Point(460, 57), Width = 80 };

            // Botón agregar producto
            var btnAgregarProd = new Button() { Text = "Agregar", Location = new System.Drawing.Point(550, 55), Width = 80 };

            // DataGridView para detalles
            var dgvDetalles = new DataGridView()
            {
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(660, 250),
                AutoGenerateColumns = true
            };

            // Label total
            var lblTotal = new Label() { Text = "Total: $0.00", Location = new System.Drawing.Point(10, 360), Width = 200, Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold) };

            // Botón guardar compra
            var btnGuardar = new Button() { Text = "Guardar Compra", Location = new System.Drawing.Point(10, 400), Width = 150, Height = 40 };

            frm.Controls.Add(lblProveedor);
            frm.Controls.Add(cbProveedor);
            frm.Controls.Add(lblProducto);
            frm.Controls.Add(cbProducto);
            frm.Controls.Add(lblCant);
            frm.Controls.Add(txtCant);
            frm.Controls.Add(lblPrecio);
            frm.Controls.Add(txtPrecio);
            frm.Controls.Add(btnAgregarProd);
            frm.Controls.Add(dgvDetalles);
            frm.Controls.Add(lblTotal);
            frm.Controls.Add(btnGuardar);

            // Cargar proveedores y productos
            using (var db = new RepuestoContext())
            {
                cbProveedor.DataSource = db.TblProveedores.Where(p => p.Inactivo == false).ToList();
                cbProveedor.DisplayMember = "Nombre";
                cbProveedor.ValueMember = "Id";

                cbProducto.DataSource = db.TblProductos.Where(p => p.Inactivo == false).ToList();
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "Id";
            }

            // Actualizar total
            void ActualizarTotal()
            {
                decimal total = detalles.Sum(d => d.SubTotal);
                lblTotal.Text = $"Total: {total:C2}";
                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = detalles;
            }

            // Agregar producto a la lista
            btnAgregarProd.Click += (s, ev) =>
            {
                if (cbProducto.SelectedValue == null) return;
                if (string.IsNullOrWhiteSpace(txtCant.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text)) return;

                int idProducto = (int)cbProducto.SelectedValue;
                string nombre = cbProducto.Text;
                int cantidad = int.Parse(txtCant.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);
                decimal subtotal = cantidad * precio;
                string proveedor = cbProveedor.Text;

                detalles.Add(new DetalleCompraTemp
                {
                    IdProducto = idProducto,
                    ProductoNombre = nombre,
                    Cantidad = cantidad,
                    PrecioCompra = precio,
                    SubTotal = subtotal,
                    Proveedor = proveedor
                });

                ActualizarTotal();
                txtCant.Clear();
                txtPrecio.Clear();
            };

            // Guardar compra completa
            btnGuardar.Click += (s, ev) =>
            {
                if (cbProveedor.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un proveedor");
                    return;
                }

                if (detalles.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un producto");
                    return;
                }

                using (var db = new RepuestoContext())
                {
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
                        Estado = "PAGADA",
                    };
                    db.TblCompras.Add(compra);
                    db.SaveChanges();

                    // Guardar cada detalle
                    foreach (var item in detalles)
                    {
                        db.TblDetalleCompras.Add(new TblDetalleCompra()
                        {
                            IdCompra = compra.Id,
                            IdProducto = item.IdProducto,
                            Cantidad = item.Cantidad,
                            PrecioCompra = item.PrecioCompra,
                            SubTotal = item.SubTotal
                        });

                        // Actualizar stock
                        var prod = db.TblProductos.Find(item.IdProducto);
                        prod.Cantidad += item.Cantidad;
                    }

                    db.SaveChanges();
                    frm.Close();
                    CargarCompras();
                    MessageBox.Show($"✅ Compra guardada. Total: {total:C2}");
                }
            };

            frm.ShowDialog();
        }
    }

    // Clase temporal para los detalles
    public class DetalleCompraTemp
    {
        public int IdProducto { get; set; }
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal SubTotal { get; set; }
        public string Proveedor { get; set; } = string.Empty;
    }
}