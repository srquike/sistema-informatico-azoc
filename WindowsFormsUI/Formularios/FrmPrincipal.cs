using BusinessObjectsLayer.Models;
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

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

            string nombreAvatar = _usuario.Nombre + ".jpg";
            string ruta = @"C:\Users\Jonathan Vanegas\source\repos\SistemaInformaticoAZOC\WindowsFormsUI\Resources\Imagenes\";
            string archivo = string.Concat(ruta, nombreAvatar);

            if (File.Exists(archivo))
            {
                PctAvatar.Image = Image.FromFile(archivo);
            }

            if (_usuario.Empleado.Genero == "M")
            {
                LblSaludo.Text = "BIENVENIDO";
                PctAvatar.Image = Properties.Resources.male_avatar_default;
            }
            else if (_usuario.Empleado.Genero == "F")
            {
                LblSaludo.Text = "BIENVENIDA";
                PctAvatar.Image = Properties.Resources.female_avatar_default;
            }

            TxtNombreEmpleado.Text = nombreEmpleado;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUsuarios usuarios = new FrmUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }
    }
}
