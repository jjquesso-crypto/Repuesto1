namespace Repuesto1.FormsInformacion
{
    partial class NominaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvNomina;
        private System.Windows.Forms.Label lblInfo;

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
            dgvNomina = new DataGridView();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNomina).BeginInit();
            SuspendLayout();
            // 
            // dgvNomina
            // 
            dgvNomina.AllowUserToAddRows = false;
            dgvNomina.AllowUserToDeleteRows = false;
            dgvNomina.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNomina.Location = new Point(12, 50);
            dgvNomina.Name = "dgvNomina";
            dgvNomina.ReadOnly = true;
            dgvNomina.Size = new Size(760, 350);
            dgvNomina.TabIndex = 0;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblInfo.Location = new Point(12, 15);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(122, 16);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Total Usuarios: 0";
            // 
            // NominaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(lblInfo);
            Controls.Add(dgvNomina);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "NominaForm";
            Text = "Nómina - Usuarios";
            Load += NominaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNomina).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}