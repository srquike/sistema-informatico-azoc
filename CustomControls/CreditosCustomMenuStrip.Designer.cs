
namespace CustomControls
{
    partial class CreditosCustomMenuStrip
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditosCustomMenuStrip));
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnAsociados = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCreditos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(9, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(23, 58);
            this.panel2.TabIndex = 16;
            // 
            // BtnAsociados
            // 
            this.BtnAsociados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.BtnAsociados.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnAsociados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnAsociados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAsociados.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAsociados.ForeColor = System.Drawing.Color.White;
            this.BtnAsociados.Image = ((System.Drawing.Image)(resources.GetObject("BtnAsociados.Image")));
            this.BtnAsociados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAsociados.Location = new System.Drawing.Point(40, 81);
            this.BtnAsociados.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAsociados.Name = "BtnAsociados";
            this.BtnAsociados.Size = new System.Drawing.Size(177, 58);
            this.BtnAsociados.TabIndex = 15;
            this.BtnAsociados.Text = "Asociados";
            this.BtnAsociados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAsociados.UseVisualStyleBackColor = false;
            this.BtnAsociados.MouseEnter += new System.EventHandler(this.CustomButton_MouseEnter);
            this.BtnAsociados.MouseLeave += new System.EventHandler(this.CustomButton_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(9, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(23, 58);
            this.panel1.TabIndex = 14;
            // 
            // BtnCreditos
            // 
            this.BtnCreditos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.BtnCreditos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCreditos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnCreditos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreditos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCreditos.ForeColor = System.Drawing.Color.White;
            this.BtnCreditos.Image = ((System.Drawing.Image)(resources.GetObject("BtnCreditos.Image")));
            this.BtnCreditos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCreditos.Location = new System.Drawing.Point(40, 13);
            this.BtnCreditos.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCreditos.Name = "BtnCreditos";
            this.BtnCreditos.Size = new System.Drawing.Size(177, 58);
            this.BtnCreditos.TabIndex = 13;
            this.BtnCreditos.Text = "Créditos";
            this.BtnCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCreditos.UseVisualStyleBackColor = false;
            this.BtnCreditos.MouseEnter += new System.EventHandler(this.CustomButton_MouseEnter);
            this.BtnCreditos.MouseLeave += new System.EventHandler(this.CustomButton_MouseLeave);
            // 
            // CreditosCustomMenuStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnAsociados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnCreditos);
            this.Name = "CreditosCustomMenuStrip";
            this.Size = new System.Drawing.Size(225, 151);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnAsociados;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button BtnCreditos;
    }
}
