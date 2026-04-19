namespace Repuesto1
{
    partial class GestionarProveedorForm
    {
        private DataGridView dgvProveedores;
        private Button btnAgregar, btnInactivar;
        private Label lblInfo;

        private void InitializeComponent()
        {
            dgvProveedores = new DataGridView();
            btnAgregar = new Button();
            btnInactivar = new Button();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // dgvProveedores
            // 
            dgvProveedores.Location = new Point(12, 12);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(760, 400);
            dgvProveedores.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 418);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnInactivar
            // 
            btnInactivar.Location = new Point(109, 418);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(75, 23);
            btnInactivar.TabIndex = 2;
            btnInactivar.Text = "Inactivo";
            btnInactivar.Click += btnInactivar_Click;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(100, 23);
            lblInfo.TabIndex = 3;
            // 
            // GestionarProveedorForm
            // 
            ClientSize = new Size(784, 481);
            Controls.Add(dgvProveedores);
            Controls.Add(btnAgregar);
            Controls.Add(btnInactivar);
            Controls.Add(lblInfo);
            Name = "GestionarProveedorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
        }
    }
}