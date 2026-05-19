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
            button1 = new Button();
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(224, 224, 224);
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(628, 4);
            button1.Name = "button1";
            button1.Size = new Size(144, 40);
            button1.TabIndex = 2;
            button1.Text = "Detalles";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // NominaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(button1);
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

        private Button button1;
    }
}