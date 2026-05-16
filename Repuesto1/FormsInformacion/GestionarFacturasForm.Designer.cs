namespace Repuesto1
{
    partial class GestionarFacturasForm
    {
        private DataGridView dgvFacturas;
        private Button btnAgregar;
        private Label lblInfo;

        private void InitializeComponent()
        {
            dgvFacturas = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // dgvFacturas
            // 
            dgvFacturas.Location = new Point(0, 55);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.Size = new Size(783, 394);
            dgvFacturas.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Imprimir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // GestionarFacturasForm
            // 
            ClientSize = new Size(784, 481);
            Controls.Add(button1);
            Controls.Add(dgvFacturas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GestionarFacturasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Facturas";
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);

        }

        private Button button1;
    }
}