namespace Repuesto1
{
    partial class GestionarVentasForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvVentas;
        private Button btnDetalle;
        private Label lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvVentas = new DataGridView();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // dgvVentas
            // 
            dgvVentas.Location = new Point(12, 12);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(760, 380);
            dgvVentas.TabIndex = 0;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfo.Location = new Point(600, 417);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(117, 19);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "Total Vendido: 0";
            // 
            // GestionarVentasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(lblInfo);
            Controls.Add(dgvVentas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GestionarVentasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caja / Ventas";
            Load += GestionarVentasForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}