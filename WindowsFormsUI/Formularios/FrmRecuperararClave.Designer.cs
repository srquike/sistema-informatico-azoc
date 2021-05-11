
namespace WindowsFormsUI.Formularios
{
    partial class FrmRecuperararClave
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtPregunta3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPregunta2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPregunta1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnIngresar = new System.Windows.Forms.Button();
            this.MTxtNombre = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtPregunta3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtPregunta2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtPregunta1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 157);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preguntas";
            // 
            // TxtPregunta3
            // 
            this.TxtPregunta3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPregunta3.Location = new System.Drawing.Point(352, 118);
            this.TxtPregunta3.Name = "TxtPregunta3";
            this.TxtPregunta3.PlaceholderText = "Escribe la respuesta";
            this.TxtPregunta3.Size = new System.Drawing.Size(321, 27);
            this.TxtPregunta3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "3. ¿Cuál era tu apodo de infancia?";
            // 
            // TxtPregunta2
            // 
            this.TxtPregunta2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPregunta2.Location = new System.Drawing.Point(352, 69);
            this.TxtPregunta2.Name = "TxtPregunta2";
            this.TxtPregunta2.PlaceholderText = "Escribe la respuesta";
            this.TxtPregunta2.Size = new System.Drawing.Size(321, 27);
            this.TxtPregunta2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "2. ¿Cuál es el nombre de la ciudad donde naciste?";
            // 
            // TxtPregunta1
            // 
            this.TxtPregunta1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPregunta1.Location = new System.Drawing.Point(352, 20);
            this.TxtPregunta1.Name = "TxtPregunta1";
            this.TxtPregunta1.PlaceholderText = "Escribe la respuesta";
            this.TxtPregunta1.Size = new System.Drawing.Size(321, 27);
            this.TxtPregunta1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "1. ¿Cuál fue el nombre de tu primera mascota?";
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.BackColor = System.Drawing.Color.White;
            this.BtnIngresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(103)))));
            this.BtnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIngresar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnIngresar.ForeColor = System.Drawing.Color.Black;
            this.BtnIngresar.Image = global::WindowsFormsUI.Properties.Resources.data_recovery;
            this.BtnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIngresar.Location = new System.Drawing.Point(502, 202);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(189, 35);
            this.BtnIngresar.TabIndex = 5;
            this.BtnIngresar.Text = "Recuperar contraseña";
            this.BtnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIngresar.UseVisualStyleBackColor = false;
            // 
            // MTxtNombre
            // 
            this.MTxtNombre.HidePromptOnLeave = true;
            this.MTxtNombre.Location = new System.Drawing.Point(162, 6);
            this.MTxtNombre.Mask = "00000000-0";
            this.MTxtNombre.Name = "MTxtNombre";
            this.MTxtNombre.PromptChar = '-';
            this.MTxtNombre.Size = new System.Drawing.Size(529, 27);
            this.MTxtNombre.TabIndex = 6;
            this.MTxtNombre.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // FrmRecuperararClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(703, 245);
            this.Controls.Add(this.MTxtNombre);
            this.Controls.Add(this.BtnIngresar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRecuperararClave";
            this.Text = "Cooperativa AZOC de R. L.  - Recuperación de contraseña";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtPregunta3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtPregunta2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPregunta1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnIngresar;
        private System.Windows.Forms.MaskedTextBox MTxtNombre;
    }
}