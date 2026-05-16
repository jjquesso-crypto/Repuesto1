using System;
using System.IO;
using System.Linq;
using System.Text;
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
            ConfigurarDataGridView();
            CargarFacturas();
        }

        private void ConfigurarDataGridView()
        {
            // Permitir seleccionar filas completas
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Solo una factura a la vez
            dgvFacturas.MultiSelect = false;
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
            }
        }

        // Evento del botón Exportar
        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar que hay una factura seleccionada
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una factura haciendo clic en ella.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportarFacturaSeleccionada();
        }

        // Método para exportar la factura seleccionada
        private void ExportarFacturaSeleccionada()
        {
            // Obtener la fila seleccionada
            DataGridViewRow row = dgvFacturas.SelectedRows[0];

            // Extraer los datos de la factura
            int idFactura = Convert.ToInt32(row.Cells["Id"].Value);
            string numeroFactura = row.Cells["NumeroFactura"].Value?.ToString() ?? "SinNumero";
            DateTime fecha = Convert.ToDateTime(row.Cells["Fecha"].Value);
            string proveedor = row.Cells["Proveedor"].Value?.ToString() ?? "SinProveedor";
            decimal subTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value);
            decimal iva = Convert.ToDecimal(row.Cells["Iva"].Value);
            decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
            string estado = row.Cells["Estado"].Value?.ToString() ?? "SinEstado";

            // Diálogo para elegir dónde guardar el archivo
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Archivo de texto|*.txt";
                saveDialog.Title = "Guardar factura";
                saveDialog.FileName = $"Factura_{numeroFactura}_{DateTime.Now:yyyyMMddHHmmss}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string contenido = GenerarContenidoFactura(idFactura, numeroFactura, fecha,
                                                              proveedor, subTotal, iva, total, estado);

                    File.WriteAllText(saveDialog.FileName, contenido);

                    MessageBox.Show($"¡Factura exportada exitosamente!\n\nUbicación: {saveDialog.FileName}",
                                    "Exportación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Método para generar el contenido del TXT
        private string GenerarContenidoFactura(int id, string numeroFactura, DateTime fecha,
                                               string proveedor, decimal subTotal, decimal iva,
                                               decimal total, string estado)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=".PadRight(50, '='));
            sb.AppendLine("              FACTURA DE COMPRA");
            sb.AppendLine("=".PadRight(50, '='));
            sb.AppendLine();
            sb.AppendLine($"ID Factura: {id}");
            sb.AppendLine($"Número Factura: {numeroFactura}");
            sb.AppendLine($"Fecha: {fecha:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"Proveedor: {proveedor}");
            sb.AppendLine($"Estado: {estado}");
            sb.AppendLine();
            sb.AppendLine("-".PadRight(50, '-'));
            sb.AppendLine("DETALLE DE PAGO");
            sb.AppendLine("-".PadRight(50, '-'));
            sb.AppendLine($"SubTotal: {subTotal:C}");
            sb.AppendLine($"IVA: {iva:C}");
            sb.AppendLine($"TOTAL: {total:C}");
            sb.AppendLine("-".PadRight(50, '-'));
            sb.AppendLine($"Fecha de exportación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine("=".PadRight(50, '='));

            return sb.ToString();
        }
    }
}