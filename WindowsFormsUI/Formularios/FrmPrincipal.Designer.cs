
namespace WindowsFormsUI.Formularios
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.PnlBarraLateral = new System.Windows.Forms.Panel();
            this.TxtNombreEmpleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.BtnConfiguracion = new System.Windows.Forms.Button();
            this.PctAvatar = new System.Windows.Forms.PictureBox();
            this.PctLogo = new System.Windows.Forms.PictureBox();
            this.PnlBarraLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBarraLateral
            // 
            this.PnlBarraLateral.BackColor = System.Drawing.Color.White;
            this.PnlBarraLateral.Controls.Add(this.TxtNombreEmpleado);
            this.PnlBarraLateral.Controls.Add(this.label1);
            this.PnlBarraLateral.Controls.Add(this.BtnCerrarSesion);
            this.PnlBarraLateral.Controls.Add(this.BtnConfiguracion);
            this.PnlBarraLateral.Controls.Add(this.PctAvatar);
            this.PnlBarraLateral.Controls.Add(this.PctLogo);
            this.PnlBarraLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlBarraLateral.Location = new System.Drawing.Point(0, 0);
            this.PnlBarraLateral.Name = "PnlBarraLateral";
            this.PnlBarraLateral.Size = new System.Drawing.Size(230, 683);
            this.PnlBarraLateral.TabIndex = 1;
            // 
            // TxtNombreEmpleado
            // 
            this.TxtNombreEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNombreEmpleado.Location = new System.Drawing.Point(12, 246);
            this.TxtNombreEmpleado.Multiline = true;
            this.TxtNombreEmpleado.Name = "TxtNombreEmpleado";
            this.TxtNombreEmpleado.Size = new System.Drawing.Size(206, 62);
            this.TxtNombreEmpleado.TabIndex = 6;
            this.TxtNombreEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(70, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "BIENVENIDO(A)";
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.Location = new System.Drawing.Point(61, 343);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(109, 23);
            this.BtnCerrarSesion.TabIndex = 4;
            this.BtnCerrarSesion.Text = "Cerrar sesión";
            this.BtnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // BtnConfiguracion
            // 
            this.BtnConfiguracion.Location = new System.Drawing.Point(61, 314);
            this.BtnConfiguracion.Name = "BtnConfiguracion";
            this.BtnConfiguracion.Size = new System.Drawing.Size(109, 23);
            this.BtnConfiguracion.TabIndex = 3;
            this.BtnConfiguracion.Text = "Configuracion";
            this.BtnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // PctAvatar
            // 
            this.PctAvatar.Image = global::WindowsFormsUI.Properties.Resources.user;
            this.PctAvatar.Location = new System.Drawing.Point(12, 138);
            this.PctAvatar.Name = "PctAvatar";
            this.PctAvatar.Size = new System.Drawing.Size(206, 77);
            this.PctAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctAvatar.TabIndex = 1;
            this.PctAvatar.TabStop = false;
            // 
            // PctLogo
            // 
            this.PctLogo.Image = ((System.Drawing.Image)(resources.GetObject("PctLogo.Image")));
            this.PctLogo.Location = new System.Drawing.Point(12, 12);
            this.PctLogo.Name = "PctLogo";
            this.PctLogo.Size = new System.Drawing.Size(206, 77);
            this.PctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctLogo.TabIndex = 0;
            this.PctLogo.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 683);
            this.Controls.Add(this.PnlBarraLateral);
            this.IsMdiContainer = true;
            this.Name = "FrmPrincipal";
            this.Text = "Cooperativa AZOC de R. L. :: Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.PnlBarraLateral.ResumeLayout(false);
            this.PnlBarraLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlBarraLateral;
        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.Button BtnConfiguracion;
        private System.Windows.Forms.PictureBox PctAvatar;
        private System.Windows.Forms.PictureBox PctLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombreEmpleado;
    }
}