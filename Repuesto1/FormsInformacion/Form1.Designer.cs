namespace Repuesto1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            cajaToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            nominaToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            toolStrip1 = new ToolStrip();
            toolStripFacturas = new ToolStripButton();
            toolStripCompras = new ToolStripButton();
            Producto = new ToolStripButton();
            toolStripProveedores = new ToolStripButton();
            toolStripIngresos = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            linkLabel3 = new LinkLabel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Bell MT", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cajaToolStripMenuItem, ventasToolStripMenuItem, nominaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(0);
            menuStrip1.Size = new Size(1370, 26);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cajaToolStripMenuItem
            // 
            cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            cajaToolStripMenuItem.Size = new Size(55, 26);
            cajaToolStripMenuItem.Text = "Caja";
            cajaToolStripMenuItem.Click += cajaToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(73, 26);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.Click += ventasToolStripMenuItem_Click;
            // 
            // nominaToolStripMenuItem
            // 
            nominaToolStripMenuItem.Name = "nominaToolStripMenuItem";
            nominaToolStripMenuItem.Size = new Size(82, 26);
            nominaToolStripMenuItem.Text = "Nomina";
            nominaToolStripMenuItem.Click += nominaToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-22, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1410, 639);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(500, 40);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(150, 28);
            progressBar1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.BackgroundImageLayout = ImageLayout.None;
            toolStrip1.Font = new Font("Segoe UI", 11F);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(48, 48);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripFacturas, toolStripCompras, Producto, toolStripProveedores, toolStripIngresos, toolStripButton1 });
            toolStrip1.Location = new Point(0, 26);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(1370, 75);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripFacturas
            // 
            toolStripFacturas.Image = (Image)resources.GetObject("toolStripFacturas.Image");
            toolStripFacturas.ImageTransparentColor = Color.Magenta;
            toolStripFacturas.Name = "toolStripFacturas";
            toolStripFacturas.Size = new Size(66, 72);
            toolStripFacturas.Text = "Facturas";
            toolStripFacturas.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripFacturas.Click += toolStripFacturas_Click;
            // 
            // toolStripCompras
            // 
            toolStripCompras.Image = (Image)resources.GetObject("toolStripCompras.Image");
            toolStripCompras.ImageTransparentColor = Color.Magenta;
            toolStripCompras.Name = "toolStripCompras";
            toolStripCompras.Size = new Size(72, 72);
            toolStripCompras.Text = "Compras";
            toolStripCompras.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripCompras.Click += toolStripCompras_Click;
            // 
            // Producto
            // 
            Producto.Image = (Image)resources.GetObject("Producto.Image");
            Producto.ImageTransparentColor = Color.Magenta;
            Producto.Name = "Producto";
            Producto.Size = new Size(79, 72);
            Producto.Text = "Productos";
            Producto.TextImageRelation = TextImageRelation.ImageAboveText;
            Producto.Click += Producto_Click;
            // 
            // toolStripProveedores
            // 
            toolStripProveedores.Image = (Image)resources.GetObject("toolStripProveedores.Image");
            toolStripProveedores.ImageTransparentColor = Color.Magenta;
            toolStripProveedores.Name = "toolStripProveedores";
            toolStripProveedores.Size = new Size(95, 72);
            toolStripProveedores.Text = "Proveedores";
            toolStripProveedores.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripProveedores.Click += toolStripButton5_Click;
            // 
            // toolStripIngresos
            // 
            toolStripIngresos.Image = (Image)resources.GetObject("toolStripIngresos.Image");
            toolStripIngresos.ImageTransparentColor = Color.Magenta;
            toolStripIngresos.Name = "toolStripIngresos";
            toolStripIngresos.Size = new Size(68, 72);
            toolStripIngresos.Text = "Ingresos";
            toolStripIngresos.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripIngresos.Click += toolStripIngresos_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Margin = new Padding(0, 1, 0, 1);
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(52, 73);
            toolStripButton1.Text = "Salir";
            toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton1.Click += toolStripButton1_Click_1;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.DisabledLinkColor = Color.Transparent;
            linkLabel3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            linkLabel3.ForeColor = SystemColors.ActiveCaptionText;
            linkLabel3.LinkBehavior = LinkBehavior.AlwaysUnderline;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(1112, 430);
            linkLabel3.Margin = new Padding(10, 0, 10, 0);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(239, 32);
            linkLabel3.TabIndex = 7;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Cambiar de Usuario";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Gray;
            ClientSize = new Size(1370, 702);
            Controls.Add(linkLabel3);
            Controls.Add(toolStrip1);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "MENU PRINCIPAL | COMPAÑÍA ACTIVA : SISFACON EXPRESS | EN PC #:1 | USUARIO: MARIA | CONEXIÓN: REMOTA, IP:SERVIDOR";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load_2;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem nominaToolStripMenuItem;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton3;
        private ToolStripButton Producto;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private LinkLabel linkLabel3;
        private ToolStripButton toolStripFacturas;
        private ToolStripButton toolStripCompras;
        private ToolStripButton toolStripProveedores;
        private ToolStripButton toolStripIngresos;
        private ToolStripMenuItem cajaToolStripMenuItem;
    }
}