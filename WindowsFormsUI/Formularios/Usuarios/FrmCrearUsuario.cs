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

                        if (string.IsNullOrEmpty(TxtPregunta1.Text))
                        {
                            ErrPControles.SetError(TxtPregunta1, "Por favor, ingrese la respuesta");
                        }
                        else
                        {
                            ErrPControles.Clear();

                            if (string.IsNullOrEmpty(TxtPregunta2.Text))
                            {
                                ErrPControles.SetError(TxtPregunta2, "Por favor, ingrese la respuesta");
                            }
                            else
                            {
                                ErrPControles.Clear();

                                if (string.IsNullOrEmpty(TxtPregunta3.Text))
                                {
                                    ErrPControles.SetError(TxtPregunta3, "Por favor, ingrese la respuesta");
                                }
                                else
                                {
                                    ErrPControles.Clear();
                                    return true;
                                }
                            }
                        }
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
                return false;
            }

            return true;
        }

        private bool AgregarPermisos(int userId)
        {
            PermisoUsuario permiso;
            ICollection<PermisoUsuario> permisos = new List<PermisoUsuario>();

            foreach (CheckBox check in GrpPermisos.Controls)
            {
                if (check.Checked)
                {
                    permiso = new PermisoUsuario
                    {
                        PermisoId = Convert.ToInt32(check.Tag),
                        UsuarioId = userId
                    };

                    permisos.Add(permiso);
                }
            }

            if (permisos.Count > 0)
            {
                if (_permisoUsuarioLogic.CreateMany(permisos))
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        private void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (ValidarControles())
            {
                string nombreUsuario = MTxtUsuario.Text;

                if (VerificarExistencia(nombreUsuario))
                {
                    Usuario usuario = new Usuario
                    {
                        Nombre = nombreUsuario,
                        Clave = TxtClave.Text,
                        FechaCreacion = DateTime.Today,
                        UltimoAcceso = DateTime.Now,
                        EmpleadoId = Convert.ToInt32(CmbEmpleados.SelectedValue),
                        FechaModificacion = DateTime.Now,
                        Respuesta1 = TxtPregunta1.Text,
                        Respuesta2 = TxtPregunta2.Text,
                        Respuesta3 = TxtPregunta3.Text,
                        Estado = ChkActivarUsuario.Checked ? '1' : '0'
                    };

                    if (_usuarioLogic.Create(usuario)) // Se valida que el usuario fue insertado a la base de datos
                    {
                        if (AgregarPermisos(usuario.UsuarioId))
                        {
                            GuardarAvatar(nombreUsuario);

                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("No fue posible asignar los permisos al usuario!", "Asignar permisos: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No fue posible crear el usuario, por favor intente de nuevo!", "Crear usuario: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El nombre de usuario ya existe. Ingrese otro nombre de usuario, por favor!", "Crear usuario: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GuardarAvatar(string nombreUsuario)
        {
            string ruta = @"Imagenes\";
            string extension = ".jpeg";

            if (!Directory.Exists(ruta))
            {
                try
                {
                    Directory.CreateDirectory(ruta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo crear la carpeta para almacenar las imagenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string archivo = string.Concat(ruta, nombreUsuario, extension);

            if (!File.Exists(archivo))
            {
                using (FileStream fileStream = new FileStream(archivo, FileMode.CreateNew, FileAccess.Write))
                {
                    if (PctAvatar.Image != null)
                    {
                        using (Bitmap bitmap = new Bitmap(PctAvatar.Image, PctAvatar.Image.Size))
                        {
                            bitmap.Save(fileStream, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ya existe un archivo de imagen con el mismo nombre, por favor verifique el archivo!", "Guardar imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnElegirImagen_Click(object sender, EventArgs e)
        {
            if (OfdElegirAvatar.ShowDialog() == DialogResult.OK)
            {
                string archivo = OfdElegirAvatar.FileName;

                if (File.Exists(archivo))
                {
                    using (FileStream fileStream = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                    {
                        PctAvatar.Image = Image.FromStream(fileStream);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo de la imagen no existe o esta dañado, selecione otra imagen!", "Elegir imagen: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CmbEmpleados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int empleadoId = Convert.ToInt32(CmbEmpleados.SelectedValue);

            Empleado empleado = _empleadoLogic.Find(empleadoId);

            if (empleado != null)
            {
                int usuarios = empleado.Usuarios.Count;

                if (usuarios > 0)
                {
                    MessageBox.Show("No se puede crear un usuario para este empleado debiado a que ya posee uno. Elimine el usuario actual del empleado e intente de nuevo!", "Crear usuario: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}