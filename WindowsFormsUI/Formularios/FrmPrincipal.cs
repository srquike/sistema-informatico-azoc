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
            InitializeComponent();

            _usuario = usuario;
            _registroUsuarioLogic = new RegistroUsuarioBLL();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (_usuario != null)
            {
                string nombreEmpleado = $"{_usuario.Empleado.PrimerNombre} {_usuario.Empleado.SegundoNombre} {_usuario.Empleado.TercerNombre} {_usuario.Empleado.PrimerApellido} {_usuario.Empleado.SegundoApellido} {_usuario.Empleado.TercerApellido}";

                string extension = ".jpg";
                string ruta = @"C:\Users\Jonathan Vanegas\source\repos\SistemaInformaticoAZOC\WindowsFormsUI\Resources\Imagenes\";
                string archivo = string.Concat(ruta, _usuario.Nombre, extension);

                if (File.Exists(archivo))
                {
                    using (FileStream fileStream = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                    {
                        PctAvatar.Image = Image.FromStream(fileStream);
                    }
                }
                else
                {
                    PctAvatar.Image = _usuario.Empleado.Genero == "F" 
                        ? Properties.Resources.female_avatar_default
                        : Properties.Resources.male_avatar_default;
                }

                LblSaludo.Text = _usuario.Empleado.Genero == "F" ? "BIENVENIDA" : "BIENVENIDO";

                TxtNombreEmpleado.Text = nombreEmpleado;
            }
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
            else
            {
                RegistroUsuario registro = new RegistroUsuario
                {
                    UsuarioId = _usuario.UsuarioId,
                    RegistroId = 2,
                    Fecha = DateTime.Now,
                    Informacion = $"Cierre de sesión del usuario {_usuario.Nombre}"
                };

                _registroUsuarioLogic.Create(registro);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEmpleados frmEmpleados = new FrmEmpleados();
            frmEmpleados.MdiParent = this;
            frmEmpleados.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios(_usuario);
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