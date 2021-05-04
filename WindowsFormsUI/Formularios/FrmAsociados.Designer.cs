
namespace WindowsFormsUI.Formularios
{
    partial class FrmAsociados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnAplicarFiltro = new System.Windows.Forms.Button();
            this.LLblQuitarFiltro = new System.Windows.Forms.LinkLabel();
            this.LblFilasMarcadas = new System.Windows.Forms.Label();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.CmbAcciones = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbTipoFiltro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LLblQuitarBusqueda = new System.Windows.Forms.LinkLabel();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnCrearNuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnMaximizar = new System.Windows.Forms.PictureBox();
            this.BtnCerrar = new System.Windows.Forms.PictureBox();
            this.PnlBarraSuperior = new System.Windows.Forms.Panel();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.Seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).BeginInit();
            this.PnlBarraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAplicarFiltro
            // 
            this.BtnAplicarFiltro.BackColor = System.Drawing.Color.White;
            this.BtnAplicarFiltro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnAplicarFiltro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnAplicarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAplicarFiltro.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAplicarFiltro.ForeColor = System.Drawing.Color.Black;
            this.BtnAplicarFiltro.Image = global::WindowsFormsUI.Properties.Resources.filter;
            this.BtnAplicarFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAplicarFiltro.Location = new System.Drawing.Point(1097, 122);
            this.BtnAplicarFiltro.Name = "BtnAplicarFiltro";
            this.BtnAplicarFiltro.Size = new System.Drawing.Size(129, 35);
            this.BtnAplicarFiltro.TabIndex = 28;
            this.BtnAplicarFiltro.Text = "Aplicar filtro";
            this.BtnAplicarFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAplicarFiltro.UseVisualStyleBackColor = false;
            this.BtnAplicarFiltro.Click += new System.EventHandler(this.BtnAplicarFiltro_Click);
            // 
            // LLblQuitarFiltro
            // 
            this.LLblQuitarFiltro.AutoSize = true;
            this.LLblQuitarFiltro.Enabled = false;
            this.LLblQuitarFiltro.Location = new System.Drawing.Point(540, 111);
            this.LLblQuitarFiltro.Name = "LLblQuitarFiltro";
            this.LLblQuitarFiltro.Size = new System.Drawing.Size(68, 15);
            this.LLblQuitarFiltro.TabIndex = 27;
            this.LLblQuitarFiltro.TabStop = true;
            this.LLblQuitarFiltro.Text = "Quitar filtro";
            this.LLblQuitarFiltro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLblQuitarFiltro_LinkClicked);
            // 
            // LblFilasMarcadas
            // 
            this.LblFilasMarcadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblFilasMarcadas.AutoSize = true;
            this.LblFilasMarcadas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblFilasMarcadas.Location = new System.Drawing.Point(12, 557);
            this.LblFilasMarcadas.Name = "LblFilasMarcadas";
            this.LblFilasMarcadas.Size = new System.Drawing.Size(121, 20);
            this.LblFilasMarcadas.TabIndex = 26;
            this.LblFilasMarcadas.Text = "Filas marcadas: 0";
            // 
            // CmbFiltro
            // 
            this.CmbFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltro.Enabled = false;
            this.CmbFiltro.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbFiltro.FormattingEnabled = true;
            this.CmbFiltro.ItemHeight = 20;
            this.CmbFiltro.Items.AddRange(new object[] {
            "-- Seleccionar filtro -- "});
            this.CmbFiltro.Location = new System.Drawing.Point(770, 129);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(321, 28);
            this.CmbFiltro.TabIndex = 25;
            // 
            // CmbAcciones
            // 
            this.CmbAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbAcciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAcciones.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbAcciones.FormattingEnabled = true;
            this.CmbAcciones.ItemHeight = 20;
            this.CmbAcciones.Items.AddRange(new object[] {
            "-- Seleccionar acción -- ",
            "Eliminar",
            "Imprimir"});
            this.CmbAcciones.Location = new System.Drawing.Point(1047, 554);
            this.CmbAcciones.Name = "CmbAcciones";
            this.CmbAcciones.Size = new System.Drawing.Size(179, 28);
            this.CmbAcciones.TabIndex = 24;
            this.CmbAcciones.SelectionChangeCommitted += new System.EventHandler(this.CmbAcciones_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(970, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Acciones:";
            // 
            // CmbTipoFiltro
            // 
            this.CmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoFiltro.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbTipoFiltro.FormattingEnabled = true;
            this.CmbTipoFiltro.ItemHeight = 20;
            this.CmbTipoFiltro.Items.AddRange(new object[] {
            "-- Seleccionar filtro -- ",
            "Genero",
            "Categoria"});
            this.CmbTipoFiltro.Location = new System.Drawing.Point(540, 129);
            this.CmbTipoFiltro.Name = "CmbTipoFiltro";
            this.CmbTipoFiltro.Size = new System.Drawing.Size(224, 28);
            this.CmbTipoFiltro.TabIndex = 22;
            this.CmbTipoFiltro.SelectionChangeCommitted += new System.EventHandler(this.CmbTipoFiltro_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(457, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Filtrar por:";
            // 
            // LLblQuitarBusqueda
            // 
            this.LLblQuitarBusqueda.AutoSize = true;
            this.LLblQuitarBusqueda.Enabled = false;
            this.LLblQuitarBusqueda.Location = new System.Drawing.Point(12, 104);
            this.LLblQuitarBusqueda.Name = "LLblQuitarBusqueda";
            this.LLblQuitarBusqueda.Size = new System.Drawing.Size(95, 15);
            this.LLblQuitarBusqueda.TabIndex = 20;
            this.LLblQuitarBusqueda.TabStop = true;
            this.LLblQuitarBusqueda.Text = "Quitar busqueda";
            this.LLblQuitarBusqueda.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLblQuitarBusqueda_LinkClicked);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.White;
            this.BtnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscar.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscar.Image = global::WindowsFormsUI.Properties.Resources.magnifying_glass;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(362, 122);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(89, 35);
            this.BtnBuscar.TabIndex = 19;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnCrearNuevo
            // 
            this.BtnCrearNuevo.BackColor = System.Drawing.Color.White;
            this.BtnCrearNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnCrearNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnCrearNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearNuevo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCrearNuevo.ForeColor = System.Drawing.Color.Black;
            this.BtnCrearNuevo.Image = global::WindowsFormsUI.Properties.Resources.add_friend;
            this.BtnCrearNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrearNuevo.Location = new System.Drawing.Point(12, 49);
            this.BtnCrearNuevo.Name = "BtnCrearNuevo";
            this.BtnCrearNuevo.Size = new System.Drawing.Size(126, 35);
            this.BtnCrearNuevo.TabIndex = 17;
            this.BtnCrearNuevo.Text = "Crear nuevo";
            this.BtnCrearNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCrearNuevo.UseVisualStyleBackColor = false;
            this.BtnCrearNuevo.Click += new System.EventHandler(this.BtnCrearNuevo_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Asociados";
            // 
            // BtnMaximizar
            // 
            this.BtnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMaximizar.Image = global::WindowsFormsUI.Properties.Resources.maximize;
            this.BtnMaximizar.Location = new System.Drawing.Point(1156, 3);
            this.BtnMaximizar.Name = "BtnMaximizar";
            this.BtnMaximizar.Size = new System.Drawing.Size(32, 32);
            this.BtnMaximizar.TabIndex = 4;
            this.BtnMaximizar.TabStop = false;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Image = global::WindowsFormsUI.Properties.Resources.x_button;
            this.BtnCerrar.Location = new System.Drawing.Point(1194, 3);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(32, 32);
            this.BtnCerrar.TabIndex = 3;
            this.BtnCerrar.TabStop = false;
            // 
            // PnlBarraSuperior
            // 
            this.PnlBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.PnlBarraSuperior.Controls.Add(this.label3);
            this.PnlBarraSuperior.Controls.Add(this.BtnMaximizar);
            this.PnlBarraSuperior.Controls.Add(this.BtnCerrar);
            this.PnlBarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlBarraSuperior.Name = "PnlBarraSuperior";
            this.PnlBarraSuperior.Size = new System.Drawing.Size(1238, 38);
            this.PnlBarraSuperior.TabIndex = 16;
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            this.DgvListado.AllowUserToDeleteRows = false;
            this.DgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DgvListado.BackgroundColor = System.Drawing.Color.White;
            this.DgvListado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvListado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.DgvListado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccion,
            this.Id,
            this.Nombre,
            this.Dui,
            this.Nit,
            this.Genero,
            this.Telefono,
            this.Categoria,
            this.Detalles,
            this.Editar,
            this.Eliminar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvListado.Location = new System.Drawing.Point(12, 163);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            this.DgvListado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvListado.RowTemplate.Height = 25;
            this.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListado.Size = new System.Drawing.Size(1214, 385);
            this.DgvListado.TabIndex = 29;
            this.DgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellContentClick);
            // 
            // Seleccion
            // 
            this.Seleccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Seleccion.FalseValue = "false";
            this.Seleccion.HeaderText = "";
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.ReadOnly = true;
            this.Seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Seleccion.TrueValue = "true";
            this.Seleccion.Width = 5;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id.HeaderText = "Código";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Id.Width = 83;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 92;
            // 
            // Dui
            // 
            this.Dui.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dui.HeaderText = "# DUI";
            this.Dui.Name = "Dui";
            this.Dui.ReadOnly = true;
            this.Dui.Width = 74;
            // 
            // Nit
            // 
            this.Nit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nit.HeaderText = "# NIT";
            this.Nit.Name = "Nit";
            this.Nit.ReadOnly = true;
            this.Nit.Width = 73;
            // 
            // Genero
            // 
            this.Genero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Genero.HeaderText = "Genero";
            this.Genero.Name = "Genero";
            this.Genero.ReadOnly = true;
            this.Genero.Width = 85;
            // 
            // Telefono
            // 
            this.Telefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 95;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Detalles
            // 
            this.Detalles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Detalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Detalles.HeaderText = "";
            this.Detalles.Name = "Detalles";
            this.Detalles.ReadOnly = true;
            this.Detalles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Detalles.Text = "Ver detalles";
            this.Detalles.ToolTipText = "Ver detalles del usuario";
            this.Detalles.UseColumnTextForButtonValue = true;
            this.Detalles.Width = 5;
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editar.HeaderText = "";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Editar.Text = "Editar";
            this.Editar.ToolTipText = "Editar datos del usuario";
            this.Editar.UseColumnTextForButtonValue = true;
            this.Editar.Width = 5;
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.ToolTipText = "Eliminar usuario del sistema";
            this.Eliminar.UseColumnTextForButtonValue = true;
            this.Eliminar.Width = 5;
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtBusqueda.Location = new System.Drawing.Point(12, 122);
            this.TxtBusqueda.MaxLength = 50;
            this.TxtBusqueda.Multiline = true;
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.PlaceholderText = "Buscar por nombre, DUI, NIT o Teléfono";
            this.TxtBusqueda.Size = new System.Drawing.Size(344, 35);
            this.TxtBusqueda.TabIndex = 30;
            this.TxtBusqueda.UseSystemPasswordChar = true;
            // 
            // FrmAsociados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1238, 586);
            this.Controls.Add(this.TxtBusqueda);
            this.Controls.Add(this.DgvListado);
            this.Controls.Add(this.BtnAplicarFiltro);
            this.Controls.Add(this.LLblQuitarFiltro);
            this.Controls.Add(this.LblFilasMarcadas);
            this.Controls.Add(this.CmbFiltro);
            this.Controls.Add(this.CmbAcciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbTipoFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LLblQuitarBusqueda);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnCrearNuevo);
            this.Controls.Add(this.PnlBarraSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAsociados";
            this.Text = "FrmAsociados";
            this.Load += new System.EventHandler(this.FrmAsociados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).EndInit();
            this.PnlBarraSuperior.ResumeLayout(false);
            this.PnlBarraSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAplicarFiltro;
        private System.Windows.Forms.LinkLabel LLblQuitarFiltro;
        private System.Windows.Forms.Label LblFilasMarcadas;
        private System.Windows.Forms.ComboBox CmbFiltro;
        private System.Windows.Forms.ComboBox CmbAcciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTipoFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LLblQuitarBusqueda;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnCrearNuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox BtnMaximizar;
        private System.Windows.Forms.PictureBox BtnCerrar;
        private System.Windows.Forms.Panel PnlBarraSuperior;
        private System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dui;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewButtonColumn Detalles;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.TextBox TxtBusqueda;
    }
}