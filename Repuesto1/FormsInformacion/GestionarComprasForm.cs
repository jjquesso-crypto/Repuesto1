using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Model;

namespace Repuesto1
{
    public partial class GestionarComprasForm : Form
    {
        public GestionarComprasForm()
        {
            InitializeComponent();
            CargarCompras();
        }

        private void CargarCompras()
        {
            using (var db = new AppDbContext())
            {
                var compras = db.Compras.OrderByDescending(c => c.Fecha).ToList();
                dgvCompras.DataSource = compras;
                lblInfo.Text = $"Total: {compras.Sum(c => c.Total):C2}";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(300, 250);
            frm.Text = "Nueva Compra";

            var cbProveedor = new ComboBox() { Location = new System.Drawing.Point(10, 30), Width = 260 };
            var cbProducto = new ComboBox() { Location = new System.Drawing.Point(10, 70), Width = 260 };
            var txtCant = new TextBox() { Location = new System.Drawing.Point(10, 110), Width = 260, PlaceholderText = "Cantidad" };
            var txtPrecio = new TextBox() { Location = new System.Drawing.Point(10, 150), Width = 260, PlaceholderText = "Precio" };
            var btnOk = new Button() { Text = "Guardar", Location = new System.Drawing.Point(10, 190), Width = 260 };

            frm.Controls.Add(cbProveedor);
            frm.Controls.Add(cbProducto);
            frm.Controls.Add(txtCant);
            frm.Controls.Add(txtPrecio);
            frm.Controls.Add(btnOk);

            using (var db = new AppDbContext())
            {
                var proveedores = db.Proveedores.Where(p => !p.Inactivo).ToList();
                var productos = db.Productos.Where(p => !p.Inactivo).ToList();

                if (proveedores.Count == 0)
                {
                    MessageBox.Show("⚠️ Cree un proveedor primero");
                    frm.Close();
                    return;
                }

                if (productos.Count == 0)
                {
                    MessageBox.Show("⚠️ Cree un producto primero");
                    frm.Close();
                    return;
                }

                // Así se carga correctamente
                cbProveedor.DataSource = proveedores;
                cbProveedor.DisplayMember = "Nombre";
                cbProveedor.ValueMember = "Id";  // ← Agrega esta línea

                cbProducto.DataSource = productos;
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "Id";   // ← Agrega esta línea
            }

            btnOk.Click += (s, ev) =>
            {
                using (var db = new AppDbContext())
                {
                    var compra = new Compra()
                    {
                        NumeroFactura = $"C-{DateTime.Now.Ticks}",
                        Fecha = DateTime.Now,
                        IdProveedor = (int)cbProveedor.SelectedValue,
                        SubTotal = int.Parse(txtCant.Text) * decimal.Parse(txtPrecio.Text),
                        Total = int.Parse(txtCant.Text) * decimal.Parse(txtPrecio.Text)
                    };
                    db.Compras.Add(compra);
                    db.SaveChanges();

                    db.DetalleCompras.Add(new DetalleCompra()
                    {
                        IdCompra = compra.Id,
                        IdProducto = (int)cbProducto.SelectedValue,
                        Cantidad = int.Parse(txtCant.Text),
                        PrecioCompra = decimal.Parse(txtPrecio.Text),
                        SubTotal = int.Parse(txtCant.Text) * decimal.Parse(txtPrecio.Text)
                    });

                    var prod = db.Productos.Find((int)cbProducto.SelectedValue);
                    prod.Cantidad += int.Parse(txtCant.Text);

                    db.SaveChanges();
                    frm.Close();
                    CargarCompras();
                }
            };
            frm.ShowDialog();
        }
    }
}