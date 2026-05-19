namespace Repuesto1.FormsInformacion
{
    partial class DetalleNominaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelNomina = new Panel();
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombreEmpleado = new TextBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblRol = new Label();
            txtRol = new TextBox();
            lblFecha = new Label();
            txtFecha = new TextBox();
            lblDias = new Label();
            txtDiasTrabajados = new TextBox();
            grpDevengado = new GroupBox();
            lblSalarioBase = new Label();
            txtSalarioBase = new TextBox();
            lblTotalDev = new Label();
            txtTotalDevengado = new TextBox();
            grpDeducciones = new GroupBox();
            lblAFP = new Label();
            txtAFP = new TextBox();
            lblSFS = new Label();
            txtSFS = new TextBox();
            lblTotalDed = new Label();
            txtTotalDeducciones = new TextBox();
            lblNeto = new Label();
            txtNeto = new TextBox();
            btnImprimir = new Button();
            panelNomina.SuspendLayout();
            grpDevengado.SuspendLayout();
            grpDeducciones.SuspendLayout();
            SuspendLayout();
            // 
            // panelNomina
            // 
            panelNomina.BackColor = Color.White;
            panelNomina.BorderStyle = BorderStyle.FixedSingle;
            panelNomina.Controls.Add(lblTitulo);
            panelNomina.Controls.Add(lblNombre);
            panelNomina.Controls.Add(txtNombreEmpleado);
            panelNomina.Controls.Add(lblUsuario);
            panelNomina.Controls.Add(txtUsuario);
            panelNomina.Controls.Add(lblRol);
            panelNomina.Controls.Add(txtRol);
            panelNomina.Controls.Add(lblFecha);
            panelNomina.Controls.Add(txtFecha);
            panelNomina.Controls.Add(lblDias);
            panelNomina.Controls.Add(txtDiasTrabajados);
            panelNomina.Controls.Add(grpDevengado);
            panelNomina.Controls.Add(grpDeducciones);
            panelNomina.Controls.Add(lblNeto);
            panelNomina.Controls.Add(txtNeto);
            panelNomina.Location = new Point(12, 12);
            panelNomina.Name = "panelNomina";
            panelNomina.Size = new Size(860, 620);
            panelNomina.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(800, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "RECIBO DE NÓMINA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombreEmpleado
            // 
            txtNombreEmpleado.Location = new Point(150, 77);
            txtNombreEmpleado.Name = "txtNombreEmpleado";
            txtNombreEmpleado.ReadOnly = true;
            txtNombreEmpleado.Size = new Size(300, 23);
            txtNombreEmpleado.TabIndex = 2;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(20, 115);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(150, 112);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.ReadOnly = true;
            txtUsuario.Size = new Size(300, 23);
            txtUsuario.TabIndex = 4;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(20, 150);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(27, 15);
            lblRol.TabIndex = 5;
            lblRol.Text = "Rol:";
            // 
            // txtRol
            // 
            txtRol.Location = new Point(150, 147);
            txtRol.Name = "txtRol";
            txtRol.ReadOnly = true;
            txtRol.Size = new Size(300, 23);
            txtRol.TabIndex = 6;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(500, 80);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 7;
            lblFecha.Text = "Fecha:";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(620, 77);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(180, 23);
            txtFecha.TabIndex = 8;
            // 
            // lblDias
            // 
            lblDias.AutoSize = true;
            lblDias.Location = new Point(500, 115);
            lblDias.Name = "lblDias";
            lblDias.Size = new Size(90, 15);
            lblDias.TabIndex = 9;
            lblDias.Text = "Días trabajados:";
            // 
            // txtDiasTrabajados
            // 
            txtDiasTrabajados.Location = new Point(620, 112);
            txtDiasTrabajados.Name = "txtDiasTrabajados";
            txtDiasTrabajados.ReadOnly = true;
            txtDiasTrabajados.Size = new Size(180, 23);
            txtDiasTrabajados.TabIndex = 10;
            // 
            // grpDevengado
            // 
            grpDevengado.Controls.Add(lblSalarioBase);
            grpDevengado.Controls.Add(txtSalarioBase);
            grpDevengado.Controls.Add(lblTotalDev);
            grpDevengado.Controls.Add(txtTotalDevengado);
            grpDevengado.Font = new Font("Arial", 10F, FontStyle.Bold);
            grpDevengado.Location = new Point(20, 210);
            grpDevengado.Name = "grpDevengado";
            grpDevengado.Size = new Size(380, 150);
            grpDevengado.TabIndex = 10;
            grpDevengado.TabStop = false;
            grpDevengado.Text = "DEVENGADO";
            // 
            // lblSalarioBase
            // 
            lblSalarioBase.AutoSize = true;
            lblSalarioBase.Font = new Font("Arial", 9F);
            lblSalarioBase.Location = new Point(20, 35);
            lblSalarioBase.Name = "lblSalarioBase";
            lblSalarioBase.Size = new Size(81, 15);
            lblSalarioBase.TabIndex = 0;
            lblSalarioBase.Text = "Salario Base:";
            // 
            // txtSalarioBase
            // 
            txtSalarioBase.Location = new Point(150, 32);
            txtSalarioBase.Name = "txtSalarioBase";
            txtSalarioBase.ReadOnly = true;
            txtSalarioBase.Size = new Size(180, 23);
            txtSalarioBase.TabIndex = 1;
            // 
            // lblTotalDev
            // 
            lblTotalDev.AutoSize = true;
            lblTotalDev.Font = new Font("Arial", 9F);
            lblTotalDev.Location = new Point(20, 75);
            lblTotalDev.Name = "lblTotalDev";
            lblTotalDev.Size = new Size(102, 15);
            lblTotalDev.TabIndex = 2;
            lblTotalDev.Text = "Total Devengado:";
            // 
            // txtTotalDevengado
            // 
            txtTotalDevengado.Location = new Point(150, 72);
            txtTotalDevengado.Name = "txtTotalDevengado";
            txtTotalDevengado.ReadOnly = true;
            txtTotalDevengado.Size = new Size(180, 23);
            txtTotalDevengado.TabIndex = 3;
            // 
            // grpDeducciones
            // 
            grpDeducciones.Controls.Add(lblAFP);
            grpDeducciones.Controls.Add(txtAFP);
            grpDeducciones.Controls.Add(lblSFS);
            grpDeducciones.Controls.Add(txtSFS);
            grpDeducciones.Controls.Add(lblTotalDed);
            grpDeducciones.Controls.Add(txtTotalDeducciones);
            grpDeducciones.Font = new Font("Arial", 10F, FontStyle.Bold);
            grpDeducciones.Location = new Point(430, 210);
            grpDeducciones.Name = "grpDeducciones";
            grpDeducciones.Size = new Size(390, 180);
            grpDeducciones.TabIndex = 11;
            grpDeducciones.TabStop = false;
            grpDeducciones.Text = "DEDUCCIONES";
            // 
            // lblAFP
            // 
            lblAFP.AutoSize = true;
            lblAFP.Font = new Font("Arial", 9F);
            lblAFP.Location = new Point(20, 35);
            lblAFP.Name = "lblAFP";
            lblAFP.Size = new Size(78, 15);
            lblAFP.TabIndex = 0;
            lblAFP.Text = "AFP (2.87%):";
            // 
            // txtAFP
            // 
            txtAFP.Location = new Point(180, 32);
            txtAFP.Name = "txtAFP";
            txtAFP.ReadOnly = true;
            txtAFP.Size = new Size(180, 23);
            txtAFP.TabIndex = 1;
            // 
            // lblSFS
            // 
            lblSFS.AutoSize = true;
            lblSFS.Font = new Font("Arial", 9F);
            lblSFS.Location = new Point(20, 75);
            lblSFS.Name = "lblSFS";
            lblSFS.Size = new Size(79, 15);
            lblSFS.TabIndex = 2;
            lblSFS.Text = "SFS (3.04%):";
            // 
            // txtSFS
            // 
            txtSFS.Location = new Point(180, 72);
            txtSFS.Name = "txtSFS";
            txtSFS.ReadOnly = true;
            txtSFS.Size = new Size(180, 23);
            txtSFS.TabIndex = 3;
            // 
            // lblTotalDed
            // 
            lblTotalDed.AutoSize = true;
            lblTotalDed.Font = new Font("Arial", 9F);
            lblTotalDed.Location = new Point(20, 115);
            lblTotalDed.Name = "lblTotalDed";
            lblTotalDed.Size = new Size(112, 15);
            lblTotalDed.TabIndex = 4;
            lblTotalDed.Text = "Total Deducciones:";
            // 
            // txtTotalDeducciones
            // 
            txtTotalDeducciones.Location = new Point(180, 112);
            txtTotalDeducciones.Name = "txtTotalDeducciones";
            txtTotalDeducciones.ReadOnly = true;
            txtTotalDeducciones.Size = new Size(180, 23);
            txtTotalDeducciones.TabIndex = 5;
            // 
            // lblNeto
            // 
            lblNeto.AutoSize = true;
            lblNeto.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblNeto.Location = new Point(20, 450);
            lblNeto.Name = "lblNeto";
            lblNeto.Size = new Size(149, 19);
            lblNeto.TabIndex = 12;
            lblNeto.Text = "Líquido a Percibir:";
            // 
            // txtNeto
            // 
            txtNeto.Font = new Font("Arial", 12F, FontStyle.Bold);
            txtNeto.Location = new Point(220, 446);
            txtNeto.Name = "txtNeto";
            txtNeto.ReadOnly = true;
            txtNeto.Size = new Size(200, 26);
            txtNeto.TabIndex = 13;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.IndianRed;
            btnImprimir.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.Location = new Point(747, 640);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(125, 35);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // DetalleNominaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(884, 691);
            Controls.Add(btnImprimir);
            Controls.Add(panelNomina);
            Name = "DetalleNominaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Nómina";
            panelNomina.ResumeLayout(false);
            panelNomina.PerformLayout();
            grpDevengado.ResumeLayout(false);
            grpDevengado.PerformLayout();
            grpDeducciones.ResumeLayout(false);
            grpDeducciones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelNomina;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreEmpleado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.TextBox txtDiasTrabajados;
        private System.Windows.Forms.GroupBox grpDevengado;
        private System.Windows.Forms.Label lblSalarioBase;
        private System.Windows.Forms.TextBox txtSalarioBase;
        private System.Windows.Forms.Label lblTotalDev;
        private System.Windows.Forms.TextBox txtTotalDevengado;
        private System.Windows.Forms.GroupBox grpDeducciones;
        private System.Windows.Forms.Label lblAFP;
        private System.Windows.Forms.TextBox txtAFP;
        private System.Windows.Forms.Label lblSFS;
        private System.Windows.Forms.TextBox txtSFS;
        private System.Windows.Forms.Label lblTotalDed;
        private System.Windows.Forms.TextBox txtTotalDeducciones;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.TextBox txtNeto;
        private System.Windows.Forms.Button btnImprimir;
    }
}