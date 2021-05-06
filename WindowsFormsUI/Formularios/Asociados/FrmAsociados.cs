﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmAsociados : Form
    {
        private readonly AsociadoBLL _asociadoLogic;
        private readonly CategoriaAsociadoBLL _categoriaAsociadoLogic;
        private int _filasMarcadas;

        public FrmAsociados()
        {
            InitializeComponent();

            _asociadoLogic = new AsociadoBLL();
            _categoriaAsociadoLogic = new CategoriaAsociadoBLL();
        }

        private void ActualizarListado(ref DataGridView dataGrid, IEnumerable<Asociado> asociados)
        {
            dataGrid.Rows.Clear();

            foreach (Asociado asociado in asociados)
            {
                string nombreAsociado = string.Concat(asociado.PrimerNombre, " ", asociado.SegundoNombre, " ", asociado.TercerNombre, " ",
                    asociado.PrimerApellido, " ", asociado.SegundoApellido, " ", asociado.TercerApellido);
                string genero = asociado.Genero == "F" ? "Femenino" : "Masculino";
                string estado = asociado.Estado == "1" ? "Activo" : "Inactivo";

                dataGrid.Rows.Add(false, asociado.AsociadoId, nombreAsociado, asociado.Dui, asociado.Nit, genero, asociado.Telefono, asociado.CategoriaAsociado.Nombre, estado);
            }

            dataGrid.ClearSelection();
        }

        private void FrmAsociados_Load(object sender, EventArgs e)
        {
            CmbAcciones.SelectedIndex = 0;
            CmbTipoFiltro.SelectedIndex = 0;
            ActualizarListado(ref DgvListado, _asociadoLogic.List());
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            FrmCrearAsociado frmCrear = new FrmCrearAsociado();
            frmCrear.StartPosition = FormStartPosition.CenterParent;
            frmCrear.ShowDialog();

            if (frmCrear.DialogResult == DialogResult.OK)
            {
                ActualizarListado(ref DgvListado, _asociadoLogic.List());
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBusqueda.Text))
            {
                string busqueda = TxtBusqueda.Text;
                var asociados = _asociadoLogic.List();

                var resultados = from asociado in asociados where asociado.PrimerNombre.Contains(busqueda) || asociado.PrimerApellido.Contains(busqueda) || asociado.Dui == busqueda || asociado.Nit == busqueda || asociado.Telefono == busqueda select asociado;

                ActualizarListado(ref DgvListado, resultados);
                LLblQuitarBusqueda.Enabled = true;
            }
            else
            {
                MessageBox.Show("Por favor, escriba la busqueda que desea realizar!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CmbTipoFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbTipoFiltro.SelectedItem.ToString() == "Genero")
            {
                CmbFiltro.Enabled = true;
                CmbFiltro.Items.Add("Masculino");
                CmbFiltro.Items.Add("Femenino");
                CmbFiltro.SelectedIndex = 0;
            }
            else if (CmbTipoFiltro.SelectedItem.ToString() == "Categoria")
            {
                var categorias = _categoriaAsociadoLogic.List();
                var nombresCategorias = from categoria in categorias
                                        select new
                                        {
                                            Nombre = categoria.Nombre
                                        };
                CmbFiltro.DataSource = categorias;
                CmbFiltro.DisplayMember = "Nombre";
            }
            else
            {
                CmbFiltro.Items.Clear();
                CmbFiltro.Enabled = false;
            }
        }

        private void BtnAplicarFiltro_Click(object sender, EventArgs e)
        {
            var asociados = _asociadoLogic.List();

            if (CmbTipoFiltro.SelectedItem.ToString() == "Genero")
            {
                string genero = CmbFiltro.SelectedItem.ToString() == "Femenino" ? "F" : "M";

                var resultados = from asociado in asociados where asociado.Genero == genero select asociado;

                ActualizarListado(ref DgvListado, resultados);
            }
            else if (CmbTipoFiltro.SelectedItem.ToString() == "Categoria")
            {
                string categoria = CmbFiltro.SelectedItem.ToString();
                var resultados = from asociado in asociados where asociado.CategoriaAsociado.Nombre == categoria select asociado;

                ActualizarListado(ref DgvListado, resultados);
            }
            else
            {
                CmbFiltro.Items.Clear();
                CmbFiltro.Enabled = false;
            }
        }

        private void LLblQuitarBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LLblQuitarBusqueda.Enabled = false;
            TxtBusqueda.Clear();
            ActualizarListado(ref DgvListado, _asociadoLogic.List());
        }

        private void LLblQuitarFiltro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LLblQuitarFiltro.Enabled = false;
            CmbTipoFiltro.SelectedIndex = 0;
            ActualizarListado(ref DgvListado, _asociadoLogic.List());
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                int asociadoId = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["Id"].Value);
                bool marcada = (bool)dataGrid.Rows[e.RowIndex].Cells["Seleccion"].Value;

                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (e.ColumnIndex == 9)
                    {
                        FrmDetallesAsociado frmDetalles = new FrmDetallesAsociado(asociadoId);
                        frmDetalles.StartPosition = FormStartPosition.CenterParent;
                        frmDetalles.ShowDialog();

                        if (frmDetalles.DialogResult == DialogResult.OK)
                        {
                            frmDetalles.Close();
                        }
                    }
                    else if (e.ColumnIndex == 10)
                    {
                        FrmEditarAsociado frmEditar = new FrmEditarAsociado(asociadoId);
                        frmEditar.StartPosition = FormStartPosition.CenterParent;
                        frmEditar.ShowDialog();

                        if (frmEditar.DialogResult == DialogResult.OK)
                        {
                            ActualizarListado(ref DgvListado, _asociadoLogic.List());
                        }
                    }
                    else if (e.ColumnIndex == 11)
                    {
                        if (MessageBox.Show("¿Esta seguro de querer eliminar al asociado del sistema?", "Eliminación de asociado: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            _asociadoLogic.Delete(asociadoId);
                            ActualizarListado(ref dataGrid, _asociadoLogic.List());
                        }
                    }
                }
                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {        
                    if (marcada)
                    {
                        dataGrid.Rows[e.RowIndex].Cells["Seleccion"].Value = false;
                        _filasMarcadas--;
                    }
                    else
                    {
                        dataGrid.Rows[e.RowIndex].Cells["Seleccion"].Value = true;
                        _filasMarcadas++;
                    }

                    LblFilasMarcadas.Text = $"Filas marcadas: {_filasMarcadas}";
                }
            }
        }

        private void CmbAcciones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_filasMarcadas > 0)
            {
                if (CmbAcciones.SelectedItem.ToString() == "Eliminar")
                {
                    if (MessageBox.Show("¿Esta seguro de querer borrar a los asociados selecionados?", "Asociados: Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow fila in DgvListado.Rows)
                        {
                            if ((bool)fila.Cells["Seleccion"].Value == true)
                            {
                                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                                _asociadoLogic.Delete(id);
                            }
                        }

                        ActualizarListado(ref DgvListado, _asociadoLogic.List());
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
            else
            {
                MessageBox.Show("Por favor, seleccione una o mas filas!", "Acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbAcciones.SelectedIndex = 0;
            }
        }
    }
}