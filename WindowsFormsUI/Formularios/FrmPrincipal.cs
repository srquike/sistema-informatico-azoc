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
        private Usuario _usuarioLogeado;
        private RegistroUsuarioBLL _registroUsuarioLogic;
        private AdministracionCustomMenuStrip administracionCustomMenuStrip;
        private CreditosCustomMenuStrip creditosCustomMenuStrip;

        #region Inicializar formularios
        private FrmUsuarios _frmUsuarios = null;
        private FrmEmpleados _frmEmpleados = null;
        private FrmCreditos _frmCreditos = null;
        private FrmAsociados _frmAsociados = null;
        #endregion

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            CargarControlesPersonalizados();

            _usuarioLogeado = usuario;
            _registroUsuarioLogic = new RegistroUsuarioBLL();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (_usuarioLogeado != null)
            {
                string nombreEmpleado = $"{_usuarioLogeado.Empleado.PrimerNombre} {_usuarioLogeado.Empleado.SegundoNombre} {_usuarioLogeado.Empleado.TercerNombre} {_usuarioLogeado.Empleado.PrimerApellido} {_usuarioLogeado.Empleado.SegundoApellido} {_usuarioLogeado.Empleado.TercerApellido}";

                string extension = ".jpeg";
                string ruta = @"C:\Users\Jonathan Vanegas\source\repos\srquike\sistema-informatico-azoc\WindowsFormsUI\Resources\Imagenes";
                string archivo = string.Concat(ruta, _usuarioLogeado.Nombre, extension);

                if (File.Exists(archivo))
                {
                    using (FileStream fileStream = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                    {
                        PctAvatar.Image = Image.FromStream(fileStream);
                    }
                }
                else
                {
                    PctAvatar.Image = _usuarioLogeado.Empleado.Genero == "F"
                        ? Properties.Resources.female_avatar_default
                        : Properties.Resources.male_avatar_default;
                }

                LblSaludo.Text = _usuarioLogeado.Empleado.Genero == "F" ? "BIENVENIDA" : "BIENVENIDO";

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
                if (_usuarioLogeado != null)
                {
                    RegistroUsuario registro = new RegistroUsuario
                    {
                        UsuarioId = _usuarioLogeado.UsuarioId,
                        RegistroId = 2,
                        Fecha = DateTime.Now,
                        Informacion = $"Cierre de sesión del usuario {_usuarioLogeado.Nombre}"
                    };

                    if (_registroUsuarioLogic.Create(registro) == false)
                    {
                        MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DialogResult = DialogResult.Abort;
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

            if (_frmUsuarios == null)
            {
                _frmUsuarios = new FrmUsuarios(_usuarioLogeado);
                _frmUsuarios.MdiParent = this;
                _frmUsuarios.FormClosed += new FormClosedEventHandler(FrmUsuarios_Closed);
                _frmUsuarios.Show();
            }
            else
            {
                _frmUsuarios.Activate();
            }
        }

        private void FrmUsuarios_Closed(object sender, EventArgs e)
        {
            _frmUsuarios = null;
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            administracionCustomMenuStrip.Visible = false;

            if (_frmEmpleados == null)
            {
                _frmEmpleados = new FrmEmpleados(_usuarioLogeado);
                _frmEmpleados.MdiParent = this;
                _frmEmpleados.FormClosed += new FormClosedEventHandler(FrmEmpleados_Closed);
                _frmEmpleados.Show();
            }
            else
            {
                _frmEmpleados.Activate();
            }
        }

        private void FrmEmpleados_Closed(object sender, EventArgs e)
        {
            _frmEmpleados = null;
        }

        private void BtnCreditos_Click(object sender, EventArgs e)
        {
            creditosCustomMenuStrip.Visible = false;

            if (_frmCreditos == null)
            {
                _frmCreditos = new FrmCreditos(_usuarioLogeado);
                _frmCreditos.MdiParent = this;
                _frmCreditos.FormClosed += new FormClosedEventHandler(FrmCreditos_Closed);
                _frmCreditos.Show();
            }
            else
            {
                _frmCreditos.Activate();
            }
        }

        private void FrmCreditos_Closed(object sender, EventArgs e)
        {
            _frmCreditos = null;
        }

        private void BtnAsociados_Click(object sender, EventArgs e)
        {
            creditosCustomMenuStrip.Visible = false;

            if (_frmAsociados == null)
            {
                _frmAsociados = new FrmAsociados(_usuarioLogeado);
                _frmAsociados.MdiParent = this;
                _frmAsociados.FormClosed += new FormClosedEventHandler(FrmAsociados_Closed);
                _frmAsociados.Show();
            }
            else
            {
                _frmAsociados.Activate();
            }
        }

        private void FrmAsociados_Closed(object sende, EventArgs e)
        {
            _frmAsociados = null;
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
            if (administracionCustomMenuStrip.Visible == true)
            {
                administracionCustomMenuStrip.Visible = false;
            }
            else if (administracionCustomMenuStrip.Visible == false)
            {
                administracionCustomMenuStrip.Visible = true;
                administracionCustomMenuStrip.Focus();
            }
        }

        private void BtnCreditos_Click_1(object sender, EventArgs e)
        {
            if (creditosCustomMenuStrip.Visible)
            {
                creditosCustomMenuStrip.Visible = false;
            }
            else
            {
                creditosCustomMenuStrip.Visible = true;
                creditosCustomMenuStrip.Focus();
            }
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