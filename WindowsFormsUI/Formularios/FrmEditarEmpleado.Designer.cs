
namespace WindowsFormsUI.Formularios
{
    partial class FrmEditarEmpleado
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
            this.MTxtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.MTxtDui = new System.Windows.Forms.MaskedTextBox();
            this.MTxtNit = new System.Windows.Forms.MaskedTextBox();
            this.CmbDepartamentos = new System.Windows.Forms.ComboBox();
            this.CmbCargos = new System.Windows.Forms.ComboBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.CmbMunicipios = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.CmbGeneros = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtSNombre = new System.Windows.Forms.TextBox();
            this.BtnLimpiarControles = new System.Windows.Forms.Button();
            this.ErrPControles = new System.Windows.Forms.ErrorProvider(this.components);
            this.DtpFNacimiento = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtTApellido = new System.Windows.Forms.TextBox();
            this.TxtTNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnGuardarCambios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPControles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MTxtTelefono
            // 
            this.MTxtTelefono.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MTxtTelefono.HidePromptOnLeave = true;
            this.MTxtTelefono.Location = new System.Drawing.Point(168, 209);
            this.MTxtTelefono.Mask = "0000-0000";
            this.MTxtTelefono.Name = "MTxtTelefono";
            this.MTxtTelefono.PromptChar = '-';
            this.MTxtTelefono.Size = new System.Drawing.Size(200, 27);
            this.MTxtTelefono.TabIndex = 13;
            this.MTxtTelefono.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(88, 212);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 20);
            this.label17.TabIndex = 32;
            this.label17.Text = "Teléfono :";
            // 
            // MTxtDui
            // 
            this.MTxtDui.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MTxtDui.HidePromptOnLeave = true;
            this.MTxtDui.Location = new System.Drawing.Point(534, 209);
            this.MTxtDui.Mask = "00000000-0";
            this.MTxtDui.Name = "MTxtDui";
            this.MTxtDui.PromptChar = '-';
            this.MTxtDui.Size = new System.Drawing.Size(200, 27);
            this.MTxtDui.TabIndex = 14;
            this.MTxtDui.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // MTxtNit
            // 
            this.MTxtNit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MTxtNit.HidePromptOnLeave = true;
            this.MTxtNit.Location = new System.Drawing.Point(886, 209);
            this.MTxtNit.Mask = "0000-000000-000-0";
            this.MTxtNit.Name = "MTxtNit";
            this.MTxtNit.PromptChar = '-';
            this.MTxtNit.Size = new System.Drawing.Size(202, 27);
            this.MTxtNit.TabIndex = 15;
            this.MTxtNit.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // CmbDepartamentos
            // 
            this.CmbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDepartamentos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbDepartamentos.FormattingEnabled = true;
            this.CmbDepartamentos.Items.AddRange(new object[] {
            "-- Seleccionar --",
            "Ahuachapán",
            "Santa Ana",
            "Sonsonate",
            "Usulután",
            "San Miguel",
            "Morazán",
            "La Unión",
            "La Paz",
            "Cabañas",
            "San Vicente",
            "La Libertad",
            "Chalatenango",
            "Cuscatlán",
            "San Salvador"});
            this.CmbDepartamentos.Location = new System.Drawing.Point(168, 164);
            this.CmbDepartamentos.Name = "CmbDepartamentos";
            this.CmbDepartamentos.Size = new System.Drawing.Size(200, 28);
            this.CmbDepartamentos.TabIndex = 10;
            // 
            // CmbCargos
            // 
            this.CmbCargos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCargos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbCargos.FormattingEnabled = true;
            this.CmbCargos.Location = new System.Drawing.Point(886, 258);
            this.CmbCargos.Name = "CmbCargos";
            this.CmbCargos.Size = new System.Drawing.Size(202, 28);
            this.CmbCargos.TabIndex = 16;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtDireccion.Location = new System.Drawing.Point(886, 116);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(202, 27);
            this.TxtDireccion.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(824, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Cargo :";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtEmail.Location = new System.Drawing.Point(886, 164);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(202, 27);
            this.TxtEmail.TabIndex = 12;
            // 
            // CmbMunicipios
            // 
            this.CmbMunicipios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMunicipios.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbMunicipios.FormattingEnabled = true;
            this.CmbMunicipios.Items.AddRange(new object[] {
            "-- Seleccionar --",
            "Candelaria de la Frontera",
            "Chalchuapa",
            "Coatepeque",
            "El Congo",
            "El Porvenir",
            "Masahuat",
            "Metapán",
            "San Antonio Pajonal",
            "San Sebastián Salitrillo",
            "Santa Ana",
            "Santa Rosa Guachipilín",
            "Santiago de la Frontera",
            "Texistepeque"});
            this.CmbMunicipios.Location = new System.Drawing.Point(534, 161);
            this.CmbMunicipios.Name = "CmbMunicipios";
            this.CmbMunicipios.Size = new System.Drawing.Size(200, 28);
            this.CmbMunicipios.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(821, 167);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 20);
            this.label16.TabIndex = 30;
            this.label16.Text = "E-mail :";
            // 
            // CmbGeneros
            // 
            this.CmbGeneros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGeneros.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbGeneros.FormattingEnabled = true;
            this.CmbGeneros.Items.AddRange(new object[] {
            "-- Seleccionar --",
            "Femenino",
            "Masculino"});
            this.CmbGeneros.Location = new System.Drawing.Point(534, 113);
            this.CmbGeneros.Name = "CmbGeneros";
            this.CmbGeneros.Size = new System.Drawing.Size(200, 28);
            this.CmbGeneros.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(442, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = " Municipio :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(460, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 20);
            this.label15.TabIndex = 28;
            this.label15.Text = " Genero :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(837, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = " NIT :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(483, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = " DUI :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(797, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = " Dirección :";
            // 
            // TxtSNombre
            // 
            this.TxtSNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtSNombre.Location = new System.Drawing.Point(534, 20);
            this.TxtSNombre.Name = "TxtSNombre";
            this.TxtSNombre.Size = new System.Drawing.Size(200, 27);
            this.TxtSNombre.TabIndex = 2;
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
            this.BtnLimpiarControles.Location = new System.Drawing.Point(1016, 315);
            this.BtnLimpiarControles.Name = "BtnLimpiarControles";
            this.BtnLimpiarControles.Size = new System.Drawing.Size(114, 35);
            this.BtnLimpiarControles.TabIndex = 36;
            this.BtnLimpiarControles.Text = "Limpiar";
            this.BtnLimpiarControles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimpiarControles.UseVisualStyleBackColor = false;
            // 
            // ErrPControles
            // 
            this.ErrPControles.ContainerControl = this;
            // 
            // DtpFNacimiento
            // 
            this.DtpFNacimiento.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtpFNacimiento.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DtpFNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFNacimiento.Location = new System.Drawing.Point(168, 114);
            this.DtpFNacimiento.MaxDate = new System.DateTime(2021, 4, 27, 0, 0, 0, 0);
            this.DtpFNacimiento.Name = "DtpFNacimiento";
            this.DtpFNacimiento.Size = new System.Drawing.Size(200, 27);
            this.DtpFNacimiento.TabIndex = 7;
            this.DtpFNacimiento.Value = new System.DateTime(2021, 4, 19, 12, 32, 5, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MTxtTelefono);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.MTxtDui);
            this.groupBox1.Controls.Add(this.MTxtNit);
            this.groupBox1.Controls.Add(this.CmbDepartamentos);
            this.groupBox1.Controls.Add(this.CmbCargos);
            this.groupBox1.Controls.Add(this.TxtDireccion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.CmbMunicipios);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.CmbGeneros);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.TxtSNombre);
            this.groupBox1.Controls.Add(this.DtpFNacimiento);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TxtTApellido);
            this.groupBox1.Controls.Add(this.TxtTNombre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtSApellido);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtPApellido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtPNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1118, 297);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(6, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Fecha de Nacimiento :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(45, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = " Departamento :";
            // 
            // TxtTApellido
            // 
            this.TxtTApellido.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtTApellido.Location = new System.Drawing.Point(886, 68);
            this.TxtTApellido.Name = "TxtTApellido";
            this.TxtTApellido.Size = new System.Drawing.Size(202, 27);
            this.TxtTApellido.TabIndex = 6;
            // 
            // TxtTNombre
            // 
            this.TxtTNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtTNombre.Location = new System.Drawing.Point(886, 20);
            this.TxtTNombre.Name = "TxtTNombre";
            this.TxtTNombre.Size = new System.Drawing.Size(202, 27);
            this.TxtTNombre.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(763, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tercer Apellido :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(767, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tercer Nombre :";
            // 
            // TxtSApellido
            // 
            this.TxtSApellido.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtSApellido.Location = new System.Drawing.Point(534, 68);
            this.TxtSApellido.Name = "TxtSApellido";
            this.TxtSApellido.Size = new System.Drawing.Size(200, 27);
            this.TxtSApellido.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(392, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Segundo Apellido :";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(434, -206);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(165, 27);
            this.textBox3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(235, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(42, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Primer Apellido :";
            // 
            // TxtPApellido
            // 
            this.TxtPApellido.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPApellido.Location = new System.Drawing.Point(168, 68);
            this.TxtPApellido.Name = "TxtPApellido";
            this.TxtPApellido.Size = new System.Drawing.Size(200, 27);
            this.TxtPApellido.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(394, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Segundo Nombre :";
            // 
            // TxtPNombre
            // 
            this.TxtPNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPNombre.Location = new System.Drawing.Point(168, 20);
            this.TxtPNombre.Name = "TxtPNombre";
            this.TxtPNombre.Size = new System.Drawing.Size(200, 27);
            this.TxtPNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(44, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primer Nombre :";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(417, 109);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 28);
            this.comboBox1.TabIndex = 37;
            // 
            // BtnGuardarCambios
            // 
            this.BtnGuardarCambios.BackColor = System.Drawing.Color.White;
            this.BtnGuardarCambios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnGuardarCambios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarCambios.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGuardarCambios.ForeColor = System.Drawing.Color.Black;
            this.BtnGuardarCambios.Image = global::WindowsFormsUI.Properties.Resources.floppy_disk;
            this.BtnGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardarCambios.Location = new System.Drawing.Point(898, 315);
            this.BtnGuardarCambios.Name = "BtnGuardarCambios";
            this.BtnGuardarCambios.Size = new System.Drawing.Size(112, 35);
            this.BtnGuardarCambios.TabIndex = 38;
            this.BtnGuardarCambios.Text = "Guardar";
            this.BtnGuardarCambios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardarCambios.UseVisualStyleBackColor = false;
            this.BtnGuardarCambios.Click += new System.EventHandler(this.BtnGuardarCambios_Click);
            // 
            // FrmEditarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1142, 363);
            this.Controls.Add(this.BtnGuardarCambios);
            this.Controls.Add(this.BtnLimpiarControles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.MaximizeBox = false;
            this.Name = "FrmEditarEmpleado";
            this.Text = "Cooperativa AZOC de R. L. - Editar datos de empleado";
            this.Load += new System.EventHandler(this.FrmEditarEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrPControles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox MTxtTelefono;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox MTxtDui;
        private System.Windows.Forms.MaskedTextBox MTxtNit;
        private System.Windows.Forms.ComboBox CmbDepartamentos;
        private System.Windows.Forms.ComboBox CmbCargos;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.ComboBox CmbMunicipios;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CmbGeneros;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtSNombre;
        private System.Windows.Forms.Button BtnLimpiarControles;
        private System.Windows.Forms.ErrorProvider ErrPControles;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DateTimePicker DtpFNacimiento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtTApellido;
        private System.Windows.Forms.TextBox TxtTNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtSApellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnGuardarCambios;
    }
}