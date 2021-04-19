using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmEditarUsuario : Form
    {

        private Usuario _usuario;
        private UsuarioBLL _usuarioLogic;

        public FrmEditarUsuario(Usuario usuario)
        {
            InitializeComponent();

            _usuario = usuario;
            _usuarioLogic = new UsuarioBLL();
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
