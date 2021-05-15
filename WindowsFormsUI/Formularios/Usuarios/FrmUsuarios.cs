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

namespace WindowsFormsUI.Formularios
{
    public partial class FrmUsuarios : Form
    {
        private UsuarioBLL _usuarioLogic;
        private EmpleadoBLL _empleadoLogic;
        private int _filasMarcadas;
        private readonly Usuario _usuarioLogeado;

        public FrmUsuarios(Usuario usuarioLogeado)
        {
            InitializeComponent();

            _usuarioLogic = new UsuarioBLL();
            _empleadoLogic = new EmpleadoBLL();
            _filasMarcadas = 0;
            _usuarioLogeado = usuarioLogeado;
        }

        private void RefrescarDataGridView(ref DataGridView dataGrid, IEnumerable<Usuario> usuarios)
        {
            dataGrid.Rows.Clear();

            foreach (Usuario usuario in usuarios)
            {
                string nombreEmpleado = $"{usuario.Empleado.PrimerNombre} {usuario.Empleado.SegundoNombre} {usuario.Empleado.TercerNombre} {usuario.Empleado.PrimerApellido} {usuario.Empleado.SegundoApellido} {usuario.Empleado.TercerApellido}";
                string estado;

                if (usuario.Estado == '0')
                {
                    estado = "Desactivado";
                }
                else if (usuario.Estado == '1')
                {
                    estado = "Activado";
                }
                else
                {
                    estado = "-";
                }

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
            CmbTipoFiltro.SelectedIndex = 0;
            CmbAcciones.SelectedIndex = 0;
            WindowState = FormWindowState.Maximized;
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            FrmCrearUsuario frmCrearUsuario = new FrmCrearUsuario();
            frmCrearUsuario.StartPosition = FormStartPosition.CenterParent;

            if (frmCrearUsuario.ShowDialog() == DialogResult.OK)
            {
                RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
            }
        }

        private void DgvListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[1].Value);

                if (e.ColumnIndex == 8)
                {
                    FrmDetallesUsuario detallesUsuario = new FrmDetallesUsuario(userId);
                    detallesUsuario.StartPosition = FormStartPosition.CenterParent;
                    detallesUsuario.ShowDialog();
                    if (detallesUsuario.DialogResult == DialogResult.OK)
                    {
                        detallesUsuario.Close();
                    }
                }
                else if (e.ColumnIndex == 9)
                {
                    Usuario usuario = _usuarioLogic.Find(userId);

                    FrmEditarUsuario frmEditar = new FrmEditarUsuario(usuario);
                    frmEditar.StartPosition = FormStartPosition.CenterParent;
                    frmEditar.ShowDialog();

                    if (frmEditar.DialogResult == DialogResult.OK)
                    {
                        RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
                    }
                }
                else if (e.ColumnIndex == 10)
                {
                    if (userId == _usuarioLogeado.UsuarioId)
                    {
                        MessageBox.Show("No se puede eliminar el usuario actual. Cierre la sesión e ingrese con otro usuario!", "Eliminar usuario: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (MessageBox.Show("¿Esta seguro de querer eliminar al usuario del sistema?", "Eliminar usuario: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            _usuarioLogic.Delete(userId);
                            RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
                        }
                    }
                }
            }
            else if (dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                bool value = (bool)dataGridView.Rows[e.RowIndex].Cells[0].Value;

                if (value)
                {
                    dataGridView.Rows[e.RowIndex].Cells[0].Value = false;
                    _filasMarcadas--;
                }
                else
                {
                    dataGridView.Rows[e.RowIndex].Cells[0].Value = true;
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
                var listaUsuario = _usuarioLogic.List();

                var resultado = from usuario in listaUsuario where usuario.Nombre.Contains(busqueda) || usuario.Empleado.PrimerNombre.Contains(busqueda) || usuario.Empleado.PrimerApellido.Contains(busqueda) select usuario;

                RefrescarDataGridView(ref DgvListaUsuarios, resultado);
                LLblQuitarBusqueda.Enabled = true;
            }
        }

        private void LblQuitarBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LLblQuitarBusqueda.Enabled = false;
            TxtBusqueda.Text = string.Empty;
            RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
        }

        private void CmbTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTipoFiltro.SelectedItem.ToString() == "Empleado")
            {
                var empleados = _empleadoLogic.List();
                var nombres = (from empleado in empleados
                               select new
                               {
                                   Nombre = $"{empleado.PrimerNombre} {empleado.SegundoNombre} {empleado.TercerNombre} {empleado.PrimerApellido} {empleado.SegundoApellido} {empleado.TercerApellido} ",
                                   Id = empleado.EmpleadoId
                               }).ToList();

                CmbFiltro.DisplayMember = "Nombre";
                CmbFiltro.DataSource = nombres;
                CmbFiltro.ValueMember = "Id";
            }
            else
            {
                CmbFiltro.DataSource = null;
            }
        }

        private void BtnAplicarFiltro_Click(object sender, EventArgs e)
        {
            LLblQuitarFiltro.Enabled = true;

            if (CmbTipoFiltro.SelectedItem.ToString() == "Empleado")
            {
                var usuarios = ObtenerLista();
                var empleadoId = Convert.ToInt32(CmbFiltro.SelectedValue);
                var usuariosFiltrados = from usuario in usuarios where usuario.EmpleadoId == empleadoId select usuario;

                RefrescarDataGridView(ref DgvListaUsuarios, usuariosFiltrados);
            }
        }

        private void LLblQuitarFiltro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LLblQuitarFiltro.Enabled = false;
            BtnAplicarFiltro.Enabled = false;
            CmbTipoFiltro.SelectedIndex = 0;

            RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
        }

        private void CmbAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_filasMarcadas > 0)
            {
                if (CmbAcciones.SelectedItem.ToString() == "Eliminar")
                {
                    if (MessageBox.Show("¿Esta seguro de querer borrar los usuarios selecionados?", "Eliminar usuarios: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow fila in DgvListaUsuarios.Rows)
                        {
                            if ((bool)fila.Cells["Seleccion"].Value == true)
                            {
                                int userId = Convert.ToInt32(fila.Cells["Id"].Value);

                                if (_usuarioLogeado.UsuarioId == userId)
                                {
                                    MessageBox.Show("No se puede eliminar el usuario actual. Cierre la sesión e ingrese con otro usuario!", "Eliminar usuario: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                else
                                {
                                    _usuarioLogic.Delete(userId);
                                }
                            }
                        }

                        RefrescarDataGridView(ref DgvListaUsuarios, ObtenerLista());
                        _filasMarcadas = 0;
                        LblFilasMarcadas.Text = _filasMarcadas.ToString();
                        CmbAcciones.SelectedIndex = 0;
                    }
                    else
                    {
                        CmbAcciones.SelectedIndex = 0;
                    }
                }
            }
        }

        private void CmbFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BtnAplicarFiltro.Enabled = true;
        }

        private void LLblQuitarMarcadas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_filasMarcadas > 0)
            {
                bool marcada;

                foreach (DataGridViewRow fila in DgvListaUsuarios.Rows)
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