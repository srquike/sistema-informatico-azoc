using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmInicioSesion : Form
    {
        private UsuarioBLL _usuarioLogic;
        private readonly RegistroUsuarioBLL _registroUsuarioLogic;
        private Usuario _usuarioLogin;
        private const string archivoConfiguracion = @"Configuracion\configuracion.bin";

        public FrmInicioSesion()
        {
            InitializeComponent();

            _usuarioLogic = new UsuarioBLL();
            _registroUsuarioLogic = new RegistroUsuarioBLL();
        }

        private bool ValidarEntradas()
        {
            if (MTxtUsuario.MaskFull != true)
            {
                ErrPNombreUsuario.SetError(MTxtUsuario, "Por favor, ingrese el nombre de usuario para continuar!");
            }
            else
            {
                ErrPNombreUsuario.Clear();

                if (string.IsNullOrEmpty(TxtClave.Text))
                {
                    ErrPClave.SetError(TxtClave, "Por favor, ingrese la contraseña del usuario para continuar!");
                }
                else
                {
                    ErrPClave.Clear();
                    return true;
                }
            }

            return false;
        }

        private bool AutenticarUsuario(string password, string nombre)
        {
            Usuario usuario = _usuarioLogic.Authentication(password, nombre);

            if (usuario != null)
            {
                if (usuario.Estado != '0')
                {
                    _usuarioLogin = usuario;
                    _usuarioLogin.UltimoAcceso = DateTime.Now;

                    _usuarioLogic.Edit(_usuarioLogin, false);

                    return true;
                }
                else
                {
                    MessageBox.Show("El usuario esta desactivado actualmente. Solicite al administrador que lo active.", "Inicio de sesión: Usuario desactivado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarControles();
                }
            }
            else
            {
                MessageBox.Show("El nombre de usuario o contraseña es incorrecto, por favor vuelva a ingresarlos", "Inicio de sesión: Error de usuario o contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarControles();
            }

            return false;
        }

        private void LimpiarControles()
        {
            MTxtUsuario.Clear();
            TxtClave.Clear();
            ChkVerClave.Checked = false;
            MTxtUsuario.Focus();
        }

        private bool AutenticarUsuarioAdministrador(string clave, string nombre)
        {
            if (File.Exists(archivoConfiguracion))
            {
                string claveConfig;
                string nombreConfig;

                using (FileStream stream = new FileStream(archivoConfiguracion, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        claveConfig = reader.ReadString();
                        nombreConfig = reader.ReadString();

                        if (claveConfig.Equals(clave) && nombreConfig.Equals(nombre))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarEntradas())
            {
                string password = TxtClave.Text;
                string nombre = MTxtUsuario.Text;

                if (ChkAdministrador.Checked)
                {
                    if (AutenticarUsuarioAdministrador(password, nombre))
                    {
                        MostrarFormularioPrincipal();
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar autenticar usuario administrador", "Autenticar usuario: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (AutenticarUsuario(password, nombre))
                    {
                        RegistroUsuario registro = new RegistroUsuario
                        {
                            UsuarioId = _usuarioLogin.UsuarioId,
                            RegistroId = 1,
                            Fecha = DateTime.Now,
                            Informacion = $"Inicio de sesión del usuario {_usuarioLogin.Nombre}"
                        };

                        if (_registroUsuarioLogic.Create(registro) == false)
                        {
                            MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        MostrarFormularioPrincipal();
                    }
                }
            }
        }

        private void MostrarFormularioPrincipal()
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal(_usuarioLogin);
            Hide();
            frmPrincipal.ShowDialog();

            if (frmPrincipal.DialogResult == DialogResult.Abort)
            {
                frmPrincipal.Dispose();
                Show();
                LimpiarControles();
            }
        }

        private void ChkVerClave_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.Checked)
            {
                TxtClave.UseSystemPasswordChar = false;
            }
            else
            {
                TxtClave.UseSystemPasswordChar = true;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.icon;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Black;
        }

        private void LLblRecuperarClave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRecuperararClave frmRecuperararClave = new FrmRecuperararClave();
            frmRecuperararClave.StartPosition = FormStartPosition.CenterParent;
            frmRecuperararClave.MTxtNombre.Text = !string.IsNullOrEmpty(MTxtUsuario.Text) ? MTxtUsuario.Text : string.Empty;
            frmRecuperararClave.ShowDialog();

            if (frmRecuperararClave.DialogResult == DialogResult.OK)
            {
                frmRecuperararClave.Close();
                TxtClave.Clear();
                MTxtUsuario.Focus();
            }
        }
    }
}