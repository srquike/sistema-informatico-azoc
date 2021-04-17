using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmInicioSesion : Form
    {
        private UsuarioBLL _usuario;

        public Usuario Usuario { get; set; }

        public FrmInicioSesion()
        {
            InitializeComponent();

            _usuario = new UsuarioBLL();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (IsUsuarioValido())
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("El usuario no existe!");
                DialogResult = DialogResult.Retry;
            }
        }

        private bool IsUsuarioValido()
        {
            string userName, password;

            userName = TxtUsuario.Text;
            password = TxtClave.Text;

            Usuario usuario = _usuario.Authentication(userName, password);

            if (usuario != null)
            {
                return true;
            }

            return false;
        }
    }
}
