using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmEditarUsuario : Form
    {
        private Usuario _usuarioEdit;
        private UsuarioBLL _usuarioLogic;
        private EmpleadoBLL _empleadoLogic;
        private PermisoUsuarioBLL _permisoUsuarioLogic;

        public FrmEditarUsuario(Usuario usuario)
        {
            InitializeComponent();

            _usuarioEdit = usuario;
            _usuarioLogic = new UsuarioBLL();
            _empleadoLogic = new EmpleadoBLL();
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

            CmbEmpleados.DataSource = nombres;
            CmbEmpleados.DisplayMember = "Nombre";
            CmbEmpleados.ValueMember = "Id";
            CmbEmpleados.SelectedItem = _usuarioEdit.EmpleadoId;
        }

        private void LlenarControles()
        {
            MTxtUsuario.Text = _usuarioEdit.Nombre;

            if (_usuarioEdit.Estado == '1')
            {
                ChkActivarUsuario.Checked = true;
            }

            ObtenerPermisos(_usuarioEdit.PermisoUsuarios);
            ObtenerAvatar(_usuarioEdit.Nombre);
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
            string path = @"C:\Users\Jonathan Vanegas\source\repos\SistemaInformaticoAZOC\WindowsFormsUI\Resources\Imagenes\";
            string file = string.Concat(path, avatar);

            if (!File.Exists(file))
            {
                PctAvatar.Image = Properties.Resources.image_nofound;
            }
            else
            {
                using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    PctAvatar.Image = Image.FromStream(stream);
                }
            }
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            LlenarComboBoxEmpleados();
            LlenarControles();
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
                return true;
            }

            return false;
        }

        private bool ValidarClaves()
        {
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
            return false;
        }

        private bool VerificarExistencia(string nombreUsuario)
        {
            var usuarios = _usuarioLogic.List();
            var usuario = (from user in usuarios where user.Nombre == nombreUsuario select user).FirstOrDefault();

            if (usuario != null)
            {
                MessageBox.Show("El nombre de usuario ya existe. Ingrese otro nombre de usuario, por favor!", "Editar usuario: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ActualizarPermisos(IEnumerable<PermisoUsuario> permisos, int userId)
        {
            foreach (PermisoUsuario permiso in permisos)
            {
                _permisoUsuarioLogic.Delete(permiso.PermisoUsuarioId);
            }

            AgregarPermisos(userId);
        }

        private void GuardarAvatar(string userName)
        {
            string fileName = $"{userName}.jpg";
            string path = @"C:\Users\Jonathan Vanegas\source\repos\SistemaInformaticoAZOC\WindowsFormsUI\Resources\Imagenes\";
            string file = string.Concat(path, fileName);

            using (Bitmap bitmap = new Bitmap(PctAvatar.Image, PctAvatar.Image.Size))
            {
                bitmap.Save(file);
            };
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (ValidarControles())
            {
                string userName = MTxtUsuario.Text.Replace("-", "");
                bool continuar = true;
                bool cambiarClave = false;

                if (userName != _usuarioEdit.Nombre)
                {
                    if (VerificarExistencia(userName))
                    {
                        _usuarioEdit.Nombre = userName;
                    }
                    else
                    {
                        continuar = false;
                    }
                }

                if (continuar)
                {
                    if (ChkCambiarClave.Checked)
                    {
                        if (ValidarClaves())
                        {
                            _usuarioEdit.Clave = TxtClave.Text;
                        }
                        else
                        {
                            cambiarClave = false;
                        }
                    }

                    if (continuar)
                    {
                        _usuarioEdit.EmpleadoId = Convert.ToInt32(CmbEmpleados.SelectedValue);  
                        _usuarioEdit.FechaModificacion = DateTime.Now;

                        if (ChkActivarUsuario.Checked)
                        {
                            _usuarioEdit.Estado = '1';
                        }
                        else
                        {
                            _usuarioEdit.Estado = '0';
                        }

                        _usuarioLogic.Edit(_usuarioEdit, cambiarClave);
                        ActualizarPermisos(_usuarioEdit.PermisoUsuarios, _usuarioEdit.UsuarioId);
                        GuardarAvatar(_usuarioEdit.Nombre);

                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void BtnElegirImagen_Click(object sender, EventArgs e)
        {
            if (OfdElegirAvatar.ShowDialog() == DialogResult.OK)
            {
                string path = OfdElegirAvatar.FileName;

                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    PctAvatar.Image = Image.FromStream(stream);
                }
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

        private void ChkCambiarClave_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCambiarClave.Checked)
            {
                TxtClave.Enabled = true;
                TxtRepetirClave.Enabled = true;
                ChkVerClaves.Enabled = true;
            }
            else
            {
                TxtClave.Enabled = false;
                TxtRepetirClave.Enabled = false;
                ChkVerClaves.Enabled = false;
            }
        }
    }
}