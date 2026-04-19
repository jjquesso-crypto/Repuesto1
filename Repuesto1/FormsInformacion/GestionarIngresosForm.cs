using System;
using System.Linq;
using System.Windows.Forms;
using Repuesto1.Model;

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
            using  (var db = new AppDbContext())
            {
                var ingresos = db.Ingresos.Where(m => m.Tipo == "INGRESO").OrderByDescending(m => m.Fecha).ToList();
                dgvIngresos.DataSource = ingresos;
                lblInfo.Text = $"Total Ingresos: {ingresos.Sum(i => i.Monto):C2}";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new System.Drawing.Size(300, 200);
            frm.Text = "Nuevo Ingreso";

            var txtConcepto = new TextBox() { Location = new System.Drawing.Point(10, 30), Width = 260, PlaceholderText = "Concepto" };
            var txtMonto = new TextBox() { Location = new System.Drawing.Point(10, 70), Width = 260, PlaceholderText = "Monto" };
            var btnOk = new Button() { Text = "Guardar", Location = new System.Drawing.Point(10, 110), Width = 260 };

            frm.Controls.Add(txtConcepto);
            frm.Controls.Add(txtMonto);
            frm.Controls.Add(btnOk);

            btnOk.Click += (s, ev) =>
            {
                using (var db = new AppDbContext())
                {
                    db.Ingresos.Add(new Ingreso()
                    {
                        Concepto = txtConcepto.Text,
                        Monto = decimal.Parse(txtMonto.Text),
                        Tipo = "INGRESO",
                        Fecha = DateTime.Now
                    });
                    db.SaveChanges();
                    frm.Close();
                    CargarIngresos();
                }
            };
            frm.ShowDialog();
        }
    }
}