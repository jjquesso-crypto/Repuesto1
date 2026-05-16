using Repuesto1.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Repuesto1.FormsInformacion
{
    public partial class IngresoForm : Form
    {
        private readonly UsuarioServices _usuarioServices;

        public IngresoForm()
        {
            InitializeComponent();
            _usuarioServices = Program.ServiceProvider.GetRequiredService<UsuarioServices>();
        }

        private void IngresoForm_Load(object sender, EventArgs e)
        {
            button2.Text = "ENTRAR";
            textBox1.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string usuario = textBox3.Text.Trim();
            string clave = textBox1.Text.Trim();

            if (usuario == "" || clave == "")
            {
                MessageBox.Show("Debe completar usuario y contraseña");
                return;
            }

            var existe = await _usuarioServices.ValidarLogin(usuario, clave);
            if (existe != null)
            {
                SesionActual.NombreUsuario = existe.NombreUsuario; // ← aquí
                SesionActual.Rol = existe.Rol ?? "";

                this.Hide();

                string rol = existe.Rol?.ToLower() ?? "";

                if (rol == "caja")
                {
                    var caja = Program.ServiceProvider.GetRequiredService<GestionarCajaForm>();
                    caja.ShowDialog();
                }
                else
                {
                    var principal = Program.ServiceProvider.GetRequiredService<Form1>();
                    principal.ShowDialog();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            var frm = Program.ServiceProvider.GetRequiredService<RegristroUsuarioForm>();
            frm.ShowDialog();

            this.Show();
        }
    }
}
