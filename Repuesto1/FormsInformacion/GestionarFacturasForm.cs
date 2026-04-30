using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Data;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;

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
            using (var db = new RepuestoContext())
            {
                var compras = (from c in db.TblCompras
                               join p in db.TblProveedores on c.IdProveedor equals p.Id
                               orderby c.Fecha descending
                               select new
                               {
                                   c.Id,
                                   c.NumeroFactura,
                                   c.Fecha,
                                   Proveedor = p.Nombre,
                                   c.SubTotal,
                                   c.Iva,
                                   c.Total,
                                   c.Estado
                               }).ToList();

                dgvFacturas.DataSource = compras;
                lblInfo.Text = $"Total Compras: {compras.Sum(c => c.Total):C2}";
            }
        }
    }
}