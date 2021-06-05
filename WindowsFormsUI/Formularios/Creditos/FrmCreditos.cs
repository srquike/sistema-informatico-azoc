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
using System.Runtime.InteropServices;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCreditos : Form
    {
        private readonly CreditoBLL _creditoLogic;
        private readonly Usuario _usuarioLogeado;
        private readonly RegistroUsuarioBLL _registroUsuarioBLL;
        private int _filasMarcadas;

        public FrmCreditos(Usuario usuarioLogeado)
        {
            InitializeComponent();

            _creditoLogic = new CreditoBLL();
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

        private void ActualizarDataGridView(ref DataGridView dataGrid, IEnumerable<Credito> creditos)
        {
            dataGrid.Rows.Clear();

            foreach (Credito credito in creditos)
            {
                string fechaInicio = string.Format("{0:dd/MM/yyyy}", credito.Inicio);
                string monto = string.Format("{0:C}", credito.Monto);
                string nombreAsociado = string.Concat(credito.Socio.Pnombre, " ", credito.Socio.Snombre, " ", credito.Socio.Tnombre, " ", credito.Socio.Papellido, " ", credito.Socio.Sapellido, " ", credito.Socio.Tapellido);
                string tasaInteres = string.Format("{0:P2}", (credito.TasaInteres / 100));

                dataGrid.Rows.Add(false, credito.CreditoId, credito.Codigo, monto, tasaInteres, credito.Plazo, fechaInicio, credito.EstadoCredito.Nombre, nombreAsociado);
            }

            dataGrid.ClearSelection();
        }

        private void FrmCreditos_Load(object sender, EventArgs e)
        {
            CmbTipoFiltro.SelectedIndex = 0;
            ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
            CmbAcciones.SelectedIndex = 0;
            WindowState = FormWindowState.Maximized;
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            if (VerificarPermisos(2))
            {
                FrmCrearCredito frmCrear = new FrmCrearCredito();
                frmCrear.StartPosition = FormStartPosition.CenterParent;
                frmCrear.ShowDialog();

                if (frmCrear.DialogResult == DialogResult.OK)
                {
                    if (_usuarioLogeado != null)
                    {
                        RegistroUsuario registro = new RegistroUsuario
                        {
                            UsuarioId = _usuarioLogeado.UsuarioId,
                            RegistroId = 4,
                            Fecha = DateTime.Now,
                            Informacion = $"Creación de crédito por parte del usuario {_usuarioLogeado.Nombre}"
                        };

                        if (_registroUsuarioBLL.Create(registro) == false)
                        {
                            MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
                }
            }
            else
            {
                MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
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
                    if (e.ColumnIndex == 9)
                    {
                        if (VerificarPermisos(1))
                        {
                            FrmDetallesCredito frmDetalles = new FrmDetallesCredito(creditoId);
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
                    else if (e.ColumnIndex == 10)
                    {
                        if (VerificarPermisos(3))
                        {
                            Credito credito = _creditoLogic.Find(creditoId);

                            if (credito != null)
                            {
                                if (credito.EstadoCreditoId == 1)
                                {
                                    credito.EstadoCreditoId = 2;

                                    if (_creditoLogic.Edit(credito))
                                    {
                                        if (_usuarioLogeado != null)
                                        {
                                            RegistroUsuario registro = new RegistroUsuario
                                            {
                                                UsuarioId = _usuarioLogeado.UsuarioId,
                                                RegistroId = 1005,
                                                Fecha = DateTime.Now,
                                                Informacion = $"Aprobación de crédito por parte del usuario {_usuarioLogeado.Nombre}"
                                            };

                                            if (_registroUsuarioBLL.Create(registro) == false)
                                            {
                                                MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }

                                        ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al intentar aprobar el crédito, por favor intente de nuevo!", "Aprobar crédito: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se puede aprobar un crédito previamente aprobado o finalizado!", "Aprobar crédito: información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else if (e.ColumnIndex == 11)
                    {
                        if (VerificarPermisos(4))
                        {
                            if (MessageBox.Show("¿Esta seguro de querer eliminar el crédito del sistema?", "Eliminación de crédito: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (_creditoLogic.Delete(creditoId))
                                {
                                    if (_usuarioLogeado != null)
                                    {
                                        RegistroUsuario registro = new RegistroUsuario
                                        {
                                            UsuarioId = _usuarioLogeado.UsuarioId,
                                            RegistroId = 5,
                                            Fecha = DateTime.Now,
                                            Informacion = $"Eliminación de crédito por parte del usuario {_usuarioLogeado.Nombre}"
                                        };

                                        if (_registroUsuarioBLL.Create(registro) == false)
                                        {
                                            MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                    ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
                                }
                                else
                                {
                                    MessageBox.Show("Error al intentar eliminar el crédito, por favor intente de nuevo!", "Eliminar crédito: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

                var resultados = from credito in creditos where credito.CreditoId.ToString() == busqueda || credito.Socio.Pnombre == busqueda || credito.Socio.Papellido == busqueda select credito;

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
                    if (VerificarPermisos(4))
                    {
                        if (MessageBox.Show("¿Esta seguro de querer borrar los créditos selecionados?", "Créditos: Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow fila in DgvLista.Rows)
                            {
                                if ((bool)fila.Cells["Seleccion"].Value == true)
                                {
                                    int creditoId = Convert.ToInt32(fila.Cells["Id"].Value);
                                    string codigo = fila.Cells["Codigo"].Value.ToString();

                                    if (_creditoLogic.Delete(creditoId))
                                    {
                                        if (_usuarioLogeado != null)
                                        {
                                            RegistroUsuario registro = new RegistroUsuario
                                            {
                                                UsuarioId = _usuarioLogeado.UsuarioId,
                                                RegistroId = 5,
                                                Fecha = DateTime.Now,
                                                Informacion = $"Eliminación de crédito por parte del usuario {_usuarioLogeado.Nombre}"
                                            };

                                            if (_registroUsuarioBLL.Create(registro) == false)
                                            {
                                                MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show($"No fue posible eliminar el credito {codigo}, por favor intente nuevamente!", "Eliminar crédito: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
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
                    else
                    {
                        MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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