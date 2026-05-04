using Microsoft.Extensions.DependencyInjection;
using Repuesto1.Data;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using Repuesto1.FormsInformacion;

namespace Repuesto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region EventosSinUso
        private void Form1_Load(object sender, EventArgs e)
        {
            // Sin implementación por el momento
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Sin implementación por el momento
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sin implementación por el momento
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Sin implementación por el momento
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Sin implementación por el momento
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Sin implementación por el momento
        }
        #endregion

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<GestionarProveedorForm>();
            form.ShowDialog();
        }

        private void Producto_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<GestionarProductForm>();
            form.ShowDialog();
        }

        private void toolStripIngresos_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<GestionarIngresosForm>();
            form.ShowDialog();
        }

        private void toolStripCompras_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<GestionarComprasForm>();
            form.ShowDialog();
        }

        private void toolStripFacturas_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<GestionarFacturasForm>();
            form.ShowDialog();
        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<GestionarCajaForm>();
            form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            IngresoForm login = new IngresoForm();
            login.ShowDialog();

            this.Close();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<GestionarVentasForm>();
            form.ShowDialog();
        }
    }
}