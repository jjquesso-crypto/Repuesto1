namespace Repuesto1
{
    partial class GestionarProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvProductos;
        private Label lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.Location = new Point(12, 12);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(600, 300);
            dgvProductos.TabIndex = 0;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(12, 360);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(400, 20);
            lblInfo.TabIndex = 3;
            // 
            // GestionarProductForm
            // 
            ClientSize = new Size(634, 391);
            Controls.Add(dgvProductos);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GestionarProductForm";
            Text = "Gestión de Productos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }
    }
}