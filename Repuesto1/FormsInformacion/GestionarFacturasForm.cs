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
                // Solo mostrar las compras
                var compras = db.Compras.OrderByDescending(c => c.Fecha).ToList();
                dgvFacturas.DataSource = compras;
                lblInfo.Text = $"Total Compras: {compras.Sum(c => c.Total):C2}";
            }
        }
    }
}