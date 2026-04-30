using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Data;
using Repuesto1.Data.Models;
using Repuesto1.Data.Context;

namespace Repuesto1
{
    public partial class GestionarProductForm : Form
    {
        public GestionarProductForm()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            using (var db = new RepuestoContext())
            {
                var productos = db.TblProductos.Where(p => p.Inactivo == false).ToList();
                dgvProductos.DataSource = productos;

                // Mostrar totales
                lblInfo.Text = $"Total: {productos.Count} productos | Stock: {productos.Sum(p => p.Cantidad)} unidades";
            }
        }
    }
}

