using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioBLL _usuarioLogic;
        private readonly RegistroUsuarioBLL _registroUsuarioBLL;
        private readonly Usuario _usuarioLogeado;

        public FrmUsuarios(Usuario usuarioLogeado)
        {
            InitializeComponent();

            _usuarioLogic = new UsuarioBLL();
            _registroUsuarioBLL = new RegistroUsuarioBLL();
            _usuarioLogeado = usuarioLogeado;
        }

        private bool VerificarPermisos(int permisoId)
        {
            int permisos = (from permiso in _usuarioLogeado.PermisoUsuarios where permiso.PermisoId == permisoId select permiso).Count();

            if (permisos > 0)
            {
                return true;
            }

            return false;
        }

        private void RefrescarDataGridView(ref DataGridView dataGrid, IEnumerable<Usuario> usuarios)
        {
            dataGrid.Rows.Clear();

            foreach (Usuario usuario in usuarios)
            {
                string nombreEmpleado = $"{usuario.Empleado.PrimerNombre} {usuario.Empleado.SegundoNombre} {usuario.Empleado.TercerNombre} {usuario.Empleado.PrimerApellido} {usuario.Empleado.SegundoApellido} {usuario.Empleado.TercerApellido}";
                string estado = usuario.Estado == '0' ? "Desactivado" : "Activado";
                string fechaCreacion = string.Format("{0:dd/MM/yyyy}", usuario.FechaCreacion);
                string fechaModificacion = string.Format("{0:dd/MM/yyyy}", usuario.FechaModificacion);

                dataGrid.Rows.Add(false, usuario.UsuarioId, usuario.Nombre, usuario.UltimoAcceso, fechaCreacion, fechaModificacion, estado, nombreEmpleado);
            }

            dataGrid.ClearSelection();
        }

        private IEnumerable<Usuario> ObtenerLista()
        {
            return _usuarioLogic.List();
        }

        private void DgvListaUsuarios_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            var usuarios = ObtenerLista();
            RefrescarDataGridView(ref DgvListaUsuarios, usuarios);
            WindowState = FormWindowState.Maximized;
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            if (VerificarPermisos(2))
            {
                FrmCrearUsuario frmCrearUsuario = new FrmCrearUsuario();
                frmCrearUsuario.StartPosition = FormStartPosition.CenterParent;

                if (frmCrearUsuario.ShowDialog() == DialogResult.OK)
                {
                    if (_usuarioLogeado != null)
                    {
                        RegistroUsuario registro = new RegistroUsuario
                        {
                            UsuarioId = _usuarioLogeado.UsuarioId,
                            RegistroId = 1002,
                            Fecha = DateTime.Now,
                            Informacion = $"Creación de usuario por parte del usuario {_usuarioLogeado.Nombre}"
                        };

                        if (_registroUsuarioBLL.Create(registro) == false)
                        {
                            MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
                }
            }
            else
            {
                MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DgvListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Id"].Value);
                string nombreUsuario = dataGridView.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();

                if (e.ColumnIndex == 8)
                {
                    if (VerificarPermisos(1))
                    {
                        FrmDetallesUsuario detallesUsuario = new FrmDetallesUsuario(userId);
                        detallesUsuario.StartPosition = FormStartPosition.CenterParent;
                        detallesUsuario.ShowDialog();

                        if (detallesUsuario.DialogResult == DialogResult.OK)
                        {
                            detallesUsuario.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else if (e.ColumnIndex == 9)
                {
                    if (VerificarPermisos(3))
                    {
                        Usuario usuario = _usuarioLogic.Find(userId);

                        FrmEditarUsuario frmEditar = new FrmEditarUsuario(usuario);
                        frmEditar.StartPosition = FormStartPosition.CenterParent;
                        frmEditar.ShowDialog();

                        if (frmEditar.DialogResult == DialogResult.OK)
                        {
                            if (_usuarioLogeado != null)
                            {
                                RegistroUsuario registro = new RegistroUsuario
                                {
                                    UsuarioId = _usuarioLogeado.UsuarioId,
                                    RegistroId = 1004,
                                    Fecha = DateTime.Now,
                                    Informacion = $"Modificación de usuario por parte del usuario {_usuarioLogeado.Nombre}"
                                };

                                if (_registroUsuarioBLL.Create(registro) == false)
                                {
                                    MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else if (e.ColumnIndex == 10)
                {
                    if (VerificarPermisos(4))
                    {
                        if (_usuarioLogeado != null)
                        {
                            if (userId == _usuarioLogeado.UsuarioId)
                            {
                                MessageBox.Show("No se puede eliminar el usuario actual. Cierre la sesión e ingrese con otro usuario!", "Eliminar usuario: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (MessageBox.Show("¿Esta seguro de querer eliminar al usuario del sistema?", "Eliminar usuario: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    if (_usuarioLogic.Delete(userId))
                                    {
                                        if (_usuarioLogeado != null)
                                        {
                                            EliminarAvatar(nombreUsuario);

                                            RegistroUsuario registro = new RegistroUsuario
                                            {
                                                UsuarioId = _usuarioLogeado.UsuarioId,
                                                RegistroId = 1003,
                                                Fecha = DateTime.Now,
                                                Informacion = $"Eliminación de usuario por parte del usuario {_usuarioLogeado.Nombre}"
                                            };

                                            if (_registroUsuarioBLL.Create(registro) == false)
                                            {
                                                MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }

                                        RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo eliminar al usuario, por favor intente de nuevo!", "Eliminar usuario: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void EliminarAvatar(string usuarioNombre)
        {
            string ruta = @"Imagenes\";
            string extension = ".jpeg";
            string archivo = string.Concat(ruta, usuarioNombre, extension);

            if (File.Exists(archivo))
            {
                File.Delete(archivo);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}