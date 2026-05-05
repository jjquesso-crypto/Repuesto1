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

        // 📦 CARGAR PROVEEDORES
        private async void CargarProveedores()
        {
            var proveedores = await _proveedorServices.GetList(p => p.Inactivo == false);

            dgvProveedores.DataSource = proveedores;

            lblInfo.Text = $"Total: {proveedores.Count} proveedores";
        }

        // ➕ AGREGAR PROVEEDOR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = CrearFormularioProveedor(null);
            frm.ShowDialog();
        }

        // ✏️ EDITAR PROVEEDOR
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

        // ❌ INACTIVAR
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

        // 🧠 FORM REUTILIZABLE (AGREGAR / EDITAR)
        private Form CrearFormularioProveedor(TblProveedore? prov)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(350, 320);
            frm.StartPosition = FormStartPosition.CenterParent;

            var txtNom = new TextBox() { Location = new System.Drawing.Point(100, 17), Width = 220 };
            var txtRUC = new TextBox() { Location = new System.Drawing.Point(100, 57), Width = 220 };
            var txtTel = new TextBox() { Location = new System.Drawing.Point(100, 97), Width = 220 };
            var txtDir = new TextBox() { Location = new System.Drawing.Point(100, 137), Width = 220 };
            var txtEmail = new TextBox() { Location = new System.Drawing.Point(100, 177), Width = 220 };

            if (prov != null)
            {
                frm.Text = "Editar Proveedor";
                txtNom.Text = prov.Nombre;
                txtRUC.Text = prov.Ruc;
                txtTel.Text = prov.Telefono;
                txtDir.Text = prov.Direccion;
                txtEmail.Text = prov.Email;
            }
            else
            {
                frm.Text = "Nuevo Proveedor";
            }

            var btnOk = new Button()
            {
                Text = "Guardar",
                Location = new System.Drawing.Point(100, 230),
                Width = 100,
                Height = 35
            };

            btnOk.Click += async (s, ev) =>
            {
                var entidad = prov ?? new TblProveedore();

                entidad.Nombre = txtNom.Text;
                entidad.Ruc = txtRUC.Text;
                entidad.Telefono = txtTel.Text;
                entidad.Direccion = txtDir.Text;
                entidad.Email = txtEmail.Text;
                entidad.Inactivo = false;

                await _proveedorServices.Guardar(entidad);

                frm.Close();
                CargarProveedores();
            };

            frm.Controls.AddRange(new Control[]
            {
                new Label(){ Text="Nombre", Location=new System.Drawing.Point(10,20)},
                txtNom,
                new Label(){ Text="RUC", Location=new System.Drawing.Point(10,60)},
                txtRUC,
                new Label(){ Text="Tel", Location=new System.Drawing.Point(10,100)},
                txtTel,
                new Label(){ Text="Dir", Location=new System.Drawing.Point(10,140)},
                txtDir,
                new Label(){ Text="Email", Location=new System.Drawing.Point(10,180)},
                txtEmail,
                btnOk
            });

            return frm;
        }
    }
}