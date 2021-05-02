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
        private int _filasMarcadas;

        public FrmEmpleados()
        {
            InitializeComponent();

            _empleadoLogic = new EmpleadoBLL();
        }

        private void ActualizarDataGridView(ref DataGridView dataGrid, IEnumerable<Empleado> empleados)
        {
            dataGrid.Rows.Clear();
            foreach (Empleado empleado in empleados)
            {
                string nombreCompleto = $"{empleado.PrimerNombre} {empleado.SegundoNombre} {empleado.TercerNombre} {empleado.PrimerApellido} {empleado.SegundoApellido} {empleado.TercerApellido}";
                string genero;

                if (empleado.Genero == "F")
                {
                    genero = "Femenino";
                }
                else if (empleado.Genero == "M")
                {
                    genero = "Masculino";
                }
                else
                {
                    genero = string.Empty;
                }

                dataGrid.Rows.Add(false, empleado.EmpleadoId, nombreCompleto, empleado.Dui, empleado.Nit, genero, empleado.Telefono, empleado.Cargo.Nombre);
            }
            dataGrid.ClearSelection();
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            FrmCrearEmpleado frmAgregar = new FrmCrearEmpleado();
            frmAgregar.StartPosition = FormStartPosition.CenterParent;
            frmAgregar.ShowDialog();

            if (frmAgregar.DialogResult == DialogResult.OK)
            {
                ActualizarDataGridView(ref DgvListaEmpleados, _empleadoLogic.List());
            }
            else
            {
                frmAgregar.Close();
            }
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CmbTipoFiltro.SelectedIndex = 0;
            ActualizarDataGridView(ref DgvListaEmpleados, _empleadoLogic.List());
            CmbAcciones.SelectedIndex = 0;
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
                    FrmDetallesEmpledos frmDetalles = new FrmDetallesEmpledos(empleadoId);
                    frmDetalles.StartPosition = FormStartPosition.CenterParent;
                    frmDetalles.ShowDialog();

                    if (frmDetalles.DialogResult == DialogResult.OK)
                    {
                        frmDetalles.Close();
                    }
                }
                else if (e.ColumnIndex == 9)
                {
                    FrmEditarEmpleado frmEditar = new FrmEditarEmpleado();
                    frmEditar.StartPosition = FormStartPosition.CenterParent;
                    frmEditar.ShowDialog();

                    if (frmEditar.DialogResult == DialogResult.OK)
                    {
                        ActualizarDataGridView(ref dataGrid, _empleadoLogic.List());
                    }
                }
                else if (e.ColumnIndex == 10)
                {
                    if (MessageBox.Show("¿Esta seguro de querer eliminar al empleado del sistema?", "Eliminación de empleado: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        _empleadoLogic.Delete(empleadoId);
                        ActualizarDataGridView(ref dataGrid, _empleadoLogic.List());
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

                LblFilasMarcadas.Text = $"Filas marcadas: {_filasMarcadas}";
            }
        }

        #region Codigo para la barra superior del formulario

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                BtnMaximizar.Image = Properties.Resources.normal;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                BtnMaximizar.Image = Properties.Resources.maximize;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PnlBarraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion

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
                string genero;
                if (CmbFiltro.SelectedItem.ToString() == "Femenino")
                {
                    genero = "F";
                }
                else
                {
                    genero = "M";
                }

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
            if (CmbAcciones.SelectedItem.ToString() == "Eliminar")
            {
                if (MessageBox.Show("¿Esta seguro de querer borrar los empleados selecionados?", "Empleados: Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow fila in DgvListaEmpleados.Rows)
                    {
                        if ((bool)fila.Cells["Seleccion"].Value == true)
                        {
                            int id = Convert.ToInt32(fila.Cells["Id"].Value);
                            _empleadoLogic.Delete(id);
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
        }
    }
}