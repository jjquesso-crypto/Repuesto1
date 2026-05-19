using Repuesto1.Data.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Repuesto1.FormsInformacion
{
    public partial class DetalleNominaForm : Form
    {
        private TblUsuario _usuario;

        public DetalleNominaForm(TblUsuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            CargarDatos();
        }

        public DetalleNominaForm()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            if (_usuario == null) return;

            txtNombreEmpleado.Text = _usuario.NombreCompleto;
            txtUsuario.Text = _usuario.NombreUsuario;
            txtRol.Text = _usuario.Rol;
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDiasTrabajados.Text = "30";

            decimal salario = ObtenerSalarioPorRol(_usuario.Rol);
            txtSalarioBase.Text = salario.ToString("N2");
            txtTotalDevengado.Text = salario.ToString("N2");

            // Deducciones aproximadas
            decimal afp = salario * 0.0287m;
            decimal sfs = salario * 0.0304m;
            decimal totalDeducciones = afp + sfs;
            decimal neto = salario - totalDeducciones;

            txtAFP.Text = afp.ToString("N2");
            txtSFS.Text = sfs.ToString("N2");
            txtTotalDeducciones.Text = totalDeducciones.ToString("N2");
            txtNeto.Text = neto.ToString("N2");
        }

        private decimal ObtenerSalarioPorRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol))
                return 0;

            rol = rol.Trim().ToLower();

            switch (rol)
            {
                case "cajero":
                    return 20000m;

                case "administrador":
                case "admin":
                    return 35000m;

                default:
                    return 15000m;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            using (System.Drawing.Printing.PrintDocument printDocument =
                   new System.Drawing.Printing.PrintDocument())
            {
                printDocument.PrintPage += (s, ev) =>
                {
                    Bitmap bmp = new Bitmap(panelNomina.Width, panelNomina.Height);
                    panelNomina.DrawToBitmap(
                        bmp,
                        new Rectangle(0, 0, panelNomina.Width, panelNomina.Height)
                    );

                    Rectangle area = ev.MarginBounds;

                    float ratioX = (float)area.Width / bmp.Width;
                    float ratioY = (float)area.Height / bmp.Height;
                    float ratio = Math.Min(ratioX, ratioY);

                    int width = (int)(bmp.Width * ratio);
                    int height = (int)(bmp.Height * ratio);

                    
                    ev.Graphics.DrawImage(
                        bmp,
                        area.Left,
                        area.Top,
                        width,
                        height
                    );
                };

                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }
    }
}