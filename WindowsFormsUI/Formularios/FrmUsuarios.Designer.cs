
namespace WindowsFormsUI.Formularios
{
    partial class FrmUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnAgregarUsuario = new System.Windows.Forms.Button();
            this.DgvListaUsuarios = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimoAcceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAgregarUsuario
            // 
            this.BtnAgregarUsuario.Location = new System.Drawing.Point(12, 46);
            this.BtnAgregarUsuario.Name = "BtnAgregarUsuario";
            this.BtnAgregarUsuario.Size = new System.Drawing.Size(136, 52);
            this.BtnAgregarUsuario.TabIndex = 0;
            this.BtnAgregarUsuario.Text = "Agregar nuevo";
            this.BtnAgregarUsuario.UseVisualStyleBackColor = true;
            this.BtnAgregarUsuario.Click += new System.EventHandler(this.BtnAgregarUsuario_Click);
            // 
            // DgvListaUsuarios
            // 
            this.DgvListaUsuarios.AllowUserToAddRows = false;
            this.DgvListaUsuarios.AllowUserToDeleteRows = false;
            this.DgvListaUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvListaUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvListaUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DgvListaUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.DgvListaUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvListaUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.DgvListaUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListaUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvListaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Usuario,
            this.UltimoAcceso,
            this.FechaCreacion,
            this.Estado,
            this.Empleado,
            this.Detalles,
            this.Editar,
            this.Eliminar});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListaUsuarios.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvListaUsuarios.Location = new System.Drawing.Point(12, 104);
            this.DgvListaUsuarios.Name = "DgvListaUsuarios";
            this.DgvListaUsuarios.ReadOnly = true;
            this.DgvListaUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            this.DgvListaUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvListaUsuarios.RowTemplate.Height = 25;
            this.DgvListaUsuarios.Size = new System.Drawing.Size(1084, 361);
            this.DgvListaUsuarios.TabIndex = 1;
            this.DgvListaUsuarios.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvListaUsuarios_RowPostPaint);
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
            // Usuario
            // 
            this.Usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Usuario.HeaderText = "Nombre de usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 107;
            // 
            // UltimoAcceso
            // 
            this.UltimoAcceso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UltimoAcceso.HeaderText = "Ultimo acceso";
            this.UltimoAcceso.Name = "UltimoAcceso";
            this.UltimoAcceso.ReadOnly = true;
            this.UltimoAcceso.Width = 121;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FechaCreacion.HeaderText = "Fecha de creación";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            this.FechaCreacion.Width = 143;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 81;
            // 
            // Empleado
            // 
            this.Empleado.HeaderText = "Pertenece a";
            this.Empleado.Name = "Empleado";
            this.Empleado.ReadOnly = true;
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
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 477);
            this.Controls.Add(this.DgvListaUsuarios);
            this.Controls.Add(this.BtnAgregarUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAgregarUsuario;
        private System.Windows.Forms.DataGridView DgvListaUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimoAcceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewButtonColumn Detalles;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}