﻿using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmAsociados : Form
    {
        private readonly SocioBLL _asociadoLogic;
        private readonly RegistroUsuarioBLL _registroUsuarioBLL;
        private readonly Usuario _usuarioLogeado;
        private int _filasMarcadas;

        public FrmAsociados(Usuario usuarioLogeado)
        {
            InitializeComponent();

            _asociadoLogic = new SocioBLL();
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

        private void ActualizarListado(ref DataGridView dataGrid, IEnumerable<Socio> asociados)
        {
            dataGrid.Rows.Clear();

            foreach (Socio asociado in asociados)
            {
                string nombreAsociado = string.Concat(asociado.Pnombre, " ", asociado.Snombre, " ", asociado.Tnombre, " ",
                    asociado.Papellido, " ", asociado.Sapellido, " ", asociado.Tapellido);

                dataGrid.Rows.Add(false, asociado.SocioId, asociado.Codigo, nombreAsociado, asociado.Dui, asociado.Nit, asociado.Genero, asociado.Telefono, asociado.Categoria, asociado.Estado);
            }

            dataGrid.ClearSelection();
        }

        private void FrmAsociados_Load(object sender, EventArgs e)
        {
            CmbAcciones.SelectedIndex = 0;
            CmbTipoFiltro.SelectedIndex = 0;
            ActualizarListado(ref DgvListado, _asociadoLogic.List());
            WindowState = FormWindowState.Maximized;
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            if (VerificarPermisos(2))
            {
                FrmCrearAsociado frmCrear = new FrmCrearAsociado();
                frmCrear.StartPosition = FormStartPosition.CenterParent;
                frmCrear.ShowDialog();

                if (frmCrear.DialogResult == DialogResult.OK)
                {
                    if (_usuarioLogeado != null)
                    {
                        RegistroUsuario registro = new RegistroUsuario
                        {
                            UsuarioId = _usuarioLogeado.UsuarioId,
                            RegistroId = 10,
                            Fecha = DateTime.Now,
                            Informacion = $"Creación de socio por parte del usuario {_usuarioLogeado.Nombre}"
                        };

                        if (_registroUsuarioBLL.Create(registro) == false)
                        {
                            MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    ActualizarListado(ref DgvListado, _asociadoLogic.List());
                }
            }
            else
            {
                MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBusqueda.Text))
            {
                string busqueda = TxtBusqueda.Text;
                var asociados = _asociadoLogic.List();

                var resultados = from asociado in asociados where asociado.Pnombre.Contains(busqueda) || asociado.Papellido.Contains(busqueda) || asociado.Dui == busqueda || asociado.Nit == busqueda || asociado.Telefono == busqueda select asociado;

                ActualizarListado(ref DgvListado, resultados);
                LLblQuitarBusqueda.Enabled = true;
            }
        }

        private void CmbTipoFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbTipoFiltro.SelectedItem.ToString() == "Genero")
            {
                CmbFiltro.Items.Add("Masculino");
                CmbFiltro.Items.Add("Femenino");
                CmbFiltro.SelectedIndex = 0;
            }
            else if (CmbTipoFiltro.SelectedItem.ToString() == "Categoria")
            {
                string[] categorias = new string[]
                {
                    "Zafrero",
                    "Temporal",
                    "Perpetuo"
                };

                CmbFiltro.Items.AddRange(categorias);
            }
            else
            {
                CmbFiltro.Items.Clear();
            }
        }

        private void BtnAplicarFiltro_Click(object sender, EventArgs e)
        {
            var asociados = _asociadoLogic.List();
            LLblQuitarFiltro.Enabled = true;

            if (CmbTipoFiltro.SelectedItem.ToString() == "Genero")
            {
                string genero = CmbFiltro.SelectedItem.ToString();

                var resultados = from asociado in asociados where asociado.Genero == genero select asociado;

                ActualizarListado(ref DgvListado, resultados);
            }
            else if (CmbTipoFiltro.SelectedItem.ToString() == "Categoria")
            {
                string categoria = CmbFiltro.SelectedItem.ToString();
                var resultados = from asociado in asociados where asociado.Categoria == categoria select asociado;

                ActualizarListado(ref DgvListado, resultados);
            }
            else
            {
                CmbFiltro.Items.Clear();
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
            CmbFiltro.Items.Clear();
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
                    if (e.ColumnIndex == 10)
                    {
                        if (VerificarPermisos(1))
                        {
                            FrmDetallesAsociado frmDetalles = new FrmDetallesAsociado(asociadoId);
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
                    else if (e.ColumnIndex == 11)
                    {
                        if (VerificarPermisos(3))
                        {
                            FrmEditarAsociado frmEditar = new FrmEditarAsociado(asociadoId);
                            frmEditar.StartPosition = FormStartPosition.CenterParent;
                            frmEditar.ShowDialog();

                            if (frmEditar.DialogResult == DialogResult.OK)
                            {
                                if (_usuarioLogeado != null)
                                {
                                    RegistroUsuario registro = new RegistroUsuario
                                    {
                                        UsuarioId = _usuarioLogeado.UsuarioId,
                                        RegistroId = 12,
                                        Fecha = DateTime.Now,
                                        Informacion = $"Modificación de socio por parte del usuario {_usuarioLogeado.Nombre}"
                                    };

                                    if (_registroUsuarioBLL.Create(registro) == false)
                                    {
                                        MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                ActualizarListado(ref DgvListado, _asociadoLogic.List());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else if (e.ColumnIndex == 12)
                    {
                        if (VerificarPermisos(4))
                        {
                            if (MessageBox.Show("¿Esta seguro de querer eliminar al socio del sistema?", "Eliminación de socio: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (_asociadoLogic.Delete(asociadoId))
                                {
                                    if (_usuarioLogeado != null)
                                    {
                                        RegistroUsuario registro = new RegistroUsuario
                                        {
                                            UsuarioId = _usuarioLogeado.UsuarioId,
                                            RegistroId = 11,
                                            Fecha = DateTime.Now,
                                            Informacion = $"Eliminación de socio por parte del usuario {_usuarioLogeado.Nombre}"
                                        };

                                        if (_registroUsuarioBLL.Create(registro) == false)
                                        {
                                            MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                    ActualizarListado(ref dataGrid, _asociadoLogic.List());
                                }
                                else
                                {
                                    MessageBox.Show("No fue posible eliminar al socio, por favor intente de nuevo!", "Eliminar socio: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

                    LLblQuitarMarcadas.Enabled = _filasMarcadas > 0 ? true : false;
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
                    if (VerificarPermisos(4))
                    {
                        if (MessageBox.Show("¿Esta seguro de querer borrar a los socios selecionados?", "Eliminar socios: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow fila in DgvListado.Rows)
                            {
                                if ((bool)fila.Cells["Seleccion"].Value == true)
                                {
                                    int id = Convert.ToInt32(fila.Cells["Id"].Value);
                                    string codigo = fila.Cells["Codigo"].Value.ToString();

                                    if (_asociadoLogic.Delete(id))
                                    {
                                        if (_usuarioLogeado != null)
                                        {
                                            RegistroUsuario registro = new RegistroUsuario
                                            {
                                                UsuarioId = _usuarioLogeado.UsuarioId,
                                                RegistroId = 11,
                                                Fecha = DateTime.Now,
                                                Informacion = $"Eliminación de socio por parte del usuario {_usuarioLogeado.Nombre}"
                                            };

                                            if (_registroUsuarioBLL.Create(registro) == false)
                                            {
                                                MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show($"No fue posible eliminar al socio {codigo}, por favor intente de nuevo!", "Eliminar socio: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
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
                    else
                    {
                        MessageBox.Show("Este usuario no tiene los permisos necesarios para realizar esta acción!", "Autorización: error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        #region Codigo para la barra superior del formulario

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {

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

        private void CmbFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void LLblQuitarMarcadas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_filasMarcadas > 0)
            {
                bool marcada;

                foreach (DataGridViewRow fila in DgvListado.Rows)
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