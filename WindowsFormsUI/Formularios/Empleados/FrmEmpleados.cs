using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessObjectsLayer.Models;
using BusinessLogicLayer.Logics;
using System.Runtime.InteropServices;
using System.Linq;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmEmpleados : Form
    {
        private readonly EmpleadoBLL _empleadoLogic;
        private readonly RegistroUsuarioBLL _registroUsuarioBLL;
        private readonly Usuario _usuarioLogeado;
        private int _filasMarcadas;

        public FrmEmpleados(Usuario usuarioLogeado)
        {
            InitializeComponent();

            _empleadoLogic = new EmpleadoBLL();
            _registroUsuarioBLL = new RegistroUsuarioBLL();
            _usuarioLogeado = usuarioLogeado;
        }

        private bool VerificarPermisos(int permisoId)
        {
            int permisos = 0;

            foreach (PermisoUsuario permiso in _usuarioLogeado.PermisoUsuarios)
            {
                if (permiso.PermisoId == permisoId)
                {
                    permisos++;
                }
            }

            if (permisos > 0)
            {
                return true;
            }

            return false;
        }

        private void ActualizarDataGridView(ref DataGridView dataGrid, IEnumerable<Empleado> empleados)
        {
            dataGrid.Rows.Clear();
            foreach (Empleado empleado in empleados)
            {
                string nombreCompleto = $"{empleado.PrimerNombre} {empleado.SegundoNombre} {empleado.TercerNombre} {empleado.PrimerApellido} {empleado.SegundoApellido} {empleado.TercerApellido}";
                string genero = empleado.Genero == "F" ? "Femenino" : "Masculino";

                dataGrid.Rows.Add(false, empleado.EmpleadoId, nombreCompleto, empleado.Dui, empleado.Nit, genero, empleado.Telefono, empleado.Cargo.Nombre);
            }
            dataGrid.ClearSelection();
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            if (VerificarPermisos(2))
            {
                FrmCrearEmpleado frmAgregar = new FrmCrearEmpleado();
                frmAgregar.StartPosition = FormStartPosition.CenterParent;
                frmAgregar.ShowDialog();

                if (frmAgregar.DialogResult == DialogResult.OK)
                {
                    if (_usuarioLogeado != null)
                    {
                        RegistroUsuario registro = new RegistroUsuario
                        {
                            UsuarioId = _usuarioLogeado.UsuarioId,
                            RegistroId = 1,
                            Fecha = DateTime.Now,
                            Informacion = $"Creación de empleado por parte del usuario {_usuarioLogeado.Nombre}"
                        };

                        if (_registroUsuarioBLL.Create(registro) == false)
                        {
                            MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    ActualizarDataGridView(ref DgvListaEmpleados, _empleadoLogic.List());
                }
                else
                {
                    frmAgregar.Close();
                }
            }
            else
            {
                MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CmbTipoFiltro.SelectedIndex = 0;
            ActualizarDataGridView(ref DgvListaEmpleados, _empleadoLogic.List());
            CmbAcciones.SelectedIndex = 0;
            WindowState = FormWindowState.Maximized;
        }

        private void DgvListaEmpleados_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void DgvListaEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;

            if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int empleadoId = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells[1].Value);

                if (e.ColumnIndex == 8)
                {
                    if (VerificarPermisos(1))
                    {
                        FrmDetallesEmpledos frmDetalles = new FrmDetallesEmpledos(empleadoId);
                        frmDetalles.StartPosition = FormStartPosition.CenterParent;
                        frmDetalles.ShowDialog();

                        if (frmDetalles.DialogResult == DialogResult.OK)
                        {
                            frmDetalles.Close();
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
                        FrmEditarEmpleado frmEditar = new FrmEditarEmpleado(empleadoId);
                        frmEditar.StartPosition = FormStartPosition.CenterParent;
                        frmEditar.ShowDialog();

                        if (frmEditar.DialogResult == DialogResult.OK)
                        {
                            if (_usuarioLogeado != null)
                            {
                                RegistroUsuario registro = new RegistroUsuario
                                {
                                    UsuarioId = _usuarioLogeado.UsuarioId,
                                    RegistroId = 3,
                                    Fecha = DateTime.Now,
                                    Informacion = $"Modificación de empleado por parte del usuario {_usuarioLogeado.Nombre}"
                                };

                                if (_registroUsuarioBLL.Create(registro) == false)
                                {
                                    MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            ActualizarDataGridView(ref dataGrid, _empleadoLogic.List());
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
                        if (MessageBox.Show("¿Esta seguro de querer eliminar al empleado del sistema?", "Eliminación de empleado: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            if (_empleadoLogic.Delete(empleadoId))
                            {
                                if (_usuarioLogeado != null)
                                {
                                    RegistroUsuario registro = new RegistroUsuario
                                    {
                                        UsuarioId = _usuarioLogeado.UsuarioId,
                                        RegistroId = 2,
                                        Fecha = DateTime.Now,
                                        Informacion = $"Eliminación de empleado por parte del usuario {_usuarioLogeado.Nombre}"
                                    };

                                    if (_registroUsuarioBLL.Create(registro) == false)
                                    {
                                        MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                ActualizarDataGridView(ref dataGrid, _empleadoLogic.List());
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar al empleado, por favor intente de nuevo", "Eliminar empleado: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else if (dataGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                bool value = (bool)dataGrid.Rows[e.RowIndex].Cells[0].Value;

                if (value)
                {
                    dataGrid.Rows[e.RowIndex].Cells[0].Value = false;
                    _filasMarcadas--;
                }
                else
                {
                    dataGrid.Rows[e.RowIndex].Cells[0].Value = true;
                    _filasMarcadas++;
                }

                LLblQuitarMarcadas.Enabled = _filasMarcadas > 0 ? true : false;
                LblFilasMarcadas.Text = $"Filas marcadas: {_filasMarcadas}";
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBusqueda.Text))
            {
                string busqueda = TxtBusqueda.Text;
                var empleados = _empleadoLogic.List();

                var resultados = from empleado in empleados where empleado.PrimerNombre.Contains(busqueda) || empleado.PrimerApellido.Contains(busqueda) || empleado.Dui == busqueda || empleado.Nit == busqueda || empleado.Telefono == busqueda select empleado;

                ActualizarDataGridView(ref DgvListaEmpleados, resultados);
                LLblQuitarBusqueda.Enabled = true;
            }
        }

        private void LLblQuitarBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LLblQuitarBusqueda.Enabled = false;
            TxtBusqueda.Text = string.Empty;
            ActualizarDataGridView(ref DgvListaEmpleados, _empleadoLogic.List());
        }

        private void CmbTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTipoFiltro.SelectedItem.ToString() == "Genero")
            {
                CmbFiltro.Enabled = true;
                CmbFiltro.Items.Add("Masculino");
                CmbFiltro.Items.Add("Femenino");
                CmbFiltro.SelectedIndex = 0;
            }
            else
            {
                CmbFiltro.Items.Clear();
                CmbFiltro.Enabled = false;
            }
        }

        private void BtnAplicarFiltro_Click(object sender, EventArgs e)
        {
            if (CmbTipoFiltro.SelectedItem.ToString() == "Genero")
            {
                LLblQuitarFiltro.Enabled = true;

                string genero = CmbFiltro.SelectedItem.ToString() == "Femenino" ? "F" : "M";
                var empleados = _empleadoLogic.List();
                var resultados = from empleado in empleados where empleado.Genero == genero select empleado;

                ActualizarDataGridView(ref DgvListaEmpleados, resultados);
            }
        }

        private void LLblQuitarFiltro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LLblQuitarFiltro.Enabled = false;
            CmbTipoFiltro.SelectedIndex = 0;
            ActualizarDataGridView(ref DgvListaEmpleados, _empleadoLogic.List());
        }

        private void CmbAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_filasMarcadas > 0)
            {
                if (CmbAcciones.SelectedItem.ToString() == "Eliminar")
                {
                    if (VerificarPermisos(4))
                    {
                        if (MessageBox.Show("¿Esta seguro de querer borrar los empleados selecionados?", "Empleados: Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow fila in DgvListaEmpleados.Rows)
                            {
                                if ((bool)fila.Cells["Seleccion"].Value == true)
                                {
                                    int id = Convert.ToInt32(fila.Cells["Id"].Value);
                                    string nombre = fila.Cells["Nombre"].Value.ToString();

                                    if (_empleadoLogic.Delete(id) == false)
                                    {
                                        MessageBox.Show($"No se pudo eliminar al empleado {nombre}, por favor intente de nuevo", "Eliminar empleado: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }

                            ActualizarDataGridView(ref DgvListaEmpleados, _empleadoLogic.List());
                            _filasMarcadas = 0;
                            LblFilasMarcadas.Text = _filasMarcadas.ToString();
                            CmbAcciones.SelectedIndex = 0;
                        }
                        else
                        {
                            CmbAcciones.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void CmbFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void LLblQuitarMarcadas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_filasMarcadas > 0)
            {
                bool marcada;

                foreach (DataGridViewRow fila in DgvListaEmpleados.Rows)
                {
                    marcada = (bool)fila.Cells["Seleccion"].Value;

                    if (marcada)
                    {
                        fila.Cells["Seleccion"].Value = false;
                        _filasMarcadas = 0;
                        LblFilasMarcadas.Text = _filasMarcadas.ToString();
                        LLblQuitarMarcadas.Enabled = false;
                    }
                }
            }
        }
    }
}