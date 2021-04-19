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
    public partial class FrmUsuarios : Form
    {
        private UsuarioBLL _usuarioLogic;

        public FrmUsuarios()
        {
            InitializeComponent();

            _usuarioLogic = new UsuarioBLL();
        }
        private void RefrescarDataGridView(ref DataGridView dataGrid)
        {
            var usuarios = _usuarioLogic.List();

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

                dataGrid.Rows.Add(false, usuario.UsuarioId, usuario.Nombre, usuario.UltimoAcceso, string.Format("{0:dd/MM/yyyy}", usuario.FechaCreacion), estado, nombreEmpleado);
            }

            dataGrid.ClearSelection();
        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {

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
            RefrescarDataGridView(ref DgvListaUsuarios);
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

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

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            FrmCrearUsuario frmCrearUsuario = new FrmCrearUsuario();

            if (frmCrearUsuario.ShowDialog() == DialogResult.OK)
            {
                RefrescarDataGridView(ref DgvListaUsuarios);
            }
        }

        private void DgvListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[1].Value);

                if (e.ColumnIndex == 7)
                {
                    FrmDetallesUsuario detallesUsuario = new FrmDetallesUsuario(userId);
                    detallesUsuario.ShowDialog();
                    if (detallesUsuario.DialogResult == DialogResult.OK)
                    {
                        detallesUsuario.Close();
                    }
                }
                else if (e.ColumnIndex == 8)
                {
                    Usuario usuario = _usuarioLogic.Find(userId);
                    FrmEditarUsuario editarUsuario = new FrmEditarUsuario(usuario);
                    editarUsuario.ShowDialog();
                    if (editarUsuario.DialogResult == DialogResult.OK)
                    {
                        RefrescarDataGridView(ref DgvListaUsuarios);
                    }
                    else
                    {
                        editarUsuario.Close();
                    }
                }
                else if (e.ColumnIndex == 9)
                {
                    if (MessageBox.Show("¿Esta seguro de querer eliminar al usuario del sistema?", "Eliminación de usuario: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        _usuarioLogic.Delete(userId);
                        RefrescarDataGridView(ref DgvListaUsuarios);
                    }
                }
            }
            else if (dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                bool value = (bool)dataGridView.Rows[e.RowIndex].Cells[0].Value;

                if (value)
                {
                    dataGridView.Rows[e.RowIndex].Cells[0].Value = false;
                }
                else
                {
                    dataGridView.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }
    }
}