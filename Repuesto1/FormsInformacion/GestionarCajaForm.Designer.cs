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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarCajaForm));
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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(482, 9);
            label1.Name = "label1";
            label1.Size = new Size(332, 48);
            label1.TabIndex = 20;
            label1.Text = "MODULO DE CAJA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(30, 80);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 19;
            label2.Text = "No. Factura";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(523, 87);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 18;
            label3.Text = "Fecha";
            // 
            // txtFactura
            // 
            txtFactura.Font = new Font("Segoe UI", 11F);
            txtFactura.Location = new Point(119, 73);
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new Size(291, 27);
            txtFactura.TabIndex = 17;
            txtFactura.TextChanged += txtFactura_TextChanged;
            // 
            // txtFecha
            // 
            txtFecha.Font = new Font("Segoe UI", 11F);
            txtFecha.Location = new Point(576, 80);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(198, 27);
            txtFecha.TabIndex = 16;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(961, 80);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(269, 27);
            txtUsuario.TabIndex = 15;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(30, 148);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre o ID...";
            txtBuscar.Size = new Size(380, 27);
            txtBuscar.TabIndex = 22;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 11F);
            comboBox1.Location = new Point(30, 213);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(380, 28);
            comboBox1.TabIndex = 13;
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Segoe UI", 11F);
            txtCantidad.Location = new Point(576, 214);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(198, 27);
            txtCantidad.TabIndex = 12;
            txtCantidad.KeyPress += txtCantidad_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(896, 87);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 14;
            label4.Text = "Usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(501, 221);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 11;
            label5.Text = "Cantidad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(30, 190);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 10;
            label6.Text = "Producto";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(896, 629);
            label7.Name = "label7";
            label7.Size = new Size(72, 21);
            label7.TabIndex = 6;
            label7.Text = "SubTotal:";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(913, 668);
            label8.Name = "label8";
            label8.Size = new Size(55, 21);
            label8.TabIndex = 5;
            label8.Text = "ITEBIS:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label9.Location = new Point(900, 758);
            label9.Name = "label9";
            label9.Size = new Size(72, 25);
            label9.TabIndex = 0;
            label9.Text = "TOTAL:";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 11F);
            lblBuscar.Location = new Point(30, 125);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(52, 20);
            lblBuscar.TabIndex = 21;
            lblBuscar.Text = "Buscar";
            // 
            // btnDetalle
            // 
            btnDetalle.BackColor = Color.LightGreen;
            btnDetalle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDetalle.Location = new Point(900, 201);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(150, 40);
            btnDetalle.TabIndex = 9;
            btnDetalle.Text = "AGREGAR";
            btnDetalle.UseVisualStyleBackColor = false;
            btnDetalle.Click += btnDetalle_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.BackColor = Color.MistyRose;
            btnQuitar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnQuitar.Location = new Point(1080, 201);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(150, 40);
            btnQuitar.TabIndex = 8;
            btnQuitar.Text = "QUITAR";
            btnQuitar.UseVisualStyleBackColor = false;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnCobrar
            // 
            btnCobrar.BackColor = Color.Gold;
            btnCobrar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCobrar.Location = new Point(30, 629);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(200, 60);
            btnCobrar.TabIndex = 1;
            btnCobrar.Text = "COBRAR";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.Font = new Font("Segoe UI", 11F);
            dataGridView1.Location = new Point(30, 265);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Size = new Size(1200, 358);
            dataGridView1.TabIndex = 7;
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new Font("Segoe UI", 12F);
            lblSubTotal.Location = new Point(995, 629);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(40, 21);
            lblSubTotal.TabIndex = 4;
            lblSubTotal.Text = "0.00";
            // 
            // lblItebis
            // 
            lblItebis.AutoSize = true;
            lblItebis.Font = new Font("Segoe UI", 12F);
            lblItebis.Location = new Point(995, 668);
            lblItebis.Name = "lblItebis";
            lblItebis.Size = new Size(40, 21);
            lblItebis.TabIndex = 3;
            lblItebis.Text = "0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Red;
            lblTotal.Location = new Point(1147, 647);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 25);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "0.00";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1248, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 728);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // GestionarCajaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(1356, 749);
            Controls.Add(pictureBox1);
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
            Name = "GestionarCajaForm";
            Text = "GestionarCajaForm";
            WindowState = FormWindowState.Maximized;
            Load += GestionarCajaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}