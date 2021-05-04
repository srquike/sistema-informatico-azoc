using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCreditos : Form
    {
        private readonly CreditoBLL _creditoLogic;
        private int _filasMarcadas;

        public FrmCreditos()
        {
            InitializeComponent();

            _creditoLogic = new CreditoBLL();
        }

        private void ActualizarDataGridView(ref DataGridView dataGrid, IEnumerable<Credito> creditos)
        {
            dataGrid.Rows.Clear();

            foreach (Credito credito in creditos)
            {
                string fechaInicio = string.Format("{0:dd/MM/yyyy}", credito.FechaInicio);
                string monto = string.Format("{0:C}", credito.Monto);
                string nombreAsociado = string.Concat(credito.Asociado.PrimerNombre, " ", credito.Asociado.SegundoNombre, " ", credito.Asociado.TercerNombre, " ", credito.Asociado.PrimerApellido, " ", credito.Asociado.SegundoApellido, " ", credito.Asociado.TercerNombre);

                dataGrid.Rows.Add(false, credito.CreditoId, monto, credito.TasaInteres, credito.Cuotas.Count, fechaInicio, credito.EstadoCredito.Nombre, nombreAsociado);
            }

            dataGrid.ClearSelection();
        }

        private void FrmCreditos_Load(object sender, EventArgs e)
        {
            CmbTipoFiltro.SelectedIndex = 0;
            ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
            CmbAcciones.SelectedIndex = 0;
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            FrmCrearCredito frmCrear = new FrmCrearCredito();
            frmCrear.StartPosition = FormStartPosition.CenterParent;
            frmCrear.ShowDialog();
        }

        private void DgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                int creditoId = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells[1].Value);
                bool marcada = Convert.ToBoolean(dataGrid.Rows[e.RowIndex].Cells[0].Value);

                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (e.ColumnIndex == 8)
                    {
                        FrmDetallesCredito frmDetalles = new FrmDetallesCredito(creditoId);
                        frmDetalles.StartPosition = FormStartPosition.CenterParent;
                        frmDetalles.ShowDialog();

                        if (frmDetalles.DialogResult == DialogResult.OK)
                        {
                            frmDetalles.Close();
                        }
                    }
                    else if (e.ColumnIndex == 9)
                    {
                        FrmEditarCredito frmEditar = new FrmEditarCredito(creditoId);
                        frmEditar.StartPosition = FormStartPosition.CenterParent;
                        frmEditar.ShowDialog();

                        if (frmEditar.DialogResult == DialogResult.OK)
                        {
                            ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
                        }
                    }
                    else if (e.ColumnIndex == 10)
                    {
                        if (MessageBox.Show("¿Esta seguro de querer eliminar el crédito del sistema?", "Eliminación de crédito: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            _creditoLogic.Delete(creditoId);
                            ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
                        }
                    }
                }
                else if (dataGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (marcada)
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
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBusqueda.Text))
            {
                string busqueda = TxtBusqueda.Text;
                var creditos = _creditoLogic.List();

                var resultados = from credito in creditos where credito.CreditoId.ToString() == busqueda || credito.Asociado.PrimerNombre == busqueda || credito.Asociado.PrimerApellido == busqueda select credito;

                ActualizarDataGridView(ref DgvLista, resultados);
                LLblQuitarBusqueda.Enabled = true;
            }
        }

        private void LLblQuitarBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LLblQuitarBusqueda.Enabled = false;
            TxtBusqueda.Clear();
            ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
        }

        private void CmbAcciones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_filasMarcadas > 0)
            {
                if (CmbAcciones.SelectedItem.ToString() == "Eliminar")
                {
                    if (MessageBox.Show("¿Esta seguro de querer borrar los créditos selecionados?", "Créditos: Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow fila in DgvLista.Rows)
                        {
                            if ((bool)fila.Cells["Seleccion"].Value == true)
                            {
                                int creditoId = Convert.ToInt32(fila.Cells["Id"].Value);
                                _creditoLogic.Delete(creditoId);
                            }
                        }

                        ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
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
            }
        }
    }
}