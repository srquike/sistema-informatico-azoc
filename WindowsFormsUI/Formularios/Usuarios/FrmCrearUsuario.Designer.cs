﻿
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
            this.components = new System.ComponentModel.Container();
            this.GrpPermisos = new System.Windows.Forms.GroupBox();
            this.chkPuedeEliminar = new System.Windows.Forms.CheckBox();
            this.chkPuedeEditar = new System.Windows.Forms.CheckBox();
            this.chkPuedeAgregar = new System.Windows.Forms.CheckBox();
            this.chkPuedeVer = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ChkActivarUsuario = new System.Windows.Forms.CheckBox();
            this.MTxtUsuario = new System.Windows.Forms.MaskedTextBox();
            this.ChkVerClaves = new System.Windows.Forms.CheckBox();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtRepetirClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbEmpleados = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OfdElegirAvatar = new System.Windows.Forms.OpenFileDialog();
            this.BtnLimpiarControles = new System.Windows.Forms.Button();
            this.BtnCrearUsuario = new System.Windows.Forms.Button();
            this.ErrPControles = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtPregunta3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtPregunta2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtPregunta1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnElegirImagen = new System.Windows.Forms.Button();
            this.PctAvatar = new System.Windows.Forms.PictureBox();
            this.GrpPermisos.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPControles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpPermisos
            // 
            this.GrpPermisos.Controls.Add(this.chkPuedeEliminar);
            this.GrpPermisos.Controls.Add(this.chkPuedeEditar);
            this.GrpPermisos.Controls.Add(this.chkPuedeAgregar);
            this.GrpPermisos.Controls.Add(this.chkPuedeVer);
            this.GrpPermisos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GrpPermisos.Location = new System.Drawing.Point(697, 270);
            this.GrpPermisos.Name = "GrpPermisos";
            this.GrpPermisos.Size = new System.Drawing.Size(165, 165);
            this.GrpPermisos.TabIndex = 13;
            this.GrpPermisos.TabStop = false;
            this.GrpPermisos.Text = "Permisos";
            // 
            // chkPuedeEliminar
            // 
            this.chkPuedeEliminar.AutoSize = true;
            this.chkPuedeEliminar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPuedeEliminar.Location = new System.Drawing.Point(6, 136);
            this.chkPuedeEliminar.Name = "chkPuedeEliminar";
            this.chkPuedeEliminar.Size = new System.Drawing.Size(127, 24);
            this.chkPuedeEliminar.TabIndex = 17;
            this.chkPuedeEliminar.Tag = "4";
            this.chkPuedeEliminar.Text = "Puede eliminar";
            this.chkPuedeEliminar.UseVisualStyleBackColor = true;
            // 
            // chkPuedeEditar
            // 
            this.chkPuedeEditar.AutoSize = true;
            this.chkPuedeEditar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPuedeEditar.Location = new System.Drawing.Point(6, 98);
            this.chkPuedeEditar.Name = "chkPuedeEditar";
            this.chkPuedeEditar.Size = new System.Drawing.Size(137, 24);
            this.chkPuedeEditar.TabIndex = 16;
            this.chkPuedeEditar.Tag = "3";
            this.chkPuedeEditar.Text = "Puede modificar";
            this.chkPuedeEditar.UseVisualStyleBackColor = true;
            // 
            // chkPuedeAgregar
            // 
            this.chkPuedeAgregar.AutoSize = true;
            this.chkPuedeAgregar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPuedeAgregar.Location = new System.Drawing.Point(6, 60);
            this.chkPuedeAgregar.Name = "chkPuedeAgregar";
            this.chkPuedeAgregar.Size = new System.Drawing.Size(106, 24);
            this.chkPuedeAgregar.TabIndex = 15;
            this.chkPuedeAgregar.Tag = "2";
            this.chkPuedeAgregar.Text = "Puede crear";
            this.chkPuedeAgregar.UseVisualStyleBackColor = true;
            // 
            // chkPuedeVer
            // 
            this.chkPuedeVer.AutoSize = true;
            this.chkPuedeVer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkPuedeVer.Location = new System.Drawing.Point(6, 22);
            this.chkPuedeVer.Name = "chkPuedeVer";
            this.chkPuedeVer.Size = new System.Drawing.Size(93, 24);
            this.chkPuedeVer.TabIndex = 14;
            this.chkPuedeVer.Tag = "1";
            this.chkPuedeVer.Text = "Puede ver";
            this.chkPuedeVer.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ChkActivarUsuario);
            this.groupBox3.Controls.Add(this.MTxtUsuario);
            this.groupBox3.Controls.Add(this.ChkVerClaves);
            this.groupBox3.Controls.Add(this.TxtClave);
            this.groupBox3.Controls.Add(this.TxtRepetirClave);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.CmbEmpleados);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(12, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(548, 258);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos";
            // 
            // ChkActivarUsuario
            // 
            this.ChkActivarUsuario.AutoSize = true;
            this.ChkActivarUsuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChkActivarUsuario.Location = new System.Drawing.Point(152, 228);
            this.ChkActivarUsuario.Name = "ChkActivarUsuario";
            this.ChkActivarUsuario.Size = new System.Drawing.Size(126, 24);
            this.ChkActivarUsuario.TabIndex = 6;
            this.ChkActivarUsuario.Text = "Activar usuario";
            this.ChkActivarUsuario.UseVisualStyleBackColor = true;
            // 
            // MTxtUsuario
            // 
            this.MTxtUsuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MTxtUsuario.HidePromptOnLeave = true;
            this.ErrPControles.SetIconPadding(this.MTxtUsuario, 5);
            this.MTxtUsuario.Location = new System.Drawing.Point(152, 66);
            this.MTxtUsuario.Mask = "00000000-0";
            this.MTxtUsuario.Name = "MTxtUsuario";
            this.MTxtUsuario.PromptChar = '-';
            this.MTxtUsuario.Size = new System.Drawing.Size(369, 27);
            this.MTxtUsuario.TabIndex = 2;
            this.MTxtUsuario.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // ChkVerClaves
            // 
            this.ChkVerClaves.AutoSize = true;
            this.ChkVerClaves.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChkVerClaves.Location = new System.Drawing.Point(152, 198);
            this.ChkVerClaves.Name = "ChkVerClaves";
            this.ChkVerClaves.Size = new System.Drawing.Size(131, 24);
            this.ChkVerClaves.TabIndex = 5;
            this.ChkVerClaves.Text = "Ver contraseñas";
            this.ChkVerClaves.UseVisualStyleBackColor = true;
            this.ChkVerClaves.CheckedChanged += new System.EventHandler(this.ChkVerClaves_CheckedChanged);
            // 
            // TxtClave
            // 
            this.TxtClave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ErrPControles.SetIconPadding(this.TxtClave, 5);
            this.TxtClave.Location = new System.Drawing.Point(152, 115);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.PlaceholderText = "Escriba la contraseña";
            this.TxtClave.Size = new System.Drawing.Size(369, 27);
            this.TxtClave.TabIndex = 3;
            this.TxtClave.UseSystemPasswordChar = true;
            // 
            // TxtRepetirClave
            // 
            this.TxtRepetirClave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ErrPControles.SetIconPadding(this.TxtRepetirClave, 5);
            this.TxtRepetirClave.Location = new System.Drawing.Point(152, 164);
            this.TxtRepetirClave.Name = "TxtRepetirClave";
            this.TxtRepetirClave.PlaceholderText = "Escriba nuevamente la contraseña";
            this.TxtRepetirClave.Size = new System.Drawing.Size(369, 27);
            this.TxtRepetirClave.TabIndex = 4;
            this.TxtRepetirClave.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Repetir contraseña :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(56, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Contraseña :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(2, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre de usuario :";
            // 
            // CmbEmpleados
            // 
            this.CmbEmpleados.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbEmpleados.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbEmpleados.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbEmpleados.FormattingEnabled = true;
            this.CmbEmpleados.Location = new System.Drawing.Point(152, 20);
            this.CmbEmpleados.Name = "CmbEmpleados";
            this.CmbEmpleados.Size = new System.Drawing.Size(369, 28);
            this.CmbEmpleados.TabIndex = 1;
            this.CmbEmpleados.SelectionChangeCommitted += new System.EventHandler(this.CmbEmpleados_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(41, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Pertenecerá a :";
            // 
            // OfdElegirAvatar
            // 
            this.OfdElegirAvatar.Filter = "Imagene |*.JPEG";
            this.OfdElegirAvatar.Title = "Seleccionar imagen para el avatar";
            // 
            // BtnLimpiarControles
            // 
            this.BtnLimpiarControles.BackColor = System.Drawing.Color.White;
            this.BtnLimpiarControles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnLimpiarControles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnLimpiarControles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiarControles.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnLimpiarControles.ForeColor = System.Drawing.Color.Black;
            this.BtnLimpiarControles.Image = global::WindowsFormsUI.Properties.Resources.household;
            this.BtnLimpiarControles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiarControles.Location = new System.Drawing.Point(628, 441);
            this.BtnLimpiarControles.Name = "BtnLimpiarControles";
            this.BtnLimpiarControles.Size = new System.Drawing.Size(114, 35);
            this.BtnLimpiarControles.TabIndex = 18;
            this.BtnLimpiarControles.Text = "Limpiar";
            this.BtnLimpiarControles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimpiarControles.UseVisualStyleBackColor = false;
            this.BtnLimpiarControles.Click += new System.EventHandler(this.BtnLimpiarControles_Click);
            // 
            // BtnCrearUsuario
            // 
            this.BtnCrearUsuario.BackColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnCrearUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearUsuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCrearUsuario.ForeColor = System.Drawing.Color.Black;
            this.BtnCrearUsuario.Image = global::WindowsFormsUI.Properties.Resources.add_friend;
            this.BtnCrearUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrearUsuario.Location = new System.Drawing.Point(474, 441);
            this.BtnCrearUsuario.Name = "BtnCrearUsuario";
            this.BtnCrearUsuario.Size = new System.Drawing.Size(149, 35);
            this.BtnCrearUsuario.TabIndex = 19;
            this.BtnCrearUsuario.Text = "Crear usuario";
            this.BtnCrearUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCrearUsuario.UseVisualStyleBackColor = false;
            this.BtnCrearUsuario.Click += new System.EventHandler(this.BtnCrearUsuario_Click);
            // 
            // ErrPControles
            // 
            this.ErrPControles.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtPregunta3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtPregunta2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtPregunta1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 165);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preguntas";
            // 
            // TxtPregunta3
            // 
            this.TxtPregunta3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPregunta3.Location = new System.Drawing.Point(352, 118);
            this.TxtPregunta3.Name = "TxtPregunta3";
            this.TxtPregunta3.PlaceholderText = "Escribe la respuesta";
            this.TxtPregunta3.Size = new System.Drawing.Size(303, 27);
            this.TxtPregunta3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "3. ¿Cuál era tu apodo de infancia?";
            // 
            // TxtPregunta2
            // 
            this.TxtPregunta2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPregunta2.Location = new System.Drawing.Point(352, 69);
            this.TxtPregunta2.Name = "TxtPregunta2";
            this.TxtPregunta2.PlaceholderText = "Escribe la respuesta";
            this.TxtPregunta2.Size = new System.Drawing.Size(303, 27);
            this.TxtPregunta2.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(340, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "2. ¿Cuál es el nombre de la ciudad donde naciste?";
            // 
            // TxtPregunta1
            // 
            this.TxtPregunta1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPregunta1.Location = new System.Drawing.Point(352, 20);
            this.TxtPregunta1.Name = "TxtPregunta1";
            this.TxtPregunta1.PlaceholderText = "Escribe la respuesta";
            this.TxtPregunta1.Size = new System.Drawing.Size(303, 27);
            this.TxtPregunta1.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(318, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "1. ¿Cuál fue el nombre de tu primera mascota?";
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
            this.BtnCancelar.Location = new System.Drawing.Point(748, 441);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(114, 35);
            this.BtnCancelar.TabIndex = 22;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnElegirImagen);
            this.groupBox2.Controls.Add(this.PctAvatar);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(566, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 258);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imagen";
            // 
            // BtnElegirImagen
            // 
            this.BtnElegirImagen.BackColor = System.Drawing.Color.White;
            this.BtnElegirImagen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnElegirImagen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnElegirImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnElegirImagen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnElegirImagen.ForeColor = System.Drawing.Color.Black;
            this.BtnElegirImagen.Image = global::WindowsFormsUI.Properties.Resources.folder;
            this.BtnElegirImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnElegirImagen.Location = new System.Drawing.Point(183, 26);
            this.BtnElegirImagen.Name = "BtnElegirImagen";
            this.BtnElegirImagen.Size = new System.Drawing.Size(105, 35);
            this.BtnElegirImagen.TabIndex = 8;
            this.BtnElegirImagen.Text = "Elegir";
            this.BtnElegirImagen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnElegirImagen.UseVisualStyleBackColor = false;
            this.BtnElegirImagen.Click += new System.EventHandler(this.BtnElegirImagen_Click);
            // 
            // PctAvatar
            // 
            this.PctAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PctAvatar.Location = new System.Drawing.Point(6, 26);
            this.PctAvatar.Name = "PctAvatar";
            this.PctAvatar.Size = new System.Drawing.Size(171, 226);
            this.PctAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctAvatar.TabIndex = 0;
            this.PctAvatar.TabStop = false;
            // 
            // FrmCrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 486);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCrearUsuario);
            this.Controls.Add(this.BtnLimpiarControles);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GrpPermisos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCrearUsuario";
            this.Text = "Cooperativa AZOC de R. L. - Crear nuevo usuario";
            this.Load += new System.EventHandler(this.FrmCrearUsuario_Load);
            this.GrpPermisos.ResumeLayout(false);
            this.GrpPermisos.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPControles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PctAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpPermisos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CmbEmpleados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkPuedeEliminar;
        private System.Windows.Forms.CheckBox chkPuedeEditar;
        private System.Windows.Forms.CheckBox chkPuedeAgregar;
        private System.Windows.Forms.CheckBox chkPuedeVer;
        private System.Windows.Forms.CheckBox ChkVerClaves;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtRepetirClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog OfdElegirAvatar;
        private System.Windows.Forms.MaskedTextBox MTxtUsuario;
        private System.Windows.Forms.CheckBox ChkActivarUsuario;
        private System.Windows.Forms.Button BtnLimpiarControles;
        private System.Windows.Forms.Button BtnCrearUsuario;
        private System.Windows.Forms.ErrorProvider ErrPControles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtPregunta3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtPregunta2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPregunta1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnElegirImagen;
        private System.Windows.Forms.PictureBox PctAvatar;
    }
}