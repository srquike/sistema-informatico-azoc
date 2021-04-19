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
        private UsuarioBLL _usuario;
        public FrmUsuarios()
        {
            InitializeComponent();

            _usuario = new UsuarioBLL();
        }
        private void RefrescarDataGridView(ref DataGridView dataGrid)
        {
            var usuarios = _usuario.List();

            dataGrid.Rows.Clear();

            foreach (Usuario usuario in usuarios)
            {
                string nombreEmpleado = $"{usuario.Empleado.PrimerNombre} {usuario.Empleado.SegundoNombre} {usuario.Empleado.TercerNombre} {usuario.Empleado.PrimerApellido} {usuario.Empleado.SegundoApellido} {usuario.Empleado.TercerApellido}";

                dataGrid.Rows.Add(usuario.UsuarioId, usuario.Nombre, usuario.UltimoAcceso, string.Format("{0:dd/MM/yyyy}", usuario.FechaCreacion),"Activo", nombreEmpleado);
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
                switch (e.ColumnIndex)
                {
                    case 6:
                        int userId = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

                        FrmDetallesUsuario frmDetallesUsuario = new FrmDetallesUsuario(userId);
                        frmDetallesUsuario.Show();

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
