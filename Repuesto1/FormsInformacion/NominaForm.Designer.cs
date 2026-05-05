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
            this.dgvNomina = new System.Windows.Forms.DataGridView();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvNomina
            // 
            this.dgvNomina.AllowUserToAddRows = false;
            this.dgvNomina.AllowUserToDeleteRows = false;
            this.dgvNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNomina.Location = new System.Drawing.Point(12, 50);
            this.dgvNomina.Name = "dgvNomina";
            this.dgvNomina.ReadOnly = true;
            this.dgvNomina.Size = new System.Drawing.Size(760, 350);
            this.dgvNomina.TabIndex = 0;

            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(12, 15);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(120, 16);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Total Usuarios: 0";

            // 
            // NominaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.dgvNomina);
            this.Name = "NominaForm";
            this.Text = "Nómina - Usuarios";
            this.Load += new System.EventHandler(this.NominaForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}