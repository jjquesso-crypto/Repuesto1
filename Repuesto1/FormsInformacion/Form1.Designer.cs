namespace Repuesto1
{

    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            cajaToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            nominaToolStripMenuItem = new ToolStripMenuItem();
            configuracionToolStripMenuItem = new ToolStripMenuItem();
            mantenimientoToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            toolStrip1 = new ToolStrip();
            toolStripFacturas = new ToolStripButton();
            toolStripCompras = new ToolStripButton();
            Producto = new ToolStripButton();
            toolStripProveedores = new ToolStripButton();
            toolStripIngresos = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cajaToolStripMenuItem, ventasToolStripMenuItem, nominaToolStripMenuItem, configuracionToolStripMenuItem, mantenimientoToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(0);
            menuStrip1.Size = new Size(911, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cajaToolStripMenuItem
            // 
            cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            cajaToolStripMenuItem.Size = new Size(40, 24);
            cajaToolStripMenuItem.Text = "Caja";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(52, 24);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // nominaToolStripMenuItem
            // 
            nominaToolStripMenuItem.Name = "nominaToolStripMenuItem";
            nominaToolStripMenuItem.Size = new Size(57, 24);
            nominaToolStripMenuItem.Text = "Nomina";
            // 
            // configuracionToolStripMenuItem
            // 
            configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            configuracionToolStripMenuItem.Size = new Size(88, 24);
            configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // mantenimientoToolStripMenuItem
            // 
            mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            mantenimientoToolStripMenuItem.Size = new Size(97, 24);
            mantenimientoToolStripMenuItem.Text = "Mantenimientos";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(50, 24);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(911, 429);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(317, 27);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.BackgroundImageLayout = ImageLayout.None;
            toolStrip1.Font = new Font("Segoe UI", 7F);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(30, 30);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripFacturas, toolStripCompras, Producto, toolStripProveedores, toolStripIngresos, toolStripButton1 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(911, 49);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripFacturas
            // 
            toolStripFacturas.Image = (Image)resources.GetObject("toolStripFacturas.Image");
            toolStripFacturas.ImageTransparentColor = Color.Magenta;
            toolStripFacturas.Name = "toolStripFacturas";
            toolStripFacturas.Size = new Size(45, 46);
            toolStripFacturas.Text = "Facturas";
            toolStripFacturas.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripFacturas.Click += toolStripFacturas_Click;
            // 
            // toolStripCompras
            // 
            toolStripCompras.Image = (Image)resources.GetObject("toolStripCompras.Image");
            toolStripCompras.ImageTransparentColor = Color.Magenta;
            toolStripCompras.Name = "toolStripCompras";
            toolStripCompras.Size = new Size(48, 46);
            toolStripCompras.Text = "Compras";
            toolStripCompras.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripCompras.Click += toolStripCompras_Click;
            // 
            // Producto
            // 
            Producto.Image = (Image)resources.GetObject("Producto.Image");
            Producto.ImageTransparentColor = Color.Magenta;
            Producto.Name = "Producto";
            Producto.Size = new Size(54, 46);
            Producto.Text = "Productos";
            Producto.TextImageRelation = TextImageRelation.ImageAboveText;
            Producto.Click += Producto_Click;
            // 
            // toolStripProveedores
            // 
            toolStripProveedores.Image = (Image)resources.GetObject("toolStripProveedores.Image");
            toolStripProveedores.ImageTransparentColor = Color.Magenta;
            toolStripProveedores.Name = "toolStripProveedores";
            toolStripProveedores.Size = new Size(63, 46);
            toolStripProveedores.Text = "Proveedores";
            toolStripProveedores.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripProveedores.Click += toolStripButton5_Click;
            // 
            // toolStripIngresos
            // 
            toolStripIngresos.Image = (Image)resources.GetObject("toolStripIngresos.Image");
            toolStripIngresos.ImageTransparentColor = Color.Magenta;
            toolStripIngresos.Name = "toolStripIngresos";
            toolStripIngresos.Size = new Size(46, 46);
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
            toolStripButton1.Size = new Size(34, 47);
            toolStripButton1.Text = "Salir";
            toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.DisabledLinkColor = Color.Transparent;
            linkLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            linkLabel1.ForeColor = SystemColors.ActiveCaptionText;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(747, 226);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(89, 17);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Iniciar sesion";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.DisabledLinkColor = Color.Transparent;
            linkLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            linkLabel2.ForeColor = SystemColors.ActiveCaptionText;
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(747, 269);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(88, 17);
            linkLabel2.TabIndex = 6;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Cerrar sesion";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.DisabledLinkColor = Color.Transparent;
            linkLabel3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            linkLabel3.ForeColor = SystemColors.ActiveCaptionText;
            linkLabel3.LinkBehavior = LinkBehavior.AlwaysUnderline;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(747, 310);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(129, 17);
            linkLabel3.TabIndex = 7;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Cambiar de Usuario";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(911, 495);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel1);
            Controls.Add(linkLabel2);
            Controls.Add(toolStrip1);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "MENU PRINCIPAL | COMPAÑÍA ACTIVA : SISFACON EXPRESS | EN PC #:1 | USUARIO: MARIA | CONEXIÓN: REMOTA, IP:SERVIDOR";
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
        private ToolStripMenuItem cajaToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem nominaToolStripMenuItem;
        private ToolStripMenuItem configuracionToolStripMenuItem;
        private ToolStripMenuItem mantenimientoToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton Producto;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private ToolStripButton toolStripFacturas;
        private ToolStripButton toolStripCompras;
        private ToolStripButton toolStripProveedores;
        private ToolStripButton toolStripIngresos;
    }
}
