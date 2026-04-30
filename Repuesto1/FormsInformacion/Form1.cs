using Repuesto1.Data;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
namespace Repuesto1
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Crear nueva instancia para verificar (NO usar Program.DbContext con using)
                using (var db = new RepuestoContext())
                {
                    db.Database.EnsureCreated();
                    MessageBox.Show("✅ Base de datos lista", "Éxito");
                }
            }
            catch (Exception ex)  // ← Faltaba esto
            {
                MessageBox.Show($"❌ Error: {ex.Message}", "Error");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new GestionarProveedorForm().ShowDialog();
        }

        private void Producto_Click(object sender, EventArgs e)
        {
            new GestionarProductForm().ShowDialog();
        }

        private void toolStripIngresos_Click(object sender, EventArgs e)
        {
            new GestionarIngresosForm().ShowDialog();
        }

        private void toolStripCompras_Click(object sender, EventArgs e)
        {
            new GestionarComprasForm().ShowDialog();
        }

        private void toolStripFacturas_Click(object sender, EventArgs e)
        {
            new GestionarFacturasForm().ShowDialog();
        }
    }
}
