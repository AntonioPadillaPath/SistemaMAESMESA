namespace MAESMESA
{
    partial class Cotizaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cotizaciones));
            this.txtAtiendeC = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateFechaC = new System.Windows.Forms.DateTimePicker();
            this.txtRFCC = new System.Windows.Forms.TextBox();
            this.txtEmailC = new System.Windows.Forms.TextBox();
            this.txtTelC = new System.Windows.Forms.TextBox();
            this.txtPostalC = new System.Windows.Forms.TextBox();
            this.txtEstadoC = new System.Windows.Forms.TextBox();
            this.txtCiudadC = new System.Windows.Forms.TextBox();
            this.txtDireccionC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreC = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarCliente = new System.Windows.Forms.Button();
            this.btnNuevaCotizacion = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dateRecordarC = new System.Windows.Forms.DateTimePicker();
            this.txtNumeroC = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buscarCotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escribeElNúmeroDeCotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSTBuscarCot = new System.Windows.Forms.ToolStripTextBox();
            this.btnTSBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBuscarProductoC = new System.Windows.Forms.Button();
            this.txtBuscarProductoC = new System.Windows.Forms.TextBox();
            this.btnCotizacion = new System.Windows.Forms.Button();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalC = new System.Windows.Forms.TextBox();
            this.txtIVAC = new System.Windows.Forms.TextBox();
            this.txtSubTotalC = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAtiendeC
            // 
            this.txtAtiendeC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAtiendeC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtAtiendeC.Location = new System.Drawing.Point(528, 173);
            this.txtAtiendeC.MaxLength = 100;
            this.txtAtiendeC.Name = "txtAtiendeC";
            this.txtAtiendeC.Size = new System.Drawing.Size(210, 23);
            this.txtAtiendeC.TabIndex = 23;
            this.txtAtiendeC.Text = "Atiende:";
            this.txtAtiendeC.TextChanged += new System.EventHandler(this.txtAtiendeC_TextChanged);
            this.txtAtiendeC.Enter += new System.EventHandler(this.txtAtiendeC_Enter);
            this.txtAtiendeC.Leave += new System.EventHandler(this.txtAtiendeC_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Helvetica LT Std Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(10, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "Fecha:";
            // 
            // dateFechaC
            // 
            this.dateFechaC.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFechaC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaC.Location = new System.Drawing.Point(66, 202);
            this.dateFechaC.Name = "dateFechaC";
            this.dateFechaC.Size = new System.Drawing.Size(189, 22);
            this.dateFechaC.TabIndex = 18;
            // 
            // txtRFCC
            // 
            this.txtRFCC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFCC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtRFCC.Location = new System.Drawing.Point(357, 173);
            this.txtRFCC.MaxLength = 13;
            this.txtRFCC.Name = "txtRFCC";
            this.txtRFCC.Size = new System.Drawing.Size(165, 23);
            this.txtRFCC.TabIndex = 17;
            this.txtRFCC.Text = "RFC:";
            this.txtRFCC.Enter += new System.EventHandler(this.txtRFCC_Enter);
            this.txtRFCC.Leave += new System.EventHandler(this.txtRFCC_Leave);
            // 
            // txtEmailC
            // 
            this.txtEmailC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtEmailC.Location = new System.Drawing.Point(13, 173);
            this.txtEmailC.MaxLength = 100;
            this.txtEmailC.Name = "txtEmailC";
            this.txtEmailC.Size = new System.Drawing.Size(337, 23);
            this.txtEmailC.TabIndex = 15;
            this.txtEmailC.Text = "e-Mail:";
            this.txtEmailC.Enter += new System.EventHandler(this.txtEmailC_Enter);
            this.txtEmailC.Leave += new System.EventHandler(this.txtEmailC_Leave);
            // 
            // txtTelC
            // 
            this.txtTelC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtTelC.Location = new System.Drawing.Point(528, 144);
            this.txtTelC.MaxLength = 200;
            this.txtTelC.Name = "txtTelC";
            this.txtTelC.Size = new System.Drawing.Size(210, 23);
            this.txtTelC.TabIndex = 13;
            this.txtTelC.Text = "Teléfono(s):";
            this.txtTelC.Enter += new System.EventHandler(this.txtTelC_Enter);
            this.txtTelC.Leave += new System.EventHandler(this.txtTelC_Leave);
            // 
            // txtPostalC
            // 
            this.txtPostalC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostalC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtPostalC.Location = new System.Drawing.Point(13, 144);
            this.txtPostalC.MaxLength = 5;
            this.txtPostalC.Name = "txtPostalC";
            this.txtPostalC.Size = new System.Drawing.Size(165, 23);
            this.txtPostalC.TabIndex = 11;
            this.txtPostalC.Text = "Código Postal:";
            this.txtPostalC.Enter += new System.EventHandler(this.txtPostalC_Enter);
            this.txtPostalC.Leave += new System.EventHandler(this.txtPostalC_Leave);
            // 
            // txtEstadoC
            // 
            this.txtEstadoC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtEstadoC.Location = new System.Drawing.Point(357, 144);
            this.txtEstadoC.MaxLength = 50;
            this.txtEstadoC.Name = "txtEstadoC";
            this.txtEstadoC.Size = new System.Drawing.Size(165, 23);
            this.txtEstadoC.TabIndex = 9;
            this.txtEstadoC.Text = "Estado:";
            this.txtEstadoC.Enter += new System.EventHandler(this.txtEstadoC_Enter);
            this.txtEstadoC.Leave += new System.EventHandler(this.txtEstadoC_Leave);
            // 
            // txtCiudadC
            // 
            this.txtCiudadC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudadC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtCiudadC.Location = new System.Drawing.Point(185, 144);
            this.txtCiudadC.MaxLength = 50;
            this.txtCiudadC.Name = "txtCiudadC";
            this.txtCiudadC.Size = new System.Drawing.Size(165, 23);
            this.txtCiudadC.TabIndex = 7;
            this.txtCiudadC.Text = "Ciudad:";
            this.txtCiudadC.Enter += new System.EventHandler(this.txtCiudadC_Enter);
            this.txtCiudadC.Leave += new System.EventHandler(this.txtCiudadC_Leave);
            // 
            // txtDireccionC
            // 
            this.txtDireccionC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtDireccionC.Location = new System.Drawing.Point(13, 115);
            this.txtDireccionC.MaxLength = 200;
            this.txtDireccionC.Name = "txtDireccionC";
            this.txtDireccionC.Size = new System.Drawing.Size(725, 23);
            this.txtDireccionC.TabIndex = 5;
            this.txtDireccionC.Text = "Dirección:";
            this.txtDireccionC.Enter += new System.EventHandler(this.txtDireccionC_Enter);
            this.txtDireccionC.Leave += new System.EventHandler(this.txtDireccionC_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Helvetica LT Std Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(383, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Cotización:";
            // 
            // txtNombreC
            // 
            this.txtNombreC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtNombreC.Location = new System.Drawing.Point(13, 87);
            this.txtNombreC.MaxLength = 100;
            this.txtNombreC.Name = "txtNombreC";
            this.txtNombreC.Size = new System.Drawing.Size(512, 23);
            this.txtNombreC.TabIndex = 1;
            this.txtNombreC.Text = "Nombre:";
            this.txtNombreC.Enter += new System.EventHandler(this.txtNombreC_Enter);
            this.txtNombreC.Leave += new System.EventHandler(this.txtNombreC_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(85)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnSeleccionarCliente);
            this.panel1.Controls.Add(this.btnNuevaCotizacion);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dateRecordarC);
            this.panel1.Controls.Add(this.txtAtiendeC);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dateFechaC);
            this.panel1.Controls.Add(this.txtRFCC);
            this.panel1.Controls.Add(this.txtEmailC);
            this.panel1.Controls.Add(this.txtTelC);
            this.panel1.Controls.Add(this.txtPostalC);
            this.panel1.Controls.Add(this.txtEstadoC);
            this.panel1.Controls.Add(this.txtCiudadC);
            this.panel1.Controls.Add(this.txtDireccionC);
            this.panel1.Controls.Add(this.txtNumeroC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNombreC);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 232);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Helvetica LT Std Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(550, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 26);
            this.label6.TabIndex = 50;
            this.label6.Text = "COTIZACIONES";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::MAESMESA.Properties.Resources.min;
            this.pictureBox3.Location = new System.Drawing.Point(700, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 49;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MAESMESA.Properties.Resources.cerrar;
            this.pictureBox2.Location = new System.Drawing.Point(725, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnSeleccionarCliente.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnSeleccionarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnSeleccionarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarCliente.Font = new System.Drawing.Font("Helvetica LT Std Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarCliente.ForeColor = System.Drawing.Color.Cyan;
            this.btnSeleccionarCliente.Location = new System.Drawing.Point(531, 85);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Size = new System.Drawing.Size(207, 26);
            this.btnSeleccionarCliente.TabIndex = 47;
            this.btnSeleccionarCliente.Text = "Seleccionar Cliente";
            this.btnSeleccionarCliente.UseVisualStyleBackColor = false;
            this.btnSeleccionarCliente.Click += new System.EventHandler(this.btnSeleccionarCliente_Click);
            // 
            // btnNuevaCotizacion
            // 
            this.btnNuevaCotizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnNuevaCotizacion.FlatAppearance.BorderSize = 0;
            this.btnNuevaCotizacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnNuevaCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnNuevaCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCotizacion.Font = new System.Drawing.Font("Helvetica LT Std Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaCotizacion.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCotizacion.Location = new System.Drawing.Point(13, 53);
            this.btnNuevaCotizacion.Name = "btnNuevaCotizacion";
            this.btnNuevaCotizacion.Size = new System.Drawing.Size(285, 26);
            this.btnNuevaCotizacion.TabIndex = 40;
            this.btnNuevaCotizacion.Text = "Nueva Cotización";
            this.btnNuevaCotizacion.UseVisualStyleBackColor = false;
            this.btnNuevaCotizacion.Click += new System.EventHandler(this.btnNuevaCotizacion_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Helvetica LT Std Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(444, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 19);
            this.label11.TabIndex = 25;
            this.label11.Text = "Recodar para:";
            // 
            // dateRecordarC
            // 
            this.dateRecordarC.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRecordarC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateRecordarC.Location = new System.Drawing.Point(553, 201);
            this.dateRecordarC.Name = "dateRecordarC";
            this.dateRecordarC.Size = new System.Drawing.Size(185, 22);
            this.dateRecordarC.TabIndex = 24;
            // 
            // txtNumeroC
            // 
            this.txtNumeroC.BackColor = System.Drawing.Color.Yellow;
            this.txtNumeroC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroC.ForeColor = System.Drawing.Color.Red;
            this.txtNumeroC.Location = new System.Drawing.Point(386, 56);
            this.txtNumeroC.Name = "txtNumeroC";
            this.txtNumeroC.ReadOnly = true;
            this.txtNumeroC.Size = new System.Drawing.Size(138, 23);
            this.txtNumeroC.TabIndex = 3;
            this.txtNumeroC.TextChanged += new System.EventHandler(this.NoConInicial);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarCotizaciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(134, 25);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buscarCotizaciónToolStripMenuItem
            // 
            this.buscarCotizaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escribeElNúmeroDeCotizaciónToolStripMenuItem,
            this.tSTBuscarCot,
            this.btnTSBuscar});
            this.buscarCotizaciónToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarCotizaciónToolStripMenuItem.Name = "buscarCotizaciónToolStripMenuItem";
            this.buscarCotizaciónToolStripMenuItem.Size = new System.Drawing.Size(126, 21);
            this.buscarCotizaciónToolStripMenuItem.Text = "Buscar Cotización";
            // 
            // escribeElNúmeroDeCotizaciónToolStripMenuItem
            // 
            this.escribeElNúmeroDeCotizaciónToolStripMenuItem.Name = "escribeElNúmeroDeCotizaciónToolStripMenuItem";
            this.escribeElNúmeroDeCotizaciónToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.escribeElNúmeroDeCotizaciónToolStripMenuItem.Text = "Escribe el número de Cotización";
            // 
            // tSTBuscarCot
            // 
            this.tSTBuscarCot.BackColor = System.Drawing.Color.Yellow;
            this.tSTBuscarCot.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSTBuscarCot.ForeColor = System.Drawing.Color.Red;
            this.tSTBuscarCot.Name = "tSTBuscarCot";
            this.tSTBuscarCot.Size = new System.Drawing.Size(200, 23);
            // 
            // btnTSBuscar
            // 
            this.btnTSBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnTSBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnTSBuscar.ForeColor = System.Drawing.Color.Yellow;
            this.btnTSBuscar.Name = "btnTSBuscar";
            this.btnTSBuscar.Size = new System.Drawing.Size(266, 22);
            this.btnTSBuscar.Text = "Buscar";
            this.btnTSBuscar.Click += new System.EventHandler(this.btnTSBuscar_Click);
            // 
            // btnBuscarProductoC
            // 
            this.btnBuscarProductoC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnBuscarProductoC.FlatAppearance.BorderSize = 0;
            this.btnBuscarProductoC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnBuscarProductoC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnBuscarProductoC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProductoC.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProductoC.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProductoC.Location = new System.Drawing.Point(187, 242);
            this.btnBuscarProductoC.Name = "btnBuscarProductoC";
            this.btnBuscarProductoC.Size = new System.Drawing.Size(111, 23);
            this.btnBuscarProductoC.TabIndex = 46;
            this.btnBuscarProductoC.Text = "Agregar";
            this.btnBuscarProductoC.UseVisualStyleBackColor = false;
            this.btnBuscarProductoC.Click += new System.EventHandler(this.btnBuscarProductoC_Click);
            // 
            // txtBuscarProductoC
            // 
            this.txtBuscarProductoC.AutoCompleteCustomSource.AddRange(new string[] {
            "PA-0001",
            "PA-0002",
            "PA-0003",
            "PA-0004",
            "PA-0005",
            "PA-0006",
            "PA-0007",
            "PA-0008",
            "PA-MINI",
            "PM-0001",
            "PM-0002",
            "PM-0003",
            "PP-0001",
            "PP-0002",
            "RAY-001",
            "RAY-003",
            "RPC-01",
            "CO-0001",
            "CO-0002",
            "CO-0005",
            "CAL-01",
            "BAT-003",
            "BTE-050",
            "BTE-100",
            "BTE-250",
            "BTE-500",
            "COP-01",
            "DA-001",
            "DP-0001",
            "DP-0002",
            "DP-0003",
            "ESP-001",
            "ESP-002",
            "GAR-01",
            "GAR-02",
            "GAR-03",
            "JAR-0001",
            "LLAA-02",
            "LLAS-01",
            "LLP-0001",
            "BAT-002",
            "JAR-KIT",
            "JAR-SET",
            "FIL-001TE",
            "FIL-001NE",
            "FIL-004TE",
            "FIL-004NE",
            "FIL-019TE",
            "FIL-019NE",
            "FIL-200TE",
            "FIL-200NE",
            "PLL-001E"});
            this.txtBuscarProductoC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscarProductoC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarProductoC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProductoC.ForeColor = System.Drawing.Color.SlateGray;
            this.txtBuscarProductoC.Location = new System.Drawing.Point(23, 242);
            this.txtBuscarProductoC.Name = "txtBuscarProductoC";
            this.txtBuscarProductoC.Size = new System.Drawing.Size(165, 23);
            this.txtBuscarProductoC.TabIndex = 44;
            this.txtBuscarProductoC.Text = "Buscar Código...";
            this.txtBuscarProductoC.Enter += new System.EventHandler(this.txtBuscarProductoC_Enter);
            this.txtBuscarProductoC.Leave += new System.EventHandler(this.txtBuscarProductoC_Leave);
            // 
            // btnCotizacion
            // 
            this.btnCotizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnCotizacion.FlatAppearance.BorderSize = 0;
            this.btnCotizacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCotizacion.Font = new System.Drawing.Font("Helvetica LT Std Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCotizacion.ForeColor = System.Drawing.Color.Yellow;
            this.btnCotizacion.Location = new System.Drawing.Point(441, 240);
            this.btnCotizacion.Name = "btnCotizacion";
            this.btnCotizacion.Size = new System.Drawing.Size(285, 26);
            this.btnCotizacion.TabIndex = 38;
            this.btnCotizacion.Text = "Realizar cálculo de la Cotización";
            this.btnCotizacion.UseVisualStyleBackColor = false;
            this.btnCotizacion.Click += new System.EventHandler(this.btnCotizacion_Click);
            // 
            // dgvPedido
            // 
            this.dgvPedido.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(85)))));
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new System.Drawing.Point(23, 269);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.Size = new System.Drawing.Size(703, 231);
            this.dgvPedido.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Helvetica LT Std Cond", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(571, 545);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 19);
            this.label15.TabIndex = 52;
            this.label15.Text = "TOTAL:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Helvetica LT Std Cond", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(592, 524);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 19);
            this.label14.TabIndex = 51;
            this.label14.Text = "IVA:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Helvetica LT Std Cond", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(551, 503);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 19);
            this.label13.TabIndex = 50;
            this.label13.Text = "Sub-Total:";
            // 
            // txtTotalC
            // 
            this.txtTotalC.BackColor = System.Drawing.Color.Yellow;
            this.txtTotalC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalC.Location = new System.Drawing.Point(626, 541);
            this.txtTotalC.Name = "txtTotalC";
            this.txtTotalC.ReadOnly = true;
            this.txtTotalC.Size = new System.Drawing.Size(100, 23);
            this.txtTotalC.TabIndex = 49;
            // 
            // txtIVAC
            // 
            this.txtIVAC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtIVAC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVAC.Location = new System.Drawing.Point(626, 520);
            this.txtIVAC.Name = "txtIVAC";
            this.txtIVAC.ReadOnly = true;
            this.txtIVAC.Size = new System.Drawing.Size(100, 23);
            this.txtIVAC.TabIndex = 48;
            // 
            // txtSubTotalC
            // 
            this.txtSubTotalC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSubTotalC.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotalC.Location = new System.Drawing.Point(626, 499);
            this.txtSubTotalC.Name = "txtSubTotalC";
            this.txtSubTotalC.ReadOnly = true;
            this.txtSubTotalC.Size = new System.Drawing.Size(100, 23);
            this.txtSubTotalC.TabIndex = 47;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Helvetica LT Std Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.Yellow;
            this.btnEnviar.Location = new System.Drawing.Point(23, 538);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(285, 26);
            this.btnEnviar.TabIndex = 54;
            this.btnEnviar.Text = "ENVIAR COTIZACIÓN A PEDIDOS";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(79)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Helvetica LT Std Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Lime;
            this.btnGuardar.Location = new System.Drawing.Point(23, 506);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(285, 26);
            this.btnGuardar.TabIndex = 53;
            this.btnGuardar.Text = "GUARDAR COTIZACIÓN";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MAESMESA.Properties.Resources.MAESMESA;
            this.pictureBox1.Location = new System.Drawing.Point(330, 518);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // Cotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MAESMESA.Properties.Resources.WhiteWall;
            this.ClientSize = new System.Drawing.Size(750, 578);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTotalC);
            this.Controls.Add(this.txtIVAC);
            this.Controls.Add(this.txtSubTotalC);
            this.Controls.Add(this.dgvPedido);
            this.Controls.Add(this.btnBuscarProductoC);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBuscarProductoC);
            this.Controls.Add(this.btnCotizacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Cotizaciones";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cotizaciones";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cotizaciones_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAtiendeC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateFechaC;
        private System.Windows.Forms.TextBox txtRFCC;
        private System.Windows.Forms.TextBox txtEmailC;
        private System.Windows.Forms.TextBox txtTelC;
        private System.Windows.Forms.TextBox txtPostalC;
        private System.Windows.Forms.TextBox txtEstadoC;
        private System.Windows.Forms.TextBox txtCiudadC;
        private System.Windows.Forms.TextBox txtDireccionC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateRecordarC;
        private System.Windows.Forms.Button btnCotizacion;
        private System.Windows.Forms.Button btnNuevaCotizacion;
        private System.Windows.Forms.TextBox txtNumeroC;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buscarCotizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escribeElNúmeroDeCotizaciónToolStripMenuItem;
        private System.Windows.Forms.Button btnBuscarProductoC;
        private System.Windows.Forms.TextBox txtBuscarProductoC;
        private System.Windows.Forms.ToolStripTextBox tSTBuscarCot;
        private System.Windows.Forms.Button btnSeleccionarCliente;
        private System.Windows.Forms.ToolStripMenuItem btnTSBuscar;
        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTotalC;
        private System.Windows.Forms.TextBox txtIVAC;
        private System.Windows.Forms.TextBox txtSubTotalC;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}