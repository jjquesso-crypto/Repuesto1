using Repuesto1.Data.Context;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Repuesto1.FormsInformacion
{
    public partial class NominaForm : Form
    {
        public NominaForm()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void NominaForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CargarUsuarios()
        {
            using (var db = new RepuestoContext())
            {
                var usuarios = db.TblUsuarios
                    .Select(u => new
                    {
                        u.Id,
                        u.NombreUsuario,
                        u.NombreCompleto,
                        u.Rol,
                        Estado = u.Activo == true ? "Activo" : "Inactivo"
                    })
                    .ToList();

                dgvNomina.DataSource = usuarios;

                lblInfo.Text = $"Total Usuarios: {usuarios.Count}";
            }
        }
    }
}