namespace Repuesto1
{
    partial class GestionarFacturasForm
    {
        private DataGridView dgvFacturas;
        private Button btnAgregar;
        private Label lblInfo;

        private void InitializeComponent()
        {
            dgvFacturas = new DataGridView() { Location = new System.Drawing.Point(12, 12), Size = new System.Drawing.Size(760, 400) };
            btnAgregar = new Button() { Text = "Vender", Location = new System.Drawing.Point(12, 420), Size = new System.Drawing.Size(100, 35) };
            lblInfo = new Label() { Location = new System.Drawing.Point(12, 470), Size = new System.Drawing.Size(400, 25) };

            Controls.Add(dgvFacturas);
            Controls.Add(btnAgregar);
            Controls.Add(lblInfo);

            Size = new System.Drawing.Size(800, 520);
            Text = "Facturas";
            StartPosition = FormStartPosition.CenterScreen;

            btnAgregar.Click += btnAgregar_Click;
        }
    }
}