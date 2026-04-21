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
            btnAgregar = new Button();
            lblInfo = new Label();
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
            // btnAgregar
            // 
            btnAgregar.Location = new Point(0, 26);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(100, 23);
            lblInfo.TabIndex = 2;
            // 
            // GestionarFacturasForm
            // 
            ClientSize = new Size(784, 481);
            Controls.Add(dgvFacturas);
            Controls.Add(btnAgregar);
            Controls.Add(lblInfo);
            Name = "GestionarFacturasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Facturas";
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);

        }
    }
}