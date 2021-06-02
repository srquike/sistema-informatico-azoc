
namespace WindowsFormsUI.Formularios
{
    partial class FrmConfiguracion
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
            this.TcOpciones = new System.Windows.Forms.TabControl();
            this.TpGeneral = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkVerClaves = new System.Windows.Forms.CheckBox();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtRepetirClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TpBaseDatos = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnRestaurar = new System.Windows.Forms.Button();
            this.LblPorcentaje = new System.Windows.Forms.Label();
            this.LblEstado = new System.Windows.Forms.Label();
            this.PbProgreso = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnRespaldar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.FbdUbicacion = new System.Windows.Forms.FolderBrowserDialog();
            this.OfdSeleccionar = new System.Windows.Forms.OpenFileDialog();
            this.TcOpciones.SuspendLayout();
            this.TpGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TpBaseDatos.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TcOpciones
            // 
            this.TcOpciones.Controls.Add(this.TpGeneral);
            this.TcOpciones.Controls.Add(this.TpBaseDatos);
            this.TcOpciones.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TcOpciones.ItemSize = new System.Drawing.Size(100, 25);
            this.TcOpciones.Location = new System.Drawing.Point(0, 0);
            this.TcOpciones.Name = "TcOpciones";
            this.TcOpciones.SelectedIndex = 0;
            this.TcOpciones.Size = new System.Drawing.Size(577, 397);
            this.TcOpciones.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TcOpciones.TabIndex = 0;
            // 
            // TpGeneral
            // 
            this.TpGeneral.Controls.Add(this.groupBox1);
            this.TpGeneral.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TpGeneral.Location = new System.Drawing.Point(4, 29);
            this.TpGeneral.Name = "TpGeneral";
            this.TpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TpGeneral.Size = new System.Drawing.Size(569, 364);
            this.TpGeneral.TabIndex = 0;
            this.TpGeneral.Text = "General";
            this.TpGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkVerClaves);
            this.groupBox1.Controls.Add(this.TxtClave);
            this.groupBox1.Controls.Add(this.TxtRepetirClave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cambiar contraseña de administrador";
            // 
            // ChkVerClaves
            // 
            this.ChkVerClaves.AutoSize = true;
            this.ChkVerClaves.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChkVerClaves.Location = new System.Drawing.Point(152, 106);
            this.ChkVerClaves.Name = "ChkVerClaves";
            this.ChkVerClaves.Size = new System.Drawing.Size(131, 24);
            this.ChkVerClaves.TabIndex = 21;
            this.ChkVerClaves.Text = "Ver contraseñas";
            this.ChkVerClaves.UseVisualStyleBackColor = true;
            // 
            // TxtClave
            // 
            this.TxtClave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtClave.Location = new System.Drawing.Point(152, 33);
            this.TxtClave.Margin = new System.Windows.Forms.Padding(10);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.PlaceholderText = "Escriba la nueva contraseña";
            this.TxtClave.Size = new System.Drawing.Size(369, 27);
            this.TxtClave.TabIndex = 19;
            this.TxtClave.UseSystemPasswordChar = true;
            // 
            // TxtRepetirClave
            // 
            this.TxtRepetirClave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtRepetirClave.Location = new System.Drawing.Point(152, 73);
            this.TxtRepetirClave.Name = "TxtRepetirClave";
            this.TxtRepetirClave.PlaceholderText = "Escriba nuevamente la contraseña";
            this.TxtRepetirClave.Size = new System.Drawing.Size(369, 27);
            this.TxtRepetirClave.TabIndex = 20;
            this.TxtRepetirClave.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Repetir contraseña :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(56, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Contraseña :";
            // 
            // TpBaseDatos
            // 
            this.TpBaseDatos.Controls.Add(this.groupBox3);
            this.TpBaseDatos.Controls.Add(this.LblPorcentaje);
            this.TpBaseDatos.Controls.Add(this.LblEstado);
            this.TpBaseDatos.Controls.Add(this.PbProgreso);
            this.TpBaseDatos.Controls.Add(this.groupBox2);
            this.TpBaseDatos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TpBaseDatos.Location = new System.Drawing.Point(4, 29);
            this.TpBaseDatos.Name = "TpBaseDatos";
            this.TpBaseDatos.Padding = new System.Windows.Forms.Padding(3);
            this.TpBaseDatos.Size = new System.Drawing.Size(569, 364);
            this.TpBaseDatos.TabIndex = 1;
            this.TpBaseDatos.Text = "Base de datos";
            this.TpBaseDatos.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnRestaurar);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(8, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(553, 66);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Restaurar base de datos";
            // 
            // BtnRestaurar
            // 
            this.BtnRestaurar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRestaurar.Location = new System.Drawing.Point(6, 26);
            this.BtnRestaurar.Name = "BtnRestaurar";
            this.BtnRestaurar.Size = new System.Drawing.Size(89, 33);
            this.BtnRestaurar.TabIndex = 1;
            this.BtnRestaurar.Text = "Restaurar";
            this.BtnRestaurar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRestaurar.UseVisualStyleBackColor = true;
            this.BtnRestaurar.Click += new System.EventHandler(this.BtnRestaurar_Click);
            // 
            // LblPorcentaje
            // 
            this.LblPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPorcentaje.AutoSize = true;
            this.LblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblPorcentaje.Location = new System.Drawing.Point(259, 333);
            this.LblPorcentaje.Name = "LblPorcentaje";
            this.LblPorcentaje.Size = new System.Drawing.Size(33, 20);
            this.LblPorcentaje.TabIndex = 5;
            this.LblPorcentaje.Text = "0 %";
            this.LblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblEstado
            // 
            this.LblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEstado.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEstado.Location = new System.Drawing.Point(8, 310);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(553, 20);
            this.LblEstado.TabIndex = 4;
            this.LblEstado.Text = "Estado :";
            this.LblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PbProgreso
            // 
            this.PbProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PbProgreso.Location = new System.Drawing.Point(8, 332);
            this.PbProgreso.Name = "PbProgreso";
            this.PbProgreso.Size = new System.Drawing.Size(553, 23);
            this.PbProgreso.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnRespaldar);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 66);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Respaldar base de datos";
            // 
            // BtnRespaldar
            // 
            this.BtnRespaldar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRespaldar.Location = new System.Drawing.Point(6, 26);
            this.BtnRespaldar.Name = "BtnRespaldar";
            this.BtnRespaldar.Size = new System.Drawing.Size(89, 33);
            this.BtnRespaldar.TabIndex = 1;
            this.BtnRespaldar.Text = "Respaldar";
            this.BtnRespaldar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRespaldar.UseVisualStyleBackColor = true;
            this.BtnRespaldar.Click += new System.EventHandler(this.BtnRespaldar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.White;
            this.BtnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelar.ForeColor = System.Drawing.Color.Black;
            this.BtnCancelar.Image = global::WindowsFormsUI.Properties.Resources.prohibition;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(462, 403);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(103, 35);
            this.BtnCancelar.TabIndex = 26;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.White;
            this.BtnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGuardar.ForeColor = System.Drawing.Color.Black;
            this.BtnGuardar.Image = global::WindowsFormsUI.Properties.Resources.floppy_disk;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(253, 403);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(203, 35);
            this.BtnGuardar.TabIndex = 25;
            this.BtnGuardar.Text = "Guardar configuración";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // OfdSeleccionar
            // 
            this.OfdSeleccionar.Filter = "Backup |*.bak";
            this.OfdSeleccionar.Title = "Seleccionar archivo de respaldo";
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 450);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.TcOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmConfiguracion";
            this.Text = "Cooperativa AZOC de R. L. - Configuración del sistema";
            this.TcOpciones.ResumeLayout(false);
            this.TpGeneral.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TpBaseDatos.ResumeLayout(false);
            this.TpBaseDatos.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TcOpciones;
        private System.Windows.Forms.TabPage TpGeneral;
        private System.Windows.Forms.TabPage TpBaseDatos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkVerClaves;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtRepetirClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar PbProgreso;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnRespaldar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnRestaurar;
        private System.Windows.Forms.Label LblPorcentaje;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.FolderBrowserDialog FbdUbicacion;
        private System.Windows.Forms.OpenFileDialog OfdSeleccionar;
    }
}