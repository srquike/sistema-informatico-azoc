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
            Autenticar();
            DialogResult = DialogResult.OK;
        }

        private void Autenticar()
        {
            string userName, password;

            userName = TxtUsuario.Text;
            password = TxtClave.Text;

            Usuario = _usuario.Authentication(userName, password);
        }
    }
}
