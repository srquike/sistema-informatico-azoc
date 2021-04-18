
namespace WindowsFormsUI.Formularios
{
    partial class FrmInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicioSesion));
            this.BtnIngresar = new System.Windows.Forms.Button();
            this.PctLogo = new System.Windows.Forms.PictureBox();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.ChkVerClave = new System.Windows.Forms.CheckBox();
            this.LLblRecuperarClave = new System.Windows.Forms.LinkLabel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.ErrPNombreUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.MTxtUsuario = new System.Windows.Forms.MaskedTextBox();
            this.ErrPClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPNombreUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.BackColor = System.Drawing.Color.White;
            this.BtnIngresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIngresar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnIngresar.ForeColor = System.Drawing.Color.Black;
            this.BtnIngresar.Image = global::WindowsFormsUI.Properties.Resources.log_in;
            this.BtnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIngresar.Location = new System.Drawing.Point(432, 109);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(118, 35);
            this.BtnIngresar.TabIndex = 4;
            this.BtnIngresar.Text = "Ingresar";
            this.BtnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIngresar.UseVisualStyleBackColor = false;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            this.BtnIngresar.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BtnIngresar.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // PctLogo
            // 
            this.PctLogo.Image = ((System.Drawing.Image)(resources.GetObject("PctLogo.Image")));
            this.PctLogo.Location = new System.Drawing.Point(12, 12);
            this.PctLogo.Name = "PctLogo";
            this.PctLogo.Size = new System.Drawing.Size(346, 132);
            this.PctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctLogo.TabIndex = 6;
            this.PctLogo.TabStop = false;
            // 
            // TxtClave
            // 
            this.TxtClave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ErrPClave.SetIconPadding(this.TxtClave, 5);
            this.TxtClave.Location = new System.Drawing.Point(394, 45);
            this.TxtClave.MaxLength = 50;
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.PlaceholderText = "Escriba la contraseña del usuario";
            this.TxtClave.Size = new System.Drawing.Size(280, 27);
            this.TxtClave.TabIndex = 1;
            this.TxtClave.UseSystemPasswordChar = true;
            // 
            // ChkVerClave
            // 
            this.ChkVerClave.AutoSize = true;
            this.ChkVerClave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChkVerClave.Location = new System.Drawing.Point(394, 75);
            this.ChkVerClave.Name = "ChkVerClave";
            this.ChkVerClave.Size = new System.Drawing.Size(125, 24);
            this.ChkVerClave.TabIndex = 2;
            this.ChkVerClave.Text = "Ver contraseña";
            this.ChkVerClave.UseVisualStyleBackColor = true;
            this.ChkVerClave.CheckedChanged += new System.EventHandler(this.ChkVerClave_CheckedChanged);
            // 
            // LLblRecuperarClave
            // 
            this.LLblRecuperarClave.AutoSize = true;
            this.LLblRecuperarClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LLblRecuperarClave.Location = new System.Drawing.Point(553, 75);
            this.LLblRecuperarClave.Name = "LLblRecuperarClave";
            this.LLblRecuperarClave.Size = new System.Drawing.Size(121, 15);
            this.LLblRecuperarClave.TabIndex = 3;
            this.LLblRecuperarClave.TabStop = true;
            this.LLblRecuperarClave.Text = "Recuperar contraseña";
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
            this.BtnCancelar.Location = new System.Drawing.Point(556, 109);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(118, 35);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            this.BtnCancelar.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BtnCancelar.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ErrPNombreUsuario
            // 
            this.ErrPNombreUsuario.ContainerControl = this;
            // 
            // MTxtUsuario
            // 
            this.MTxtUsuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ErrPNombreUsuario.SetIconPadding(this.MTxtUsuario, 5);
            this.MTxtUsuario.Location = new System.Drawing.Point(394, 12);
            this.MTxtUsuario.Mask = "00000000-0";
            this.MTxtUsuario.Name = "MTxtUsuario";
            this.MTxtUsuario.PromptChar = '-';
            this.MTxtUsuario.Size = new System.Drawing.Size(280, 27);
            this.MTxtUsuario.TabIndex = 0;
            // 
            // ErrPClave
            // 
            this.ErrPClave.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsUI.Properties.Resources.user24px;
            this.pictureBox1.Location = new System.Drawing.Point(364, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsUI.Properties.Resources.key;
            this.pictureBox2.Location = new System.Drawing.Point(364, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // FrmInicioSesion
            // 
            this.AcceptButton = this.BtnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(700, 157);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MTxtUsuario);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LLblRecuperarClave);
            this.Controls.Add(this.ChkVerClave);
            this.Controls.Add(this.TxtClave);
            this.Controls.Add(this.PctLogo);
            this.Controls.Add(this.BtnIngresar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "FrmInicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cooperativa AZOC de R. L. - Inicio de sesión";
            this.Load += new System.EventHandler(this.FrmInicioSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPNombreUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnIngresar;
        private System.Windows.Forms.PictureBox PctLogo;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.CheckBox ChkVerClave;
        private System.Windows.Forms.LinkLabel LLblRecuperarClave;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ErrorProvider ErrPNombreUsuario;
        private System.Windows.Forms.ErrorProvider ErrPClave;
        private System.Windows.Forms.MaskedTextBox MTxtUsuario;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}