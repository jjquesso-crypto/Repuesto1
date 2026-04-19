using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Model;

namespace Repuesto1
{
    public partial class GestionarFacturasForm : Form
    {
        public GestionarFacturasForm()
        {
            InitializeComponent();
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            using (var db = new AppDbContext())
            {
                var facturas = db.Facturas.OrderByDescending(f => f.Fecha).ToList();
                dgvFacturas.DataSource = facturas;
                lblInfo.Text = $"Total Ventas: {facturas.Sum(f => f.Total):C2}";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(300, 250);
            frm.Text = "Nueva Factura";

            var cbProducto = new ComboBox() { Location = new System.Drawing.Point(10, 30), Width = 260 };
            var txtCant = new TextBox() { Location = new System.Drawing.Point(10, 70), Width = 260, PlaceholderText = "Cantidad" };
            var txtPrecio = new TextBox() { Location = new System.Drawing.Point(10, 110), Width = 260, PlaceholderText = "Precio" };
            var txtCliente = new TextBox() { Location = new System.Drawing.Point(10, 150), Width = 260, PlaceholderText = "Cliente" };
            var btnOk = new Button() { Text = "Vender", Location = new System.Drawing.Point(10, 190), Width = 260 };

            frm.Controls.Add(cbProducto);
            frm.Controls.Add(txtCant);
            frm.Controls.Add(txtPrecio);
            frm.Controls.Add(txtCliente);
            frm.Controls.Add(btnOk);

            using (var db = new AppDbContext())
            {
                cbProducto.DataSource = db.Productos.Where(p => !p.Inactivo && p.Cantidad > 0).ToList();
                cbProducto.DisplayMember = "Nombre";
            }

            btnOk.Click += (s, ev) =>
            {
                using (var db = new AppDbContext())
                {
                    var prod = db.Productos.Find((int)cbProducto.SelectedValue);
                    int cantidad = int.Parse(txtCant.Text);

                    if (prod.Cantidad < cantidad)
                    {
                        MessageBox.Show("Stock insuficiente");
                        return;
                    }

                    var factura = new Factura()
                    {
                        NumeroFactura = $"F-{DateTime.Now.Ticks}",
                        Fecha = DateTime.Now,
                        Cliente = txtCliente.Text,
                        SubTotal = cantidad * decimal.Parse(txtPrecio.Text),
                        Total = cantidad * decimal.Parse(txtPrecio.Text)
                    };
                    db.Facturas.Add(factura);
                    db.SaveChanges();

                    db.DetalleFacturas.Add(new DetalleFactura()
                    {
                        IdFactura = factura.Id,
                        IdProducto = (int)cbProducto.SelectedValue,
                        Cantidad = cantidad,
                        PrecioVenta = decimal.Parse(txtPrecio.Text),
                        SubTotal = cantidad * decimal.Parse(txtPrecio.Text)
                    });

                    prod.Cantidad -= cantidad;
                    db.SaveChanges();

                    frm.Close();
                    CargarFacturas();
                    MessageBox.Show("✅ Venta registrada");
                }
            };
            frm.ShowDialog();
        }
    }
}