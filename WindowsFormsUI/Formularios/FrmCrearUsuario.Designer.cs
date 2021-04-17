
namespace WindowsFormsUI.Formularios
{
    partial class FrmCrearUsuario
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
            this.GrpPermisos = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkPuedeEliminar = new System.Windows.Forms.CheckBox();
            this.chkPuedeEditar = new System.Windows.Forms.CheckBox();
            this.chkPuedeAgregar = new System.Windows.Forms.CheckBox();
            this.chkPuedeVer = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnTomarFoto = new System.Windows.Forms.Button();
            this.BtnElegirImagen = new System.Windows.Forms.Button();
            this.BtnQuitarImagen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbEmpleados = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.ChkVerClaves = new System.Windows.Forms.CheckBox();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtRepetirClave = new System.Windows.Forms.TextBox();
            this.TxtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpPermisos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpPermisos
            // 
            this.GrpPermisos.Controls.Add(this.checkBox1);
            this.GrpPermisos.Controls.Add(this.chkPuedeEliminar);
            this.GrpPermisos.Controls.Add(this.chkPuedeEditar);
            this.GrpPermisos.Controls.Add(this.chkPuedeAgregar);
            this.GrpPermisos.Controls.Add(this.chkPuedeVer);
            this.GrpPermisos.Location = new System.Drawing.Point(365, 6);
            this.GrpPermisos.Name = "GrpPermisos";
            this.GrpPermisos.Size = new System.Drawing.Size(127, 167);
            this.GrpPermisos.TabIndex = 6;
            this.GrpPermisos.TabStop = false;
            this.GrpPermisos.Text = "Permisos";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 142);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Tag = "6";
            this.checkBox1.Text = "Acceso completo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkPuedeEliminar
            // 
            this.chkPuedeEliminar.AutoSize = true;
            this.chkPuedeEliminar.Location = new System.Drawing.Point(6, 112);
            this.chkPuedeEliminar.Name = "chkPuedeEliminar";
            this.chkPuedeEliminar.Size = new System.Drawing.Size(105, 19);
            this.chkPuedeEliminar.TabIndex = 3;
            this.chkPuedeEliminar.Tag = "4";
            this.chkPuedeEliminar.Text = "Puede eliminar";
            this.chkPuedeEliminar.UseVisualStyleBackColor = true;
            // 
            // chkPuedeEditar
            // 
            this.chkPuedeEditar.AutoSize = true;
            this.chkPuedeEditar.Location = new System.Drawing.Point(6, 82);
            this.chkPuedeEditar.Name = "chkPuedeEditar";
            this.chkPuedeEditar.Size = new System.Drawing.Size(92, 19);
            this.chkPuedeEditar.TabIndex = 2;
            this.chkPuedeEditar.Tag = "3";
            this.chkPuedeEditar.Text = "Puede editar";
            this.chkPuedeEditar.UseVisualStyleBackColor = true;
            // 
            // chkPuedeAgregar
            // 
            this.chkPuedeAgregar.AutoSize = true;
            this.chkPuedeAgregar.Location = new System.Drawing.Point(6, 52);
            this.chkPuedeAgregar.Name = "chkPuedeAgregar";
            this.chkPuedeAgregar.Size = new System.Drawing.Size(102, 19);
            this.chkPuedeAgregar.TabIndex = 1;
            this.chkPuedeAgregar.Tag = "2";
            this.chkPuedeAgregar.Text = "Puede agregar";
            this.chkPuedeAgregar.UseVisualStyleBackColor = true;
            // 
            // chkPuedeVer
            // 
            this.chkPuedeVer.AutoSize = true;
            this.chkPuedeVer.Location = new System.Drawing.Point(6, 22);
            this.chkPuedeVer.Name = "chkPuedeVer";
            this.chkPuedeVer.Size = new System.Drawing.Size(78, 19);
            this.chkPuedeVer.TabIndex = 0;
            this.chkPuedeVer.Tag = "1";
            this.chkPuedeVer.Text = "Puede ver";
            this.chkPuedeVer.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.BtnTomarFoto);
            this.groupBox2.Controls.Add(this.BtnElegirImagen);
            this.groupBox2.Controls.Add(this.BtnQuitarImagen);
            this.groupBox2.Location = new System.Drawing.Point(498, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 167);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imagen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 137);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BtnTomarFoto
            // 
            this.BtnTomarFoto.Location = new System.Drawing.Point(112, 80);
            this.BtnTomarFoto.Name = "BtnTomarFoto";
            this.BtnTomarFoto.Size = new System.Drawing.Size(106, 23);
            this.BtnTomarFoto.TabIndex = 10;
            this.BtnTomarFoto.Text = "Tomar foto";
            this.BtnTomarFoto.UseVisualStyleBackColor = true;
            // 
            // BtnElegirImagen
            // 
            this.BtnElegirImagen.Location = new System.Drawing.Point(112, 22);
            this.BtnElegirImagen.Name = "BtnElegirImagen";
            this.BtnElegirImagen.Size = new System.Drawing.Size(106, 23);
            this.BtnElegirImagen.TabIndex = 8;
            this.BtnElegirImagen.Text = "Elegir";
            this.BtnElegirImagen.UseVisualStyleBackColor = true;
            // 
            // BtnQuitarImagen
            // 
            this.BtnQuitarImagen.Location = new System.Drawing.Point(112, 51);
            this.BtnQuitarImagen.Name = "BtnQuitarImagen";
            this.BtnQuitarImagen.Size = new System.Drawing.Size(106, 23);
            this.BtnQuitarImagen.TabIndex = 9;
            this.BtnQuitarImagen.Text = "Quitar";
            this.BtnQuitarImagen.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ChkVerClaves);
            this.groupBox3.Controls.Add(this.TxtClave);
            this.groupBox3.Controls.Add(this.TxtRepetirClave);
            this.groupBox3.Controls.Add(this.TxtNombreUsuario);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.CmbEmpleados);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 167);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos";
            // 
            // CmbEmpleados
            // 
            this.CmbEmpleados.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbEmpleados.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbEmpleados.FormattingEnabled = true;
            this.CmbEmpleados.Location = new System.Drawing.Point(124, 16);
            this.CmbEmpleados.Name = "CmbEmpleados";
            this.CmbEmpleados.Size = new System.Drawing.Size(211, 23);
            this.CmbEmpleados.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Empleado:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(391, 179);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(106, 23);
            this.BtnGuardar.TabIndex = 11;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(503, 179);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(106, 23);
            this.BtnLimpiar.TabIndex = 12;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(615, 179);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(106, 23);
            this.BtnCancelar.TabIndex = 13;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // ChkVerClaves
            // 
            this.ChkVerClaves.AutoSize = true;
            this.ChkVerClaves.Location = new System.Drawing.Point(124, 143);
            this.ChkVerClaves.Name = "ChkVerClaves";
            this.ChkVerClaves.Size = new System.Drawing.Size(108, 19);
            this.ChkVerClaves.TabIndex = 22;
            this.ChkVerClaves.Text = "Ver contraseñas";
            this.ChkVerClaves.UseVisualStyleBackColor = true;
            // 
            // TxtClave
            // 
            this.TxtClave.Location = new System.Drawing.Point(124, 81);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.PlaceholderText = "Escriba la contraseña";
            this.TxtClave.Size = new System.Drawing.Size(211, 23);
            this.TxtClave.TabIndex = 21;
            this.TxtClave.UseSystemPasswordChar = true;
            // 
            // TxtRepetirClave
            // 
            this.TxtRepetirClave.Location = new System.Drawing.Point(124, 114);
            this.TxtRepetirClave.Name = "TxtRepetirClave";
            this.TxtRepetirClave.PlaceholderText = "Escriba nuevamente la contraseña";
            this.TxtRepetirClave.Size = new System.Drawing.Size(211, 23);
            this.TxtRepetirClave.TabIndex = 20;
            this.TxtRepetirClave.UseSystemPasswordChar = true;
            // 
            // TxtNombreUsuario
            // 
            this.TxtNombreUsuario.Location = new System.Drawing.Point(124, 48);
            this.TxtNombreUsuario.Name = "TxtNombreUsuario";
            this.TxtNombreUsuario.PlaceholderText = "Escriba el nombre de usuario";
            this.TxtNombreUsuario.Size = new System.Drawing.Size(211, 23);
            this.TxtNombreUsuario.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Repetir contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre de usuario:";
            // 
            // FrmCrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 211);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GrpPermisos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCrearUsuario";
            this.Text = "Cooperativa AZOC de R. L. :: Creación de usuario";
            this.Load += new System.EventHandler(this.FrmCrearUsuario_Load);
            this.GrpPermisos.ResumeLayout(false);
            this.GrpPermisos.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpPermisos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnTomarFoto;
        private System.Windows.Forms.Button BtnElegirImagen;
        private System.Windows.Forms.Button BtnQuitarImagen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ComboBox CmbEmpleados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkPuedeEliminar;
        private System.Windows.Forms.CheckBox chkPuedeEditar;
        private System.Windows.Forms.CheckBox chkPuedeAgregar;
        private System.Windows.Forms.CheckBox chkPuedeVer;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox ChkVerClaves;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtRepetirClave;
        private System.Windows.Forms.TextBox TxtNombreUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}