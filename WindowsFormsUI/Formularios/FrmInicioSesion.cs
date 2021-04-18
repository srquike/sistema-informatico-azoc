using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmInicioSesion : Form
    {
        private UsuarioBLL _usuarioLogic;
        public Usuario UsuarioLogIn;

        public FrmInicioSesion()
        {
            InitializeComponent();

            _usuarioLogic = new UsuarioBLL();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string userName = TxtUsuario.Text;
            string password = TxtClave.Text;

            Usuario usuario = _usuarioLogic.Authentication(userName, password);

            if (usuario != null)
            {
                UsuarioLogIn = usuario;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("El usuario solicitado no exites!");
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
    }
}
