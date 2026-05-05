using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Data.Context;

namespace Repuesto1
{
    public partial class GestionarVentasForm : Form
    {
        public GestionarVentasForm()
        {
            InitializeComponent();
        }

        private void GestionarVentasForm_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            using (var db = new RepuestoContext())
            {
                var ventas = db.TblVentas
                    .OrderByDescending(v => v.Fecha)
                    .Select(v => new
                    {
                        v.Id,
                        v.NumeroFactura,
                        v.Fecha,
                        v.IdUsuario,
                        v.SubTotal,
                        v.Itebis,
                        v.Total,
                        v.Estado
                    })
                    .ToList();

                dgvVentas.DataSource = ventas;

                // Total general de ventas
                decimal totalGeneral = ventas.Sum(v => v.Total ?? 0);
                lblInfo.Text = $"Total Ventas: {totalGeneral:C2}";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Aquí luego puedes hacer el formulario de nueva venta
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}