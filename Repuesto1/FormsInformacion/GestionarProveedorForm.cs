using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;

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
            using (var db = new RepuestoContext())
            {
                // Usar TblProveedores (plural) y la propiedad Inactivo
                var proveedores = db.TblProveedores.Where(p => p.Inactivo == false).ToList();
                dgvProveedores.DataSource = proveedores;
                lblInfo.Text = $"Total: {proveedores.Count} proveedores";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(350, 320);
            frm.Text = "Nuevo Proveedor";
            frm.StartPosition = FormStartPosition.CenterParent;

            // Campos
            var lblNom = new Label() { Text = "Nombre:", Location = new System.Drawing.Point(10, 20), Width = 80 };
            var txtNom = new TextBox() { Location = new System.Drawing.Point(100, 17), Width = 220 };

            var lblRUC = new Label() { Text = "RUC:", Location = new System.Drawing.Point(10, 60), Width = 80 };
            var txtRUC = new TextBox() { Location = new System.Drawing.Point(100, 57), Width = 220 };

            var lblTel = new Label() { Text = "Teléfono:", Location = new System.Drawing.Point(10, 100), Width = 80 };
            var txtTel = new TextBox() { Location = new System.Drawing.Point(100, 97), Width = 220 };

            var lblDir = new Label() { Text = "Dirección:", Location = new System.Drawing.Point(10, 140), Width = 80 };
            var txtDir = new TextBox() { Location = new System.Drawing.Point(100, 137), Width = 220 };

            var lblEmail = new Label() { Text = "Email:", Location = new System.Drawing.Point(10, 180), Width = 80 };
            var txtEmail = new TextBox() { Location = new System.Drawing.Point(100, 177), Width = 220 };

            var btnOk = new Button() { Text = "Guardar", Location = new System.Drawing.Point(100, 230), Width = 100, Height = 35 };
            var btnCancel = new Button() { Text = "Cancelar", Location = new System.Drawing.Point(210, 230), Width = 100, Height = 35 };

            frm.Controls.AddRange(new Control[] { lblNom, txtNom, lblRUC, txtRUC, lblTel, txtTel, lblDir, txtDir, lblEmail, txtEmail, btnOk, btnCancel });

            btnOk.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var db = new RepuestoContext())
                {
                    // Usar TblProveedore (singular) como está en tu modelo
                    var nuevoProveedor = new TblProveedore()
                    {
                        Nombre = txtNom.Text,
                        Ruc = txtRUC.Text,           // Propiedad: Ruc (no RUC)
                        Telefono = txtTel.Text,
                        Direccion = txtDir.Text,
                        Email = txtEmail.Text,
                        Inactivo = false              // Por defecto activo
                    };

                    db.TblProveedores.Add(nuevoProveedor);
                    db.SaveChanges();
                    frm.Close();
                    CargarProveedores();
                    MessageBox.Show("✅ Proveedor agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            btnCancel.Click += (s, ev) => frm.Close();
            frm.ShowDialog();
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor para inactivar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var prov = (TblProveedore)dgvProveedores.SelectedRows[0].DataBoundItem;

            using (var db = new RepuestoContext())
            {
                var p = db.TblProveedores.Find(prov.Id);
                if (p != null)
                {
                    p.Inactivo = true;
                    db.SaveChanges();
                    CargarProveedores();
                    MessageBox.Show("✅ Proveedor inactivado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var prov = (TblProveedore)dgvProveedores.SelectedRows[0].DataBoundItem;

            var frm = new Form();
            frm.Size = new System.Drawing.Size(350, 320);
            frm.Text = "Editar Proveedor";
            frm.StartPosition = FormStartPosition.CenterParent;

            // Campos con valores actuales
            var lblNom = new Label() { Text = "Nombre:", Location = new System.Drawing.Point(10, 20), Width = 80 };
            var txtNom = new TextBox() { Location = new System.Drawing.Point(100, 17), Width = 220, Text = prov.Nombre };

            var lblRUC = new Label() { Text = "RUC:", Location = new System.Drawing.Point(10, 60), Width = 80 };
            var txtRUC = new TextBox() { Location = new System.Drawing.Point(100, 57), Width = 220, Text = prov.Ruc };

            var lblTel = new Label() { Text = "Teléfono:", Location = new System.Drawing.Point(10, 100), Width = 80 };
            var txtTel = new TextBox() { Location = new System.Drawing.Point(100, 97), Width = 220, Text = prov.Telefono };

            var lblDir = new Label() { Text = "Dirección:", Location = new System.Drawing.Point(10, 140), Width = 80 };
            var txtDir = new TextBox() { Location = new System.Drawing.Point(100, 137), Width = 220, Text = prov.Direccion };

            var lblEmail = new Label() { Text = "Email:", Location = new System.Drawing.Point(10, 180), Width = 80 };
            var txtEmail = new TextBox() { Location = new System.Drawing.Point(100, 177), Width = 220, Text = prov.Email };

            var btnOk = new Button() { Text = "Actualizar", Location = new System.Drawing.Point(100, 230), Width = 100, Height = 35 };
            var btnCancel = new Button() { Text = "Cancelar", Location = new System.Drawing.Point(210, 230), Width = 100, Height = 35 };

            frm.Controls.AddRange(new Control[] { lblNom, txtNom, lblRUC, txtRUC, lblTel, txtTel, lblDir, txtDir, lblEmail, txtEmail, btnOk, btnCancel });

            btnOk.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var db = new RepuestoContext())
                {
                    var p = db.TblProveedores.Find(prov.Id);
                    if (p != null)
                    {
                        p.Nombre = txtNom.Text;
                        p.Ruc = txtRUC.Text;
                        p.Telefono = txtTel.Text;
                        p.Direccion = txtDir.Text;
                        p.Email = txtEmail.Text;

                        db.SaveChanges();
                        frm.Close();
                        CargarProveedores();
                        MessageBox.Show("✅ Proveedor actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };

            btnCancel.Click += (s, ev) => frm.Close();
            frm.ShowDialog();
        }
    }
}