namespace Repuesto1
{
    partial class GestionarIngresosForm
    {
        private DataGridView dgvIngresos;
        private Button btnAgregar;
        private Label lblInfo;

        private void InitializeComponent()
        {
            dgvIngresos = new DataGridView();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).BeginInit();
            SuspendLayout();
            // 
            // dgvIngresos
            // 
            dgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngresos.Location = new Point(12, 12);
            dgvIngresos.Name = "dgvIngresos";
            dgvIngresos.ReadOnly = true;
            dgvIngresos.Size = new Size(760, 400);
            dgvIngresos.TabIndex = 0;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(100, 23);
            lblInfo.TabIndex = 2;
            // 
            // GestionarIngresosForm
            // 
            ClientSize = new Size(784, 481);
            Controls.Add(dgvIngresos);
            Controls.Add(lblInfo);
            Name = "GestionarIngresosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingresos";
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).EndInit();
            ResumeLayout(false);
        }
    }
}