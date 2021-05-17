
namespace CustomControls
{
    partial class AdministracionCustomMenuStrip
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministracionCustomMenuStrip));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnUsuarios = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnEmpleados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(9, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(23, 58);
            this.panel1.TabIndex = 10;
            // 
            // BtnUsuarios
            // 
            this.BtnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.BtnUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUsuarios.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnUsuarios.ForeColor = System.Drawing.Color.White;
            this.BtnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("BtnUsuarios.Image")));
            this.BtnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUsuarios.Location = new System.Drawing.Point(38, 13);
            this.BtnUsuarios.Margin = new System.Windows.Forms.Padding(5);
            this.BtnUsuarios.Name = "BtnUsuarios";
            this.BtnUsuarios.Size = new System.Drawing.Size(177, 58);
            this.BtnUsuarios.TabIndex = 9;
            this.BtnUsuarios.Text = "Usuarios";
            this.BtnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUsuarios.UseVisualStyleBackColor = false;
            this.BtnUsuarios.MouseEnter += new System.EventHandler(this.CustomButton_MouseEnter);
            this.BtnUsuarios.MouseLeave += new System.EventHandler(this.CustomButton_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(9, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(23, 58);
            this.panel2.TabIndex = 12;
            // 
            // BtnEmpleados
            // 
            this.BtnEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.BtnEmpleados.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEmpleados.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnEmpleados.ForeColor = System.Drawing.Color.White;
            this.BtnEmpleados.Image = ((System.Drawing.Image)(resources.GetObject("BtnEmpleados.Image")));
            this.BtnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEmpleados.Location = new System.Drawing.Point(38, 81);
            this.BtnEmpleados.Margin = new System.Windows.Forms.Padding(5);
            this.BtnEmpleados.Name = "BtnEmpleados";
            this.BtnEmpleados.Size = new System.Drawing.Size(177, 58);
            this.BtnEmpleados.TabIndex = 11;
            this.BtnEmpleados.Text = "Empleados";
            this.BtnEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEmpleados.UseVisualStyleBackColor = false;
            this.BtnEmpleados.MouseEnter += new System.EventHandler(this.CustomButton_MouseEnter);
            this.BtnEmpleados.MouseLeave += new System.EventHandler(this.CustomButton_MouseLeave);
            // 
            // AdministracionCustomMenuStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnEmpleados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnUsuarios);
            this.Name = "AdministracionCustomMenuStrip";
            this.Size = new System.Drawing.Size(225, 151);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnUsuarios;
        public System.Windows.Forms.Button BtnEmpleados;
    }
}
