using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;

namespace WindowsFormsUI.Formularios.Cuotas
{
    public partial class FrmCuotas : Form
    {
        private readonly Usuario _usuarioLogeado;
        private readonly CuotaBLL _cuotaBLL;
        private int _filasMarcadas;

        public FrmCuotas(Usuario usuarioLogeado)
        {
            InitializeComponent();

            _usuarioLogeado = usuarioLogeado;
            _cuotaBLL = new CuotaBLL();
        }

        private void ActualizarListado(ref DataGridView dataGrid, IEnumerable<Cuota> cuotas)
        {
            List<Cuota> cuotass = cuotas.ToList();

            if (cuotass.Count > 0)
            {
                dataGrid.Rows.Clear();

                foreach (Cuota cuota in cuotas)
                {
                    string monto = string.Format("{0:C2}", cuota.Monto);
                    string fechaVencimiento = string.Format("{0:dd/MM/yyyy}", cuota.FechaVencimiento);
                    string fechaPago = string.Format("{0:dd/MM/yyyy}", cuota.FechaPago);

                    dataGrid.Rows.Add(false, cuota.CuotaId, cuota.Numero, monto, fechaVencimiento, fechaPago, cuota.Credito.Codigo, cuota.EstadoCuota.Nombre);
                }

                dataGrid.ClearSelection();
            }
        }

        private void FrmCuotas_Load(object sender, EventArgs e)
        {
            ActualizarListado(ref DgvListado, _cuotaBLL.List());
            CmbTipoFiltro.SelectedIndex = 0;
            CmbAcciones.SelectedIndex = 0;
            WindowState = FormWindowState.Maximized;
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

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridView dataGrid = (DataGridView)sender;

                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    int cuotaId = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["Id"].Value);

                    if (e.ColumnIndex == 8)
                    {
                        if (VerificarPermisos(1))
                        {

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
                            if (MessageBox.Show("Esta seguro de cancelar esta cuota?", "Cancelar cuota: confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                Cuota cuota = _cuotaBLL.Find(cuotaId);

                                if (cuota != null)
                                {
                                    if (cuota.EstadoCuotaId == 1)
                                    {
                                        cuota.EstadoCuotaId = 2;
                                        cuota.FechaPago = DateTime.Today;

                                        if (_cuotaBLL.Edit(cuota))
                                        {
                                            ActualizarListado(ref DgvListado, _cuotaBLL.List());
                                        }
                                        else
                                        {
                                            MessageBox.Show("No fue posible cancelar la cuota, por favor intente de nuevo!", "Cancelar cuota: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No puede cancelar una cuota que ya esta cancelada", "Cancelar cuota: información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (dataGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
                {
                    bool value = (bool)dataGrid.Rows[e.RowIndex].Cells["Seleccion"].Value;

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
        }

        private void CmbTipoFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbTipoFiltro.SelectedItem.ToString() == "Estado")
            {
                CmbFiltro.Items.Add("-- Seleccionar filtro --");
                CmbFiltro.Items.Add("Cancelada");
                CmbFiltro.Items.Add("Pendiente");
            }

            CmbFiltro.SelectedIndex = 0;
        }

        private void CmbFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string estado = CmbFiltro.SelectedItem.ToString();
            var cuotas = _cuotaBLL.List();
            var resultado = from cuota in cuotas where cuota.EstadoCuota.Nombre == estado select cuota;

            LLblQuitarFiltro.Enabled = true;
            ActualizarListado(ref DgvListado, resultado);
        }

        private void LLblQuitarFiltro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CmbTipoFiltro.SelectedIndex = 0;
            CmbFiltro.Items.Clear();
            LLblQuitarFiltro.Enabled = false;

            ActualizarListado(ref DgvListado, _cuotaBLL.List());
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBusqueda.Text))
            {
                MessageBox.Show("Por favor, ingrese las palabras a buscar", "Buscar cuota: información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string busqueda = TxtBusqueda.Text;
                var cuotas = _cuotaBLL.List();
                var resultado = from cuota in cuotas where cuota.Credito.Codigo.ToString() == busqueda select cuota;

                LLblQuitarBusqueda.Enabled = true;
                ActualizarListado(ref DgvListado, resultado);
            }
        }

        private void LLblQuitarBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TxtBusqueda.Clear();
            LLblQuitarBusqueda.Enabled = false;

            ActualizarListado(ref DgvListado, _cuotaBLL.List());
        }
    }
}
