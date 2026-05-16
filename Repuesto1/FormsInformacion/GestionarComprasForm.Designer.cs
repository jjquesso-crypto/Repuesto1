namespace Repuesto1
{
    partial class GestionarComprasForm
    {
        private DataGridView dgvCompras;
        private Button btnAgregar;
        private Label lblInfo;

        private void InitializeComponent()
        {
            dgvCompras = new DataGridView();
            btnAgregar = new Button();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            SuspendLayout();
            // 
            // dgvCompras
            // 
            dgvCompras.Location = new Point(12, 50);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.Size = new Size(738, 369);
            dgvCompras.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 437);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(88, 32);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(12, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(100, 23);
            lblInfo.TabIndex = 2;
            lblInfo.Click += lblInfo_Click_1;
            // 
            // GestionarComprasForm
            // 
            ClientSize = new Size(784, 481);
            Controls.Add(dgvCompras);
            Controls.Add(btnAgregar);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GestionarComprasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compras";
            Load += GestionarComprasForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ResumeLayout(false);
        }
    }
}