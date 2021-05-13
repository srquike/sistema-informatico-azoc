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
        private readonly RegistroUsuarioBLL _registroUsuarioLogic;
        private bool _continuar = false;
        public Usuario UsuarioLogIn;


        public FrmInicioSesion()
        {
            InitializeComponent();

            _usuarioLogic = new UsuarioBLL();
            _registroUsuarioLogic = new RegistroUsuarioBLL();
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

        private void AutenticarUsuario(string password)
        {
            Usuario usuario = _usuarioLogic.Authentication(password);

            if (usuario != null)
            {
                if (usuario.Estado != '0')
                {
                    UsuarioLogIn = usuario;
                    UsuarioLogIn.UltimoAcceso = DateTime.Now;

                    _usuarioLogic.Edit(UsuarioLogIn);

                    RegistroUsuario registro = new RegistroUsuario
                    {
                        UsuarioId = UsuarioLogIn.UsuarioId,
                        RegistroId = 1,
                        Fecha = DateTime.Now,
                        Informacion = $"Inicio de sesión del usuario {UsuarioLogIn.Nombre}"
                    };

                    _registroUsuarioLogic.Create(registro);

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
            //ValidarControles();
            //if (_continuar)
            //{
            //    string user, password;

            //    user = MTxtUsuario.Text;
            //    password = TxtClave.Text;

            //    AutenticarUsuario(password);
            //}

            DialogResult = DialogResult.OK;
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
            }
        }
    }
}
