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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(750, 600);
            frm.MinimumSize = new System.Drawing.Size(750, 600);
            frm.Text = "Nueva Compra";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            var panelTop = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = System.Drawing.Color.White,
                Padding = new Padding(10)
            };

            var lblProveedor = new Label() { Text = "Proveedor:", Location = new System.Drawing.Point(10, 15), Width = 80, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            var cbProveedor = new ComboBox() { Location = new System.Drawing.Point(95, 12), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblProducto = new Label() { Text = "Producto:", Location = new System.Drawing.Point(10, 55), Width = 80, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            var cbProducto = new ComboBox() { Location = new System.Drawing.Point(95, 52), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblCant = new Label() { Text = "Cantidad:", Location = new System.Drawing.Point(330, 55), Width = 70, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            var txtCant = new TextBox() { Location = new System.Drawing.Point(405, 52), Width = 70 };

            var lblPrecio = new Label() { Text = "Precio:", Location = new System.Drawing.Point(490, 55), Width = 55, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            var txtPrecio = new TextBox() { Location = new System.Drawing.Point(548, 52), Width = 90, ReadOnly = true, BackColor = System.Drawing.Color.FromArgb(235, 235, 235) };

            var btnAgregarProd = new Button()
            {
                Text = "➕ Agregar",
                Location = new System.Drawing.Point(650, 48),
                Width = 85,
                Height = 30,
                BackColor = System.Drawing.Color.FromArgb(0, 122, 204),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAgregarProd.FlatAppearance.BorderSize = 0;

            panelTop.Controls.AddRange(new Control[]
            {
        lblProveedor, cbProveedor,
        lblProducto, cbProducto,
        lblCant, txtCant,
        lblPrecio, txtPrecio,
        btnAgregarProd
            });

            var panelBottom = new Panel()
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = System.Drawing.Color.White,
                Padding = new Padding(10)
            };

            var lblTotal = new Label()
            {
                Text = "Total: $0.00",
                Location = new System.Drawing.Point(10, 15),
                Width = 300,
                Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(0, 122, 204)
            };

            var btnGuardar = new Button()
            {
                Text = "💾 Guardar Compra",
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                Size = new System.Drawing.Size(160, 38),
                BackColor = System.Drawing.Color.FromArgb(40, 167, 69),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold)
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Location = new System.Drawing.Point(panelBottom.Width - 170, 11);
            panelBottom.Controls.AddRange(new Control[] { lblTotal, btnGuardar });

            panelBottom.Resize += (s, ev) =>
            {
                btnGuardar.Location = new System.Drawing.Point(panelBottom.Width - 170, 11);
            };

            var dgvDetalles = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false,
                ReadOnly = true,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dgvDetalles.EnableHeadersVisualStyles = false;

            frm.Controls.Add(dgvDetalles);   
            frm.Controls.Add(panelBottom);
            frm.Controls.Add(panelTop);

            List<TblProducto> productos;
            using (var db = new RepuestoContext())
            {
                cbProveedor.DataSource = db.TblProveedores.Where(p => p.Inactivo == false).ToList();
                cbProveedor.DisplayMember = "Nombre";
                cbProveedor.ValueMember = "Id";

                productos = db.TblProductos.Where(p => p.Inactivo == false).ToList();
                cbProducto.DataSource = productos;
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "Id";
            }

            cbProducto.SelectedIndexChanged += (s, ev) =>
            {
                if (cbProducto.SelectedValue == null) return;
                int idSeleccionado = (int)cbProducto.SelectedValue;
                var prod = productos.FirstOrDefault(p => p.Id == idSeleccionado);
                if (prod != null)
                    txtPrecio.Text = prod.Precio.ToString();
            };

            if (cbProducto.SelectedValue != null)
            {
                var prod = productos.FirstOrDefault(p => p.Id == (int)cbProducto.SelectedValue);
                if (prod != null) txtPrecio.Text = prod.Precio.ToString();
            }

            void ActualizarTotal()
            {
                decimal total = detalles.Sum(d => d.SubTotal);
                lblTotal.Text = $"Total: {total:C2}";
                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = detalles.ToList();
            }

            // ── Agregar producto ──
            btnAgregarProd.Click += (s, ev) =>
            {
                if (cbProducto.SelectedValue == null) return;
                if (string.IsNullOrWhiteSpace(txtCant.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Complete cantidad y precio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCant.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("El precio no es válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                detalles.Add(new DetalleCompraTemp
                {
                    IdProducto = (int)cbProducto.SelectedValue,
                    ProductoNombre = cbProducto.Text,
                    Cantidad = cantidad,
                    PrecioCompra = precio,
                    SubTotal = cantidad * precio
                });

                ActualizarTotal();
                txtCant.Clear();
            };

            // ── Guardar compra ──
            btnGuardar.Click += async (s, ev) =>
            {
                if (cbProveedor.SelectedValue == null || detalles.Count == 0)
                {
                    MessageBox.Show("Seleccione proveedor y agregue al menos un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        if (prod != null) prod.Cantidad += item.Cantidad;
                    }
                    await db.SaveChangesAsync();
                }

                MessageBox.Show($"✅ Compra guardada. Total: {total:C2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                detalles.Clear();
                frm.Close();
                CargarCompras();
            };

            frm.ShowDialog();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void GestionarComprasForm_Load(object sender, EventArgs e)
        {

        }

        private void lblInfo_Click_1(object sender, EventArgs e)
        {

        }
    }

    public class DetalleCompraTemp
    {
        public int IdProducto { get; set; }
        public string ProductoNombre { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal SubTotal { get; set; }
    }
}