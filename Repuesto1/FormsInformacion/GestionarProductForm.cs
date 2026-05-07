using Repuesto1.Data.Models;
using Repuesto1.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Repuesto1
{
    public partial class GestionarProductForm : Form
    {
        private readonly ProductoServices _productoServices;

        public GestionarProductForm()
        {
            InitializeComponent();
            _productoServices = Program.ServiceProvider.GetRequiredService<ProductoServices>();
            CargarProductos();
        }

        private async void CargarProductos()
        {
            var productos = await _productoServices.GetList(p => p.Inactivo == false);

            dgvProductos.DataSource = productos;

            lblInfo.Text =
                $"Total: {productos.Count} productos | Stock: {productos.Sum(p => p.Cantidad)} unidades";
        }
    }
}