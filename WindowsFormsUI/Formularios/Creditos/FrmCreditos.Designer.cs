
namespace WindowsFormsUI.Formularios
{
    partial class FrmCreditos
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
            this.LLblQuitarFiltro = new System.Windows.Forms.LinkLabel();
            this.LblFilasMarcadas = new System.Windows.Forms.Label();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.CmbAcciones = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbTipoFiltro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LLblQuitarBusqueda = new System.Windows.Forms.LinkLabel();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.BtnCrearNuevo = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.PnlBarraSuperior = new System.Windows.Forms.Panel();
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.Seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Aprobar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PnlBarraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            this.SuspendLayout();
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
            this.CmbFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltro.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbFiltro.FormattingEnabled = true;
            this.CmbFiltro.ItemHeight = 20;
            this.CmbFiltro.Items.AddRange(new object[] {
            "-- Seleccionar filtro -- ",
            "Empleado"});
            this.CmbFiltro.Location = new System.Drawing.Point(770, 129);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(456, 28);
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
            "-- Seleccionar filtro -- ",
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
            "Empleado"});
            this.CmbTipoFiltro.Location = new System.Drawing.Point(540, 129);
            this.CmbTipoFiltro.Name = "CmbTipoFiltro";
            this.CmbTipoFiltro.Size = new System.Drawing.Size(224, 28);
            this.CmbTipoFiltro.TabIndex = 22;
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
            // TxtBusqueda
            // 
            this.TxtBusqueda.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtBusqueda.Location = new System.Drawing.Point(12, 122);
            this.TxtBusqueda.MaxLength = 50;
            this.TxtBusqueda.Multiline = true;
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.PlaceholderText = "Buscar por código o asociado";
            this.TxtBusqueda.Size = new System.Drawing.Size(344, 35);
            this.TxtBusqueda.TabIndex = 18;
            this.TxtBusqueda.UseSystemPasswordChar = true;
            // 
            // BtnCrearNuevo
            // 
            this.BtnCrearNuevo.BackColor = System.Drawing.Color.White;
            this.BtnCrearNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnCrearNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnCrearNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearNuevo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCrearNuevo.ForeColor = System.Drawing.Color.Black;
            this.BtnCrearNuevo.Image = global::WindowsFormsUI.Properties.Resources.salary24px;
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
            // LblTitulo
            // 
            this.LblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(12, 9);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(67, 20);
            this.LblTitulo.TabIndex = 15;
            this.LblTitulo.Text = "Créditos";
            // 
            // PnlBarraSuperior
            // 
            this.PnlBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.PnlBarraSuperior.Controls.Add(this.LblTitulo);
            this.PnlBarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlBarraSuperior.Name = "PnlBarraSuperior";
            this.PnlBarraSuperior.Size = new System.Drawing.Size(1238, 38);
            this.PnlBarraSuperior.TabIndex = 16;
            // 
            // DgvLista
            // 
            this.DgvLista.AllowUserToAddRows = false;
            this.DgvLista.AllowUserToDeleteRows = false;
            this.DgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DgvLista.BackgroundColor = System.Drawing.Color.White;
            this.DgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.DgvLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccion,
            this.Id,
            this.Monto,
            this.Interes,
            this.Plazo,
            this.Fecha,
            this.Estado,
            this.Asociado,
            this.Detalles,
            this.Aprobar,
            this.Eliminar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvLista.Location = new System.Drawing.Point(12, 163);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            this.DgvLista.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvLista.RowTemplate.Height = 25;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(1214, 385);
            this.DgvLista.TabIndex = 15;
            this.DgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellContentClick);
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
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 81;
            // 
            // Interes
            // 
            this.Interes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Interes.HeaderText = "% Interés";
            this.Interes.Name = "Interes";
            this.Interes.ReadOnly = true;
            // 
            // Plazo
            // 
            this.Plazo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Plazo.HeaderText = "Plazo";
            this.Plazo.Name = "Plazo";
            this.Plazo.ReadOnly = true;
            this.Plazo.Width = 71;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 74;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 81;
            // 
            // Asociado
            // 
            this.Asociado.HeaderText = "Nombre de asociado";
            this.Asociado.Name = "Asociado";
            this.Asociado.ReadOnly = true;
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
            // Aprobar
            // 
            this.Aprobar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Aprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Aprobar.HeaderText = "";
            this.Aprobar.Name = "Aprobar";
            this.Aprobar.ReadOnly = true;
            this.Aprobar.Text = "Aprobar";
            this.Aprobar.ToolTipText = "Aprueba el crédito";
            this.Aprobar.UseColumnTextForButtonValue = true;
            this.Aprobar.Width = 5;
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
            // FrmCreditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1238, 586);
            this.Controls.Add(this.LLblQuitarFiltro);
            this.Controls.Add(this.LblFilasMarcadas);
            this.Controls.Add(this.CmbFiltro);
            this.Controls.Add(this.CmbAcciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbTipoFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LLblQuitarBusqueda);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtBusqueda);
            this.Controls.Add(this.BtnCrearNuevo);
            this.Controls.Add(this.PnlBarraSuperior);
            this.Controls.Add(this.DgvLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCreditos";
            this.Text = "FrmCreditos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCreditos_Load);
            this.PnlBarraSuperior.ResumeLayout(false);
            this.PnlBarraSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel LLblQuitarFiltro;
        private System.Windows.Forms.Label LblFilasMarcadas;
        private System.Windows.Forms.ComboBox CmbFiltro;
        private System.Windows.Forms.ComboBox CmbAcciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTipoFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LLblQuitarBusqueda;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Button BtnCrearNuevo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel PnlBarraSuperior;
        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plazo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asociado;
        private System.Windows.Forms.DataGridViewButtonColumn Detalles;
        private System.Windows.Forms.DataGridViewButtonColumn Aprobar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}