using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Data;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;

namespace Repuesto1
{
    public partial class GestionarIngresosForm : Form
    {
        public GestionarIngresosForm()
        {
            InitializeComponent();
            CargarIngresos();
        }

        private void CargarIngresos()
        {
            using (var db = new RepuestoContext())
            {
                var ingresos = db.TblIngresos
                    .OrderByDescending(m => m.Fecha)
                    .ToList();

                dgvIngresos.DataSource = ingresos;

                lblInfo.Text = $"Total Ingresos: {ingresos.Sum(i => i.Monto):C2}";
            }
        }
    }
}