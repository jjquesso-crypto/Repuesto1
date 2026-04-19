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
            btnAgregar = new Button() { Text = "Agregar Ingreso", Location = new System.Drawing.Point(12, 420), Size = new System.Drawing.Size(120, 35) };
            lblInfo = new Label() { Location = new System.Drawing.Point(12, 470), Size = new System.Drawing.Size(400, 25) };

            dgvIngresos.Location = new System.Drawing.Point(12, 12);
            dgvIngresos.Size = new System.Drawing.Size(760, 400);
            dgvIngresos.ReadOnly = true;
            dgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Controls.Add(dgvIngresos);
            Controls.Add(btnAgregar);
            Controls.Add(lblInfo);

            Size = new System.Drawing.Size(800, 520);
            Text = "Ingresos";
            StartPosition = FormStartPosition.CenterScreen;

            btnAgregar.Click += btnAgregar_Click;
        }
    }
}