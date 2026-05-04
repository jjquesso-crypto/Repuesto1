namespace Repuesto1
{
    partial class GestionarCajaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtFactura = new TextBox();
            txtFecha = new TextBox();
            txtUsuario = new TextBox();
            comboBox1 = new ComboBox();
            txtCantidad = new TextBox();
            label4 = new Label();
            label5 = new Label();
            btnDetalle = new Button();
            btnQuitar = new Button();
            dataGridView1 = new DataGridView();
            lblSubTotal = new Label();
            lblItebis = new Label();
            lblTotal = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnCobrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(280, 9);
            label1.Text = "MODULO DE CAJA";

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(25, 55);
            label2.Text = "No. Factura";

            // label3
            label3.AutoSize = true;
            label3.Location = new Point(250, 55);
            label3.Text = "Fecha";

            txtFactura.Location = new Point(95, 52);
            txtFactura.Size = new Size(120, 23);

            txtFecha.Location = new Point(290, 52);
            txtFecha.Size = new Size(120, 23);

            txtUsuario.Location = new Point(530, 52);
            txtUsuario.Size = new Size(150, 23);

            label4.AutoSize = true;
            label4.Location = new Point(470, 55);
            label4.Text = "Usuario";

            // combo productos
            comboBox1.Location = new Point(25, 110);
            comboBox1.Size = new Size(260, 23);

            // cantidad
            txtCantidad.Location = new Point(320, 110);
            txtCantidad.Size = new Size(90, 23);

            label5.AutoSize = true;
            label5.Location = new Point(320, 90);
            label5.Text = "Cantidad";

            label6.AutoSize = true;
            label6.Location = new Point(25, 90);
            label6.Text = "Producto";

            // boton detalle
            btnDetalle.Location = new Point(440, 103);
            btnDetalle.Size = new Size(100, 32);
            btnDetalle.Text = "AGREGAR";
            btnDetalle.BackColor = Color.LightGreen;
            btnDetalle.Click += btnDetalle_Click;

            // boton quitar
            btnQuitar.Location = new Point(560, 103);
            btnQuitar.Size = new Size(100, 32);
            btnQuitar.Text = "QUITAR";
            btnQuitar.BackColor = Color.MistyRose;
            btnQuitar.Click += btnQuitar_Click;

            // datagrid
            dataGridView1.Location = new Point(25, 155);
            dataGridView1.Size = new Size(680, 220);
            dataGridView1.BackgroundColor = Color.White;

            // subtotal
            label7.AutoSize = true;
            label7.Location = new Point(470, 395);
            label7.Text = "SubTotal:";

            lblSubTotal.AutoSize = true;
            lblSubTotal.Location = new Point(560, 395);
            lblSubTotal.Text = "0.00";

            // itebis
            label8.AutoSize = true;
            label8.Location = new Point(470, 420);
            label8.Text = "ITEBIS:";

            lblItebis.AutoSize = true;
            lblItebis.Location = new Point(560, 420);
            lblItebis.Text = "0.00";

            // total
            Label label9 = new Label();
            label9.AutoSize = true;
            label9.Location = new Point(470, 445);
            label9.Text = "TOTAL:";
            Controls.Add(label9);

            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Red;
            lblTotal.Location = new Point(560, 442);
            lblTotal.Text = "0.00";

            // cobrar
            btnCobrar.Location = new Point(25, 405);
            btnCobrar.Size = new Size(140, 45);
            btnCobrar.Text = "COBRAR";
            btnCobrar.BackColor = Color.Gold;
            btnCobrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCobrar.Click += btnCobrar_Click;

            // form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(734, 481);
            Controls.Add(btnCobrar);
            Controls.Add(lblTotal);
            Controls.Add(lblItebis);
            Controls.Add(lblSubTotal);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dataGridView1);
            Controls.Add(btnQuitar);
            Controls.Add(btnDetalle);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtCantidad);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(txtUsuario);
            Controls.Add(txtFecha);
            Controls.Add(txtFactura);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GestionarCajaForm";
            Text = "GestionarCajaForm";
            Load += GestionarCajaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtFactura;
        private TextBox txtFecha;
        private TextBox txtUsuario;
        private ComboBox comboBox1;
        private TextBox txtCantidad;
        private Label label4;
        private Label label5;
        private Button btnDetalle;
        private Button btnQuitar;
        private DataGridView dataGridView1;
        private Label lblSubTotal;
        private Label lblItebis;
        private Label lblTotal;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnCobrar;
    }
}