using Repuesto1.Model;
namespace Repuesto1
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Crear nueva instancia para verificar (NO usar Program.DbContext con using)
                using (var db = new AppDbContext())
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
            MessageBox.Show("Botón productos funcionando");
        }

        private void Producto_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un producto de prueba
                using (var db = new AppDbContext())
                {
                    var nuevoProducto = new Producto
                    {
                        Nombre = "Producto de Prueba",
                        Precio = 99.99m,
                        Cantidad = 10,
                        Inactivo = false
                    };

                    db.Productos.Add(nuevoProducto);
                    db.SaveChanges();

                    MessageBox.Show($"✅ Producto agregado con ID: {nuevoProducto.Id}", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}", "Error");
            }
        }
    }
}
