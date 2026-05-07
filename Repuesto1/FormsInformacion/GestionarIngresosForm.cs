using Repuesto1.Data.Models;
using Repuesto1.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Repuesto1
{
    public partial class GestionarIngresosForm : Form
    {
        private readonly IngresoServices _ingresoServices;

        public GestionarIngresosForm()
        {
            InitializeComponent();
            _ingresoServices = Program.ServiceProvider.GetRequiredService<IngresoServices>();
            CargarIngresos();
        }

        private async void CargarIngresos()
        {
            var ingresos = await _ingresoServices.GetList(i => true);

            dgvIngresos.DataSource = ingresos
                .Select(i => new
                {
                    i.Id,
                    i.Fecha,
                    i.Tipo,
                    i.Concepto,
                    i.Monto,
                    i.TipoReferencia
                })
                .ToList();

            lblInfo.Text = $"Total Ingresos: {ingresos.Sum(i => i.Monto):C2}";
        }
    }
}