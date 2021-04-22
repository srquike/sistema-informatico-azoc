using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCrearUsuario : Form
    {
        private EmpleadoBLL _empleadoLogic;
        private UsuarioBLL _usuarioLogic;
        private PermisoUsuarioBLL _permisoUsuarioLogic;

        public FrmCrearUsuario()
        {
            InitializeComponent();

            _empleadoLogic = new EmpleadoBLL();
            _usuarioLogic = new UsuarioBLL();
            _permisoUsuarioLogic = new PermisoUsuarioBLL();
        }

        private void LlenarComboBoxEmpleados()
        {
            var empleados = _empleadoLogic.List();
            var nombres = (from empleado in empleados
                           select new
                           {
                               Nombre = $"{empleado.PrimerNombre} {empleado.SegundoNombre} {empleado.TercerNombre} {empleado.PrimerApellido} {empleado.SegundoApellido} {empleado.TercerApellido} ",
                               Id = empleado.EmpleadoId
                           }).ToList();

            CmbEmpleados.DisplayMember = "Nombre";
            CmbEmpleados.DataSource = nombres;
            CmbEmpleados.ValueMember = "Id";
        }

        private void FrmCrearUsuario_Load(object sender, EventArgs e)
        {
            LlenarComboBoxEmpleados();
        }

        private void ChkVerClaves_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.Checked)
            {
                TxtClave.UseSystemPasswordChar = false;
                TxtRepetirClave.UseSystemPasswordChar = false;
            }
            else
            {
                TxtClave.UseSystemPasswordChar = true;
                TxtRepetirClave.UseSystemPasswordChar = true;
            }
        }

        private bool ValidarControles()
        {
            if (MTxtUsuario.MaskFull != true)
            {
                ErrPControles.SetError(MTxtUsuario, "Por favor, ingrese el nombre de usuario para continuar!");
            }
            else
            {
                ErrPControles.Clear();

                if (string.IsNullOrEmpty(TxtClave.Text))
                {
                    ErrPControles.SetError(TxtClave, "Por favor, ingrese la contraseña del usuario para continuar!");
                }
                else
                {
                    ErrPControles.Clear();

                    if (string.IsNullOrEmpty(TxtRepetirClave.Text) || TxtRepetirClave.Text != TxtClave.Text)
                    {
                        ErrPControles.SetError(TxtRepetirClave, "Por favor, ingrese la misma contraseña!");
                    }
                    else
                    {
                        ErrPControles.Clear();
                        return true;
                    }
                }
            }

            return false;
        }

        private bool VerificarExistencia(string nombreUsuario)
        {
            var usuarios = _usuarioLogic.List();
            var usuario = (from user in usuarios where user.Nombre == nombreUsuario select user).FirstOrDefault();

            if (usuario != null)
            {
                MessageBox.Show("El nombre de usuario ya existe. Ingrese otro nombre de usuario, por favor!", "Crear usuario: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void AgregarPermisos(int userId)
        {
            PermisoUsuario permiso;

            foreach (CheckBox check in GrpPermisos.Controls)
            {
                if (check.Checked)
                {
                    permiso = new PermisoUsuario
                    {
                        PermisoId = Convert.ToInt32(check.Tag),
                        UsuarioId = userId
                    };

                    _permisoUsuarioLogic.Create(permiso);
                }
            }
        }

        private void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (ValidarControles())
            {
                string nombreUsuario = MTxtUsuario.Text.Replace("-", "");

                if (VerificarExistencia(nombreUsuario))
                {
                    Usuario usuario = new Usuario
                    {
                        Nombre = nombreUsuario,
                        Clave = TxtClave.Text,
                        FechaCreacion = DateTime.Today,
                        UltimoAcceso = DateTime.Now,
                        EmpleadoId = Convert.ToInt32(CmbEmpleados.SelectedValue),
                        FechaModificacion = DateTime.Now
                    };

                    if (ChkActivarUsuario.Checked)
                    {
                        usuario.Estado = '1';
                    }
                    else
                    {
                        usuario.Estado = '0';
                    }

                    _usuarioLogic.Create(usuario);

                    AgregarPermisos(usuario.UsuarioId);

                    GuardarAvatar(nombreUsuario);

                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void GuardarAvatar(string userId)
        {
            if (File.Exists(PctAvatar.ImageLocation))
            {
                File.Copy(PctAvatar.ImageLocation, Path.Combine(@"C:\Users\Jonathan Vanegas\source\repos\SistemaInformaticoAZOC\WindowsFormsUI\Resources\Imagenes", userId + Path.GetExtension(PctAvatar.ImageLocation)), true);
            }
        }

        private void BtnElegirImagen_Click(object sender, EventArgs e)
        {
            if (OfdElegirAvatar.ShowDialog() == DialogResult.OK)
            {
                PctAvatar.ImageLocation = OfdElegirAvatar.FileName;
            }
        }

        private void BtnLimpiarControles_Click(object sender, EventArgs e)
        {
            MTxtUsuario.Clear();
            TxtClave.Clear();
            TxtRepetirClave.Clear();
            ChkVerClaves.Checked = false;
            ChkActivarUsuario.Checked = false;
            chkPuedeAgregar.Checked = false;
            chkPuedeEditar.Checked = false;
            chkPuedeEliminar.Checked = false;
            chkPuedeVer.Checked = false;
            PctAvatar.Image = null;
            CmbEmpleados.Focus();
        }
    }
}