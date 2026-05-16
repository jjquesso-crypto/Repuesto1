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
            txtBuscar = new TextBox();
            comboBox1 = new ComboBox();
            txtCantidad = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblBuscar = new Label();
            btnDetalle = new Button();
            btnQuitar = new Button();
            btnCobrar = new Button();
            dataGridView1 = new DataGridView();
            lblSubTotal = new Label();
            lblItebis = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // label1 - título
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(280, 9);
            label1.Name = "label1";
            label1.Size = new Size(187, 28);
            label1.TabIndex = 20;
            label1.Text = "MODULO DE CAJA";

            // label2 - No. Factura
            label2.AutoSize = true;
            label2.Location = new Point(25, 55);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 19;
            label2.Text = "No. Factura";

            // label3 - Fecha
            label3.AutoSize = true;
            label3.Location = new Point(250, 55);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 18;
            label3.Text = "Fecha";

            // txtFactura
            txtFactura.Location = new Point(95, 52);
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new Size(120, 23);
            txtFactura.TabIndex = 17;
            txtFactura.TextChanged += txtFactura_TextChanged;

            // txtFecha
            txtFecha.Location = new Point(290, 52);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(120, 23);
            txtFecha.TabIndex = 16;

            // txtUsuario
            txtUsuario.Location = new Point(530, 52);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(150, 23);
            txtUsuario.TabIndex = 15;

            // label4 - Usuario
            label4.AutoSize = true;
            label4.Location = new Point(470, 55);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 14;
            label4.Text = "Usuario";

            // lblBuscar
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(25, 90);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(56, 15);
            lblBuscar.TabIndex = 21;
            lblBuscar.Text = "Buscar";

            // txtBuscar
            txtBuscar.Location = new Point(25, 108);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(260, 23);
            txtBuscar.PlaceholderText = "Buscar por nombre o ID...";
            txtBuscar.TabIndex = 22;

            // label6 - Producto
            label6.AutoSize = true;
            label6.Location = new Point(25, 138);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 10;
            label6.Text = "Producto";

            // comboBox1
            comboBox1.Location = new Point(25, 155);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(260, 23);
            comboBox1.TabIndex = 13;

            // label5 - Cantidad
            label5.AutoSize = true;
            label5.Location = new Point(320, 138);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 11;
            label5.Text = "Cantidad";

            // txtCantidad
            txtCantidad.Location = new Point(320, 155);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(90, 23);
            txtCantidad.TabIndex = 12;
            txtCantidad.KeyPress += txtCantidad_KeyPress;

            // btnDetalle
            btnDetalle.BackColor = Color.LightGreen;
            btnDetalle.Location = new Point(440, 150);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(100, 32);
            btnDetalle.TabIndex = 9;
            btnDetalle.Text = "AGREGAR";
            btnDetalle.UseVisualStyleBackColor = false;
            btnDetalle.Click += btnDetalle_Click;

            // btnQuitar
            btnQuitar.BackColor = Color.MistyRose;
            btnQuitar.Location = new Point(560, 150);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(100, 32);
            btnQuitar.TabIndex = 8;
            btnQuitar.Text = "QUITAR";
            btnQuitar.UseVisualStyleBackColor = false;
            btnQuitar.Click += btnQuitar_Click;

            // dataGridView1
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.Location = new Point(25, 195);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(680, 190);
            dataGridView1.TabIndex = 7;

            // label7 - SubTotal
            label7.AutoSize = true;
            label7.Location = new Point(470, 405);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 6;
            label7.Text = "SubTotal:";

            // label8 - ITEBIS
            label8.AutoSize = true;
            label8.Location = new Point(470, 430);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 5;
            label8.Text = "ITEBIS:";

            // label9 - TOTAL
            label9.AutoSize = true;
            label9.Location = new Point(470, 455);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 0;
            label9.Text = "TOTAL:";

            // lblSubTotal
            lblSubTotal.AutoSize = true;
            lblSubTotal.Location = new Point(560, 405);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(28, 15);
            lblSubTotal.TabIndex = 4;
            lblSubTotal.Text = "0.00";

            // lblItebis
            lblItebis.AutoSize = true;
            lblItebis.Location = new Point(560, 430);
            lblItebis.Name = "lblItebis";
            lblItebis.Size = new Size(28, 15);
            lblItebis.TabIndex = 3;
            lblItebis.Text = "0.00";

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Red;
            lblTotal.Location = new Point(560, 452);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(40, 20);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "0.00";

            // btnCobrar
            btnCobrar.BackColor = Color.Gold;
            btnCobrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCobrar.Location = new Point(25, 415);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(140, 45);
            btnCobrar.TabIndex = 1;
            btnCobrar.Text = "COBRAR";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click;

            // GestionarCajaForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(734, 481);
            Controls.Add(label9);
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
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(label4);
            Controls.Add(txtUsuario);
            Controls.Add(txtFecha);
            Controls.Add(txtFactura);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private TextBox txtBuscar;
        private ComboBox comboBox1;
        private TextBox txtCantidad;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblBuscar;
        private Button btnDetalle;
        private Button btnQuitar;
        private Button btnCobrar;
        private DataGridView dataGridView1;
        private Label lblSubTotal;
        private Label lblItebis;
        private Label lblTotal;
    }
}