using System.Windows.Forms;
using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Model;

namespace Repuesto1
{
    public partial class GestionarProveedorForm : Form
    {
        public GestionarProveedorForm()
        {
            InitializeComponent();
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            using (var db = new AppDbContext())
            {
                var proveedores = db.Proveedores.Where(p => !p.Inactivo).ToList();
                dgvProveedores.DataSource = proveedores;
                lblInfo.Text = $"Total: {proveedores.Count} proveedores";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(300, 200);
            frm.Text = "Nuevo Proveedor";

            var txtNom = new TextBox() { Location = new System.Drawing.Point(10, 30), Width = 260 };
            var btnOk = new Button() { Text = "Guardar", Location = new System.Drawing.Point(10, 70), Width = 260 };

            frm.Controls.Add(txtNom);
            frm.Controls.Add(btnOk);

            btnOk.Click += (s, ev) =>
            {
                using (var db = new AppDbContext())
                {
                    db.Proveedores.Add(new Proveedor() { Nombre = txtNom.Text });
                    db.SaveChanges();
                    frm.Close();
                    CargarProveedores();
                }
            };
            frm.ShowDialog();
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0) return;

            var prov = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;

            using (var db = new AppDbContext())
            {
                var p = db.Proveedores.Find(prov.Id);
                p.Inactivo = true;
                db.SaveChanges();
                CargarProveedores();
            }
        }
    }
}