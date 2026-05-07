using Repuesto1.Data.Models;
using Repuesto1.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Repuesto1
{
    public partial class GestionarVentasForm : Form
    {
        private readonly VentasServices _ventasServices;

        public GestionarVentasForm()
        {
            InitializeComponent();
            _ventasServices = Program.ServiceProvider.GetRequiredService<VentasServices>();
        }

        private void GestionarVentasForm_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private async void CargarVentas()
        {
            var ventas = await _ventasServices.GetList(v => true);

            dgvVentas.DataSource = ventas.Select(v => new
            {
                v.Id,
                v.NumeroFactura,
                v.Fecha,
                v.IdUsuario,
                v.SubTotal,
                v.Itebis,
                v.Total,
                v.Estado
            }).ToList();

            decimal totalGeneral = ventas.Sum(v => v.Total ?? 0);
            lblInfo.Text = $"Total Ventas: {totalGeneral:C2}";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La venta se realiza desde CajaForm");
        }
    }
}