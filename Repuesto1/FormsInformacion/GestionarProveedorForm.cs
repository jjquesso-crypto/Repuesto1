using Repuesto1.Data.Models;
using Repuesto1.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Repuesto1
{
    public partial class GestionarProveedorForm : Form
    {
        private readonly ProveedorServices _proveedorServices;

        public GestionarProveedorForm()
        {
            InitializeComponent();
            _proveedorServices = Program.ServiceProvider.GetRequiredService<ProveedorServices>();
            CargarProveedores();
        }

        private async void CargarProveedores()
        {
            var proveedores = await _proveedorServices.GetList(p => p.Inactivo == false);

            dgvProveedores.DataSource = proveedores
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Ruc,
                    p.Telefono,
                    p.Direccion,
                    p.Email
                })
                .ToList();

            lblInfo.Text = $"Total: {proveedores.Count} proveedores";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = CrearFormularioProveedor(null);
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor");
                return;
            }

            var proveedor = (TblProveedore)dgvProveedores.SelectedRows[0].DataBoundItem;

            var frm = CrearFormularioProveedor(proveedor);
            frm.ShowDialog();
        }

        private async void btnInactivar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor");
                return;
            }

            var proveedor = (TblProveedore)dgvProveedores.SelectedRows[0].DataBoundItem;

            await _proveedorServices.Eliminar(proveedor.Id);

            MessageBox.Show("Proveedor inactivado");
            CargarProveedores();
        }

        private Form CrearFormularioProveedor(TblProveedore? prov)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(380, 340);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.BackColor = System.Drawing.Color.White;
            frm.Text = prov != null ? "Editar Proveedor" : "Nuevo Proveedor";

            // Campos con estilo
            TextBox Txt(int y) => new TextBox()
            {
                Location = new System.Drawing.Point(100, y),
                Width = 240,
                Font = new System.Drawing.Font("Segoe UI", 9),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label Lbl(string texto, int y) => new Label()
            {
                Text = texto,
                Location = new System.Drawing.Point(10, y + 3),
                Width = 85,
                Font = new System.Drawing.Font("Segoe UI", 9),
                ForeColor = System.Drawing.Color.FromArgb(60, 60, 60)
            };

            var txtNom = Txt(17);
            var txtRUC = Txt(57);
            var txtTel = Txt(97);
            var txtDir = Txt(137);
            var txtEmail = Txt(177);

            if (prov != null)
            {
                txtNom.Text = prov.Nombre;
                txtRUC.Text = prov.Ruc;
                txtTel.Text = prov.Telefono;
                txtDir.Text = prov.Direccion;
                txtEmail.Text = prov.Email;
            }

            var btnOk = new Button()
            {
                Text = "💾 Guardar",
                Location = new System.Drawing.Point(110, 235),
                Width = 130,
                Height = 36,
                BackColor = System.Drawing.Color.FromArgb(40, 167, 69),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold)
            };
            btnOk.FlatAppearance.BorderSize = 0;

            btnOk.Click += async (s, ev) =>
            {
                var entidad = prov ?? new TblProveedore();
                entidad.Nombre = txtNom.Text.Trim();
                entidad.Ruc = txtRUC.Text.Trim();
                entidad.Telefono = txtTel.Text.Trim();
                entidad.Direccion = txtDir.Text.Trim();
                entidad.Email = txtEmail.Text.Trim();
                entidad.Inactivo = false;
                await _proveedorServices.Guardar(entidad);
                frm.Close();
                CargarProveedores();
            };

            frm.Controls.AddRange(new Control[]
            {
        Lbl("Nombre", 17),  txtNom,
        Lbl("RUC",    57),  txtRUC,
        Lbl("Tel",    97),  txtTel,
        Lbl("Dir",   137),  txtDir,
        Lbl("Email", 177),  txtEmail,
        btnOk
            });

            return frm;
        }
    }
}