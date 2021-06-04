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
    public partial class FrmDetallesAsociado : Form
    {
        private readonly SocioBLL _asociadoLogic;
        private Socio _asociado;

        public FrmDetallesAsociado(int asociadoId)
        {
            InitializeComponent();

            _asociadoLogic = new SocioBLL();
            _asociado = _asociadoLogic.Find(asociadoId);
        }

        private void LlenarListado(ref DataGridView dataGrid, ICollection<Beneficiario> beneficiarios)
        {
            dataGrid.Rows.Clear();

            foreach (Beneficiario beneficiario in beneficiarios)
            {
                string nombre = string.Concat(beneficiario.PrimerNombre, " ", beneficiario.SegundoNombre, " ", beneficiario.TercerNombre, " ", beneficiario.PrimerApellido, " ", beneficiario.SegundoApellido, " ", beneficiario.TercerApellido);
                string genero = beneficiario.Genero == "F" ? "Femenino" : "Masculino";

                dataGrid.Rows.Add(beneficiario.BeneficiarioId, nombre, beneficiario.Dui, beneficiario.Nit, beneficiario.Telefono, genero, beneficiario.Porcentaje);
            }

            dataGrid.ClearSelection();
        }

        private void RellenarControles()
        {
            string nombre = string.Concat(_asociado.Pnombre, " ", _asociado.Snombre, " ", _asociado.Tnombre, " ", _asociado.Papellido, " ", _asociado.Sapellido, " ", _asociado.Tapellido);
            string genero = _asociado.Genero;
            string estado = _asociado.Estado;

            TxtCodigo.Text = _asociado.Codigo;
            TxtCategoria.Text = _asociado.CategoriaAsociado.Nombre;
            TxtEstado.Text = estado;
            TxtNombre.Text = nombre;
            TxtFNacimiento.Text = _asociado.Nacimiento.Value.ToShortDateString();
            TxtGenero.Text = genero;
            TxtEmail.Text = _asociado.Email;
            TxtDireccion.Text = _asociado.Direccion;
            TxtDepartamento.Text = _asociado.Departamento;
            TxtMunicipio.Text = _asociado.Municipio;
            MTxtDui.Text = _asociado.Dui;
            MTxtNit.Text = _asociado.Nit;
            MTxtTelefono.Text = _asociado.Telefono;
            TxtFIngreso.Text = _asociado.Ingreso.ToShortDateString();
            TxtFRetiro.Text = _asociado.Retiro.ToString();

            LlenarListado(ref DgvListado, _asociado.Beneficiarios);
        }

        private void FrmDetallesAsociado_Load(object sender, EventArgs e)
        {
            if (_asociado != null)
            {
                RellenarControles();
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                int beneficiarioId = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["Id"].Value);

                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (e.ColumnIndex == 7)
                    {
                        FrmDetallesBeneficiario frmDetalles = new FrmDetallesBeneficiario(beneficiarioId);
                        frmDetalles.StartPosition = FormStartPosition.CenterScreen;
                        frmDetalles.ShowDialog();

                        if (frmDetalles.DialogResult == DialogResult.OK)
                        {
                            frmDetalles.Close();
                        }
                    }
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
