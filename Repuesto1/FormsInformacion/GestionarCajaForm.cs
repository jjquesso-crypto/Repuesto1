using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Repuesto1
{
    public partial class GestionarCajaForm : Form
    {
        public GestionarCajaForm()
        {
            InitializeComponent();
        }

        // 🔹 LOAD DEL FORM
        private void GestionarCajaForm_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Cargar productos en el ComboBox
            using (var db = new RepuestoContext())
            {
                comboBox1.DataSource = db.TblProductos
                    .Where(p => p.Inactivo == false)
                    .ToList();

                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = -1;
            }

            // Configurar columnas del DataGrid
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdProducto", "IdProducto");
            dataGridView1.Columns.Add("Producto", "Producto");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("SubTotal", "SubTotal");

            dataGridView1.AllowUserToAddRows = false;
        }

        // 🔹 BOTÓN AGREGAR AL DETALLE
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí agregarás el producto al detalle");
        }

        // 🔹 BOTÓN QUITAR PRODUCTO
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        // 🔹 BOTÓN COBRAR
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí irá la lógica de guardar la venta");
        }

        // 🔹 MÉTODO PARA CALCULAR TOTALES (LO USARÁS DESPUÉS)
        private void CalcularTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells["SubTotal"].Value != null)
                {
                    subtotal += Convert.ToDecimal(fila.Cells["SubTotal"].Value);
                }
            }

            decimal itebis = subtotal * 0.18m;
            decimal total = subtotal + itebis;

            lblSubTotal.Text = subtotal.ToString("N2");
            lblItebis.Text = itebis.ToString("N2");
            lblTotal.Text = total.ToString("N2");
        }
    }
}