using BusinessObjectsLayer.Models;
using BusinessLogicLayer.Logics;
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private Usuario _usuario;
        private RegistroUsuarioBLL _registroUsuarioLogic;

        public FrmPrincipal(Usuario usuario)
        {
            _usuario = usuario;

            InitializeComponent();

            _registroUsuarioLogic = new RegistroUsuarioBLL();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //string nombreEmpleado = $"{_usuario.Empleado.PrimerNombre} {_usuario.Empleado.SegundoNombre} {_usuario.Empleado.TercerNombre} {_usuario.Empleado.PrimerApellido} {_usuario.Empleado.SegundoApellido} {_usuario.Empleado.TercerApellido}";

            //string nombreAvatar = _usuario.Nombre + ".jpg";
            //string ruta = @"C:\Users\Jonathan Vanegas\source\repos\SistemaInformaticoAZOC\WindowsFormsUI\Resources\Imagenes\";
            //string archivo = string.Concat(ruta, nombreAvatar);

            //if (File.Exists(archivo))
            //{
            //    PctAvatar.Image = Image.FromFile(archivo);
            //}
            //else
            //{
            //    if (_usuario.Empleado.Genero == "M")
            //    {
            //        PctAvatar.Image = Properties.Resources.male_avatar_default;
            //    }
            //    else if (_usuario.Empleado.Genero == "F")
            //    {
            //        PctAvatar.Image = Properties.Resources.female_avatar_default;
            //    }
            //}

            //if (_usuario.Empleado.Genero == "M")
            //{
            //    LblSaludo.Text = "BIENVENIDO";
            //}
            //else if (_usuario.Empleado.Genero == "F")
            //{
            //    LblSaludo.Text = "BIENVENIDA";
            //}

            //TxtNombreEmpleado.Text = nombreEmpleado;
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
            //else
            //{
            //    RegistroUsuario registro = new RegistroUsuario
            //    {
            //        UsuarioId = _usuario.UsuarioId,
            //        RegistroId = 2,
            //        Fecha = DateTime.Now,
            //        Informacion = $"Cierre de sesión del usuario {_usuario.Nombre}"
            //    };

            //    _registroUsuarioLogic.Create(registro);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEmpleados frmEmpleados = new FrmEmpleados();
            frmEmpleados.MdiParent = this;
            frmEmpleados.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.MdiParent = this;
            frmUsuarios.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmCreditos frmCreditos = new FrmCreditos();
            frmCreditos.MdiParent = this;
            frmCreditos.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAsociados frmAsociados = new FrmAsociados();
            frmAsociados.MdiParent = this;
            frmAsociados.Show();
        }
    }
}
