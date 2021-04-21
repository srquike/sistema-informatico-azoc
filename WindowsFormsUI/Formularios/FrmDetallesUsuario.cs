using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessObjectsLayer.Models;
using BusinessLogicLayer.Logics;
using System.IO;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmDetallesUsuario : Form
    {
        private int _userId;
        private UsuarioBLL _usuarioLogic;

        public FrmDetallesUsuario(int userId)
        {
            InitializeComponent();

            _userId = userId;
            _usuarioLogic = new UsuarioBLL();
        }

        private void ObtenerPermisos(IEnumerable<PermisoUsuario> permisos)
        {
            foreach (PermisoUsuario permiso in permisos)
            {
                if (permiso.PermisoId == 1)
                {
                    chkPuedeVer.Checked = true;
                }
                else if (permiso.PermisoId == 2)
                {
                    chkPuedeAgregar.Checked = true;
                }
                else if (permiso.PermisoId == 3)
                {
                    chkPuedeEditar.Checked = true;
                }
                else if (permiso.PermisoId == 4)
                {
                    chkPuedeEliminar.Checked = true;
                }
            }
        }

        private void ObtenerAvatar(string userName)
        {
            string avatar = string.Concat(userName, ".jpg");
            string ruta = @"C:\Users\Jonathan Vanegas\source\repos\SistemaInformaticoAZOC\WindowsFormsUI\Resources\Imagenes\";
            string archivo = string.Concat(ruta, avatar);

            if (File.Exists(archivo))
            {
                PctAvatar.Image = Image.FromFile(archivo);
            }
        }

        private void FrmDetallesUsuario_Load(object sender, EventArgs e)
        {
            Usuario usuario = _usuarioLogic.Find(_userId);

            string nombreEmpleado = $"{usuario.Empleado.PrimerNombre} {usuario.Empleado.SegundoNombre} {usuario.Empleado.TercerNombre} " +
                $"{usuario.Empleado.PrimerApellido} {usuario.Empleado.SegundoApellido} {usuario.Empleado.TercerApellido}";

            TxtEmpleado.Text = nombreEmpleado;
            MTxtUsuario.Text = usuario.Nombre;
            TxtCodigoUsuario.Text = usuario.UsuarioId.ToString();

            if (usuario.Estado == '1')
            {
                LblEstadoUsuario.Text = "Activado";
            }
            else if (usuario.Estado == '0')
            {
                LblEstadoUsuario.Text = "Desactivado";
            }

            ObtenerPermisos(usuario.PermisoUsuarios);
            ObtenerAvatar(usuario.Nombre);
        }
    }
}
