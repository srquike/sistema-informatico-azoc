using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmInicioSesion : Form
    {
        private UsuarioBLL _usuarioLogic;
        private bool _continuar = false;
        public Usuario UsuarioLogIn;
        

        public FrmInicioSesion()
        {
            InitializeComponent();

            _usuarioLogic = new UsuarioBLL();
        }

        private void ValidarControles()
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
                    _continuar = true;
                }
            }
        }

        private void AutenticarUsuario(string user, string password)
        {
            Usuario usuario = _usuarioLogic.Authentication(user, password);

            if (usuario != null)
            {
                if (usuario.Estado != '0')
                {
                    UsuarioLogIn = usuario;
                    UsuarioLogIn.UltimoAcceso = DateTime.Now;
                    DialogResult = DialogResult.OK;
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
        }

        private void LimpiarControles()
        {
            MTxtUsuario.Clear();
            TxtClave.Clear();
            ChkVerClave.Checked = false;
            MTxtUsuario.Focus();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            ValidarControles();
            if (_continuar)
            {
                string user, password;

                user = MTxtUsuario.Text.Replace("-", "");
                password = TxtClave.Text;

                AutenticarUsuario(user, password);
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
    }
}
