using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Repuesto1
{
    public partial class GestionarCajaForm : Form
    {
        public GestionarCajaForm()
        {
            InitializeComponent();
        }

        private void GestionarCajaForm_Load(object sender, EventArgs e)
        {
            txtFactura.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtUsuario.ReadOnly = true;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtUsuario.Text = SesionActual.NombreUsuario; 
            GenerarNumeroFactura();

          
            using (var db = new RepuestoContext())
            {
                comboBox1.DataSource = db.TblProductos
                    .Where(p => p.Inactivo == false && p.Cantidad > 0)
                    .ToList();

                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = -1;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdProducto", "IdProducto");
            dataGridView1.Columns.Add("Producto", "Producto");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("SubTotal", "SubTotal");

            dataGridView1.Columns["IdProducto"].Visible = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void GenerarNumeroFactura()
        {
            using (var db = new RepuestoContext())
            {
                int ultimoId = 0;

                if (db.TblVentas.Any())
                {
                    ultimoId = db.TblVentas.Max(x => x.Id);
                }

                int nuevoNumero = ultimoId + 1;

                txtFactura.Text = "FAC-" + nuevoNumero.ToString("0000");
            }
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || txtCantidad.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione producto y cantidad");
                return;
            }

            int cantidad = Convert.ToInt32(txtCantidad.Text);

            using (var db = new RepuestoContext())
            {
                int idProducto = Convert.ToInt32(comboBox1.SelectedValue);

                var producto = db.TblProductos.FirstOrDefault(p => p.Id == idProducto);

                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado");
                    return;
                }

                // Cantidad ya agregada en la tabla para ese producto
                int yaAgregado = 0;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(r.Cells["IdProducto"].Value) == idProducto)
                        yaAgregado += Convert.ToInt32(r.Cells["Cantidad"].Value);
                }

                if (cantidad + yaAgregado > producto.Cantidad)
                {
                    MessageBox.Show($"No hay suficiente existencia. Disponible: {producto.Cantidad - yaAgregado}");
                    return;
                }

                decimal precio = Convert.ToDecimal(producto.Precio);
                decimal subtotal = precio * cantidad;

                dataGridView1.Rows.Add(producto.Id, producto.Nombre, cantidad, precio, subtotal);

                CalcularTotales();

                comboBox1.SelectedIndex = -1;
                txtCantidad.Clear();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                CalcularTotales();
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar productos");
                return;
            }

            using (var db = new RepuestoContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        TblVentas venta = new TblVentas()
                        {
                            NumeroFactura = txtFactura.Text,
                            Fecha = DateTime.Now,
                            SubTotal = Convert.ToDecimal(lblSubTotal.Text),
                            Itebis = Convert.ToDecimal(lblItebis.Text),
                            Total = Convert.ToDecimal(lblTotal.Text),
                            Estado = "PAGADA"
                        };

                        db.TblVentas.Add(venta);
                        db.SaveChanges();

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            TblDetalleVentas detalle = new TblDetalleVentas()
                            {
                                IdVenta = venta.Id,
                                IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                                Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                                PrecioVenta = Convert.ToDecimal(row.Cells["Precio"].Value),
                                SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value)
                            };

                            db.TblDetalleVentas.Add(detalle);
                            var prod = db.TblProductos.Find(Convert.ToInt32(row.Cells["IdProducto"].Value));
                            if (prod != null)
                            prod.Cantidad -= Convert.ToInt32(row.Cells["Cantidad"].Value);
                        }

                        db.SaveChanges();

                        TblIngreso ingreso = new TblIngreso()
                        {
                            Fecha = DateTime.Now,
                            Tipo = "VENTA",
                            Concepto = "Venta Factura " + txtFactura.Text,
                            Monto = venta.Total ?? 0,
                            IdReferencia = venta.Id,
                            TipoReferencia = "VENTA"
                        };

                        db.TblIngresos.Add(ingreso);
                        db.SaveChanges();

                        transaction.Commit();

                        MessageBox.Show("Venta registrada correctamente");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            dataGridView1.Rows.Clear();
            CalcularTotales();
            GenerarNumeroFactura();

            using (var db = new RepuestoContext())
            {
                comboBox1.DataSource = db.TblProductos
                    .Where(p => p.Inactivo == false)
                    .ToList();
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = -1;
            }
        }

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

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}