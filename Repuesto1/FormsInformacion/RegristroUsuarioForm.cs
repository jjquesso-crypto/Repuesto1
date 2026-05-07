using Microsoft.Extensions.DependencyInjection;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Repuesto1.FormsInformacion
{
    public partial class RegristroUsuarioForm : Form
    {
        private readonly UsuarioServices _usuarioServices;

        public RegristroUsuarioForm()
        {
            InitializeComponent();
            _usuarioServices = Program.ServiceProvider.GetRequiredService<UsuarioServices>();
        }

        private async void RegristroUsuarioForm_Load(object sender, EventArgs e)
        {
            var roles = await _usuarioServices.ObtenerRoles();

            if (roles.Count == 0)
            {
                roles.Add("Administrador");
                roles.Add("Empleado");
                roles.Add("Cajero");
            }

            comboBox1.DataSource = roles;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string nombres = textBox1.Text.Trim();
            string apellidos = textBox4.Text.Trim();
            string clave = textBox3.Text.Trim();
            string rol = comboBox1.Text;

            if (nombres == "" || apellidos == "" || clave == "" || rol == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            string usuarioGenerado = (nombres + apellidos).Replace(" ", "").ToLower();

            var existentes = await _usuarioServices.GetList(x => x.NombreUsuario == usuarioGenerado);

            if (existentes.Any())
            {
                MessageBox.Show("Ese usuario ya existe, intente con otro nombre");
                return;
            }

            TblUsuario nuevo = new TblUsuario()
            {
                NombreCompleto = nombres + " " + apellidos,
                NombreUsuario = usuarioGenerado,
                Contraseña = clave,
                Rol = rol,
                Activo = true
            };

            bool guardo = await _usuarioServices.Guardar(nuevo);

            if (guardo)
            {
                MessageBox.Show("Usuario registrado correctamente\nSu usuario para ingresar es: " + usuarioGenerado);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}