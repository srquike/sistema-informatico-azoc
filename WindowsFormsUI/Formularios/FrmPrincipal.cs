using BusinessObjectsLayer.Models;
using BusinessLogicLayer.Logics;
using CustomControls;
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private Usuario _usuario;
        private RegistroUsuarioBLL _registroUsuarioLogic;
        private AdministracionCustomMenuStrip administracionCustomMenuStrip;
        private CreditosCustomMenuStrip creditosCustomMenuStrip;

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            CargarControlesPersonalizados();

            _usuario = usuario;
            _registroUsuarioLogic = new RegistroUsuarioBLL();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (_usuario != null)
            {
                string nombreEmpleado = $"{_usuario.Empleado.PrimerNombre} {_usuario.Empleado.SegundoNombre} {_usuario.Empleado.TercerNombre} {_usuario.Empleado.PrimerApellido} {_usuario.Empleado.SegundoApellido} {_usuario.Empleado.TercerApellido}";

                string extension = ".jpg";
                string ruta = @"C:\Users\Jonathan Vanegas\source\repos\SistemaInformaticoAZOC\WindowsFormsUI\Resources\Imagenes\";
                string archivo = string.Concat(ruta, _usuario.Nombre, extension);

                if (File.Exists(archivo))
                {
                    using (FileStream fileStream = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                    {
                        PctAvatar.Image = Image.FromStream(fileStream);
                    }
                }
                else
                {
                    PctAvatar.Image = _usuario.Empleado.Genero == "F" 
                        ? Properties.Resources.female_avatar_default
                        : Properties.Resources.male_avatar_default;
                }

                LblSaludo.Text = _usuario.Empleado.Genero == "F" ? "BIENVENIDA" : "BIENVENIDO";

                TxtNombreEmpleado.Text = nombreEmpleado;
            }
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir del sistema?", "Cerrar sesión: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if (_usuario != null)
                {
                    RegistroUsuario registro = new RegistroUsuario
                    {
                        UsuarioId = _usuario.UsuarioId,
                        RegistroId = 2,
                        Fecha = DateTime.Now,
                        Informacion = $"Cierre de sesión del usuario {_usuario.Nombre}"
                    };

                    _registroUsuarioLogic.Create(registro);
                }
            }
        }

        private void CargarControlesPersonalizados()
        {
            administracionCustomMenuStrip = new AdministracionCustomMenuStrip();
            administracionCustomMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            administracionCustomMenuStrip.Location = new System.Drawing.Point(236, 424);
            administracionCustomMenuStrip.Name = "administracionCustomMenuStrip";
            administracionCustomMenuStrip.Size = new System.Drawing.Size(225, 151);
            administracionCustomMenuStrip.TabIndex = 15;
            administracionCustomMenuStrip.Visible = false;
            administracionCustomMenuStrip.BtnUsuarios.Click += new EventHandler(BtnUsuarios_Click);
            administracionCustomMenuStrip.BtnEmpleados.Click += new EventHandler(BtnEmpleados_Click);
            administracionCustomMenuStrip.Leave += new EventHandler(AdministracionCustomMenuStrip_Leave);

            creditosCustomMenuStrip = new CreditosCustomMenuStrip();
            creditosCustomMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            creditosCustomMenuStrip.Location = new System.Drawing.Point(236, 488);
            creditosCustomMenuStrip.Name = "creditosCustomMenuStrip";
            creditosCustomMenuStrip.Size = new System.Drawing.Size(225, 151);
            creditosCustomMenuStrip.TabIndex = 17;
            creditosCustomMenuStrip.Visible = false;
            creditosCustomMenuStrip.BtnCreditos.Click += new EventHandler(BtnCreditos_Click);
            creditosCustomMenuStrip.BtnAsociados.Click += new EventHandler(BtnAsociados_Click);
            creditosCustomMenuStrip.Leave += new EventHandler(CreditosCustomMenuStrip_Leave);


            Controls.Add(administracionCustomMenuStrip);
            Controls.Add(creditosCustomMenuStrip);
        }

        #region Eventos de los controles personalizados

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            administracionCustomMenuStrip.Visible = false;

            FrmUsuarios frmUsuarios = new FrmUsuarios(_usuario);
            frmUsuarios.MdiParent = this;
            frmUsuarios.Show();
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            administracionCustomMenuStrip.Visible = false;

            FrmEmpleados frmEmpleados = new FrmEmpleados();
            frmEmpleados.MdiParent = this;
            frmEmpleados.Show();
        }

        private void BtnCreditos_Click(object sender, EventArgs e)
        {
            creditosCustomMenuStrip.Visible = false;

            FrmCreditos frmCreditos = new FrmCreditos();
            frmCreditos.MdiParent = this;
            frmCreditos.Show();
        }

        private void BtnAsociados_Click(object sender, EventArgs e)
        {
            creditosCustomMenuStrip.Visible = false;

            FrmAsociados frmAsociados = new FrmAsociados();
            frmAsociados.MdiParent = this;
            frmAsociados.Show();
        }

        private void AdministracionCustomMenuStrip_Leave(object sender, EventArgs e)
        {
            administracionCustomMenuStrip.Visible = false;
        }

        private void CreditosCustomMenuStrip_Leave(object sender, EventArgs e)
        {
            creditosCustomMenuStrip.Visible = false;
        }

        #endregion

        private void BtnAdministracion_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
        }

        private void BtnAdministracion_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Black;
        }

        private void BtnCreditos_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;           
        }

        private void BtnCreditos_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Black;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Black;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
        }

        private void BtnAdministracion_Click(object sender, EventArgs e)
        {
            administracionCustomMenuStrip.Visible = true;
            administracionCustomMenuStrip.Focus();
        }

        private void BtnCreditos_Click_1(object sender, EventArgs e)
        {
            creditosCustomMenuStrip.Visible = true;
            creditosCustomMenuStrip.Focus();
        }

        private void TSMIAcercaDe_Click(object sender, EventArgs e)
        {
            FrmAcercaDe frmAcercaDe = new FrmAcercaDe();
            frmAcercaDe.StartPosition = FormStartPosition.CenterScreen;
            frmAcercaDe.ShowDialog();

            if (frmAcercaDe.DialogResult == DialogResult.OK)
            {
                frmAcercaDe.Close();
            }
        }

        private void BtnConfiguracion_Click(object sender, EventArgs e)
        {
            FrmConfiguracion frmConfiguracion = new FrmConfiguracion();
            frmConfiguracion.StartPosition = FormStartPosition.CenterScreen;
            frmConfiguracion.ShowDialog();

            if (frmConfiguracion.DialogResult == DialogResult.OK)
            {
                
            }
        }
    }
}