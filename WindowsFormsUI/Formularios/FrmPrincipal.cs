using BusinessObjectsLayer.Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private Usuario _usuario;

        public FrmPrincipal(Usuario usuario)
        {
            _usuario = usuario;

            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            string nombreEmpleado = $"{_usuario.Empleado.PrimerNombre} {_usuario.Empleado.SegundoNombre} {_usuario.Empleado.TercerNombre} {_usuario.Empleado.PrimerApellido} {_usuario.Empleado.SegundoApellido} {_usuario.Empleado.TercerApellido}";

            if (_usuario.Empleado.Genero == "M")
            {
                LblSaludo.Text = "BIENVENIDO";
            }
            else if (_usuario.Empleado.Genero == "F")
            {
                LblSaludo.Text = "BIENVENIDA";
            }

            TxtNombreEmpleado.Text = nombreEmpleado;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir del sistema?", "Cerrar sesión: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir del sistema?", "Cerrar sesión: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUsuarios usuarios = new FrmUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }
    }
}
