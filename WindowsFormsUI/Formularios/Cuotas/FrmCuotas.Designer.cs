
namespace WindowsFormsUI.Formularios.Cuotas
{
    partial class FrmCuotas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LLblQuitarMarcadas = new System.Windows.Forms.LinkLabel();
            this.LblFilasMarcadas = new System.Windows.Forms.Label();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.CmbAcciones = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbTipoFiltro = new System.Windows.Forms.ComboBox();
            this.LLblQuitarBusqueda = new System.Windows.Forms.LinkLabel();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PnlBarraSuperior = new System.Windows.Forms.Panel();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.Seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimineto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Pagar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LLblQuitarFiltro = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlBarraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // LLblQuitarMarcadas
            // 
            this.LLblQuitarMarcadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LLblQuitarMarcadas.AutoSize = true;
            this.LLblQuitarMarcadas.Enabled = false;
            this.LLblQuitarMarcadas.Location = new System.Drawing.Point(12, 539);
            this.LLblQuitarMarcadas.Name = "LLblQuitarMarcadas";
            this.LLblQuitarMarcadas.Size = new System.Drawing.Size(94, 15);
            this.LLblQuitarMarcadas.TabIndex = 29;
            this.LLblQuitarMarcadas.TabStop = true;
            this.LLblQuitarMarcadas.Text = "Quitar marcadas";
            // 
            // LblFilasMarcadas
            // 
            this.LblFilasMarcadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblFilasMarcadas.AutoSize = true;
            this.LblFilasMarcadas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblFilasMarcadas.Location = new System.Drawing.Point(113, 535);
            this.LblFilasMarcadas.Name = "LblFilasMarcadas";
            this.LblFilasMarcadas.Size = new System.Drawing.Size(121, 20);
            this.LblFilasMarcadas.TabIndex = 27;
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
            this.CmbFiltro.Location = new System.Drawing.Point(770, 66);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(456, 28);
            this.CmbFiltro.TabIndex = 26;
            this.CmbFiltro.SelectionChangeCommitted += new System.EventHandler(this.CmbFiltro_SelectionChangeCommitted);
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
            "Imprimir"});
            this.CmbAcciones.Location = new System.Drawing.Point(1047, 532);
            this.CmbAcciones.Name = "CmbAcciones";
            this.CmbAcciones.Size = new System.Drawing.Size(179, 28);
            this.CmbAcciones.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(970, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 24;
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
            "Estado"});
            this.CmbTipoFiltro.Location = new System.Drawing.Point(540, 66);
            this.CmbTipoFiltro.Name = "CmbTipoFiltro";
            this.CmbTipoFiltro.Size = new System.Drawing.Size(224, 28);
            this.CmbTipoFiltro.TabIndex = 23;
            this.CmbTipoFiltro.SelectionChangeCommitted += new System.EventHandler(this.CmbTipoFiltro_SelectionChangeCommitted);
            // 
            // LLblQuitarBusqueda
            // 
            this.LLblQuitarBusqueda.AutoSize = true;
            this.LLblQuitarBusqueda.Enabled = false;
            this.LLblQuitarBusqueda.Location = new System.Drawing.Point(12, 41);
            this.LLblQuitarBusqueda.Name = "LLblQuitarBusqueda";
            this.LLblQuitarBusqueda.Size = new System.Drawing.Size(95, 15);
            this.LLblQuitarBusqueda.TabIndex = 21;
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
            this.BtnBuscar.Location = new System.Drawing.Point(362, 59);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(89, 35);
            this.BtnBuscar.TabIndex = 20;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtBusqueda.Location = new System.Drawing.Point(12, 59);
            this.TxtBusqueda.MaxLength = 50;
            this.TxtBusqueda.Multiline = true;
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.PlaceholderText = "Buscar por código de crédito";
            this.TxtBusqueda.Size = new System.Drawing.Size(344, 35);
            this.TxtBusqueda.TabIndex = 19;
            this.TxtBusqueda.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cuota";
            // 
            // PnlBarraSuperior
            // 
            this.PnlBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.PnlBarraSuperior.Controls.Add(this.label3);
            this.PnlBarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlBarraSuperior.Name = "PnlBarraSuperior";
            this.PnlBarraSuperior.Size = new System.Drawing.Size(1238, 38);
            this.PnlBarraSuperior.TabIndex = 17;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccion,
            this.Id,
            this.Numero,
            this.Monto,
            this.FechaVencimineto,
            this.FechaPago,
            this.Credito,
            this.Estado,
            this.Detalles,
            this.Pagar});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvListado.Location = new System.Drawing.Point(12, 100);
            this.DgvListado.MultiSelect = false;
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            this.DgvListado.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvListado.RowTemplate.Height = 25;
            this.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListado.Size = new System.Drawing.Size(1214, 426);
            this.DgvListado.TabIndex = 16;
            this.DgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellContentClick);
            // 
            // Seleccion
            // 
            this.Seleccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Seleccion.FalseValue = "false";
            this.Seleccion.HeaderText = "";
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.ReadOnly = true;
            this.Seleccion.TrueValue = "true";
            this.Seleccion.Width = 5;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 48;
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 92;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 81;
            // 
            // FechaVencimineto
            // 
            this.FechaVencimineto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FechaVencimineto.HeaderText = "Fecha de vencimiento";
            this.FechaVencimineto.Name = "FechaVencimineto";
            this.FechaVencimineto.ReadOnly = true;
            this.FechaVencimineto.Width = 169;
            // 
            // FechaPago
            // 
            this.FechaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FechaPago.HeaderText = "Fecha de pago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.ReadOnly = true;
            this.FechaPago.Width = 91;
            // 
            // Credito
            // 
            this.Credito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Credito.HeaderText = "Pertenece al crédito";
            this.Credito.Name = "Credito";
            this.Credito.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 81;
            // 
            // Detalles
            // 
            this.Detalles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Detalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Detalles.HeaderText = "";
            this.Detalles.Name = "Detalles";
            this.Detalles.ReadOnly = true;
            this.Detalles.Text = "Ver detalles";
            this.Detalles.ToolTipText = "Ver detalles del usuario";
            this.Detalles.UseColumnTextForButtonValue = true;
            this.Detalles.Width = 5;
            // 
            // Pagar
            // 
            this.Pagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Pagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pagar.HeaderText = "";
            this.Pagar.Name = "Pagar";
            this.Pagar.ReadOnly = true;
            this.Pagar.Text = "Pagar";
            this.Pagar.ToolTipText = "Pagar la cuota";
            this.Pagar.UseColumnTextForButtonValue = true;
            this.Pagar.Width = 5;
            // 
            // LLblQuitarFiltro
            // 
            this.LLblQuitarFiltro.AutoSize = true;
            this.LLblQuitarFiltro.Enabled = false;
            this.LLblQuitarFiltro.Location = new System.Drawing.Point(540, 48);
            this.LLblQuitarFiltro.Name = "LLblQuitarFiltro";
            this.LLblQuitarFiltro.Size = new System.Drawing.Size(68, 15);
            this.LLblQuitarFiltro.TabIndex = 28;
            this.LLblQuitarFiltro.TabStop = true;
            this.LLblQuitarFiltro.Text = "Quitar filtro";
            this.LLblQuitarFiltro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLblQuitarFiltro_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(457, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Filtrar por:";
            // 
            // FrmCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1238, 572);
            this.Controls.Add(this.LLblQuitarMarcadas);
            this.Controls.Add(this.LblFilasMarcadas);
            this.Controls.Add(this.CmbFiltro);
            this.Controls.Add(this.CmbAcciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbTipoFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LLblQuitarBusqueda);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtBusqueda);
            this.Controls.Add(this.LLblQuitarFiltro);
            this.Controls.Add(this.PnlBarraSuperior);
            this.Controls.Add(this.DgvListado);
            this.Name = "FrmCuotas";
            this.Text = "Cuota";
            this.Load += new System.EventHandler(this.FrmCuotas_Load);
            this.PnlBarraSuperior.ResumeLayout(false);
            this.PnlBarraSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LLblQuitarMarcadas;
        private System.Windows.Forms.Label LblFilasMarcadas;
        private System.Windows.Forms.ComboBox CmbFiltro;
        private System.Windows.Forms.ComboBox CmbAcciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTipoFiltro;
        private System.Windows.Forms.LinkLabel LLblQuitarBusqueda;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PnlBarraSuperior;
        private System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.LinkLabel LLblQuitarFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimineto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn Detalles;
        private System.Windows.Forms.DataGridViewButtonColumn Pagar;
    }
}