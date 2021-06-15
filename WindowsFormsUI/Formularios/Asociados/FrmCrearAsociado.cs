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
    public partial class FrmCrearAsociado : Form
    {
        private readonly SocioBLL _asociadoLogic;
        private readonly BeneficiarioBLL _beneficiarioLogic;
        private IList<Beneficiario> _beneficiarios;

        public FrmCrearAsociado()
        {
            InitializeComponent();

            _asociadoLogic = new SocioBLL();
            _beneficiarioLogic = new BeneficiarioBLL();
            _beneficiarios = new List<Beneficiario>();
        }

        private void ActualizarListado(ref DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();

            foreach (Beneficiario beneficiario in _beneficiarios)
            {
                string nombre = string.Concat(beneficiario.PrimerNombre, " ", beneficiario.SegundoNombre, " ", beneficiario.TercerNombre, " ", beneficiario.PrimerApellido, " ", beneficiario.SegundoApellido, " ", beneficiario.TercerApellido);

                dataGrid.Rows.Add(false, beneficiario.Codigo, nombre, beneficiario.Dui, beneficiario.Nit, beneficiario.Telefono, beneficiario.Genero, beneficiario.Porcentaje);
            }

            dataGrid.ClearSelection();
        }

        private void FrmCrearAsociado_Load(object sender, EventArgs e)
        {
            CmbMunicipios.SelectedIndex = 0;
            CmbDepartamentos.SelectedIndex = 0;
            CmbGeneros.SelectedIndex = 0;
            CmbCategoria.SelectedIndex = 0;
        }

        private decimal ObtenerPorcentajeRestante()
        {
            decimal porcentaje = 0;

            if (_beneficiarios.Count > 0)
            {

                foreach (Beneficiario beneficiario in _beneficiarios)
                {
                    porcentaje += beneficiario.Porcentaje;
                }

                if (porcentaje == 100)
                {
                    return 0.00M;
                }
                else
                {
                    return porcentaje;
                }
            }

            return porcentaje;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (_beneficiarios.Count < 6)
            {
                FrmCrearBeneficiario crearBeneficiario = new FrmCrearBeneficiario(false, ObtenerPorcentajeRestante());
                crearBeneficiario.StartPosition = FormStartPosition.CenterParent;
                crearBeneficiario.ShowDialog();

                if (crearBeneficiario.DialogResult == DialogResult.OK)
                {
                    _beneficiarios.Add(crearBeneficiario.Beneficiario);
                    ActualizarListado(ref DgvListado);
                }
                else
                {
                    crearBeneficiario.Close();
                }
            }
            else
            {
                MessageBox.Show("El socio solo puede tener 6 beneficiarios!", "Beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dataGrid = (DataGridView)sender;
                Beneficiario beneficiario = _beneficiarios[e.RowIndex];
                bool marcada = (bool)dataGrid.Rows[e.RowIndex].Cells["Seleccion"].Value;

                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (e.ColumnIndex == 8)
                    {
                        FrmDetallesBeneficiario frmDetalles = new FrmDetallesBeneficiario(beneficiario);
                        frmDetalles.StartPosition = FormStartPosition.CenterParent;
                        frmDetalles.ShowDialog();

                        if (frmDetalles.DialogResult == DialogResult.OK)
                        {
                            frmDetalles.Close();
                        }
                    }
                    else if (e.ColumnIndex == 9)
                    {
                        FrmEditarBeneficiario frmEditar = new FrmEditarBeneficiario(beneficiario, ObtenerPorcentajeRestante());
                        frmEditar.StartPosition = FormStartPosition.CenterParent;
                        frmEditar.ShowDialog();

                        if (frmEditar.DialogResult == DialogResult.OK)
                        {
                            _beneficiarios.RemoveAt(e.RowIndex);
                            _beneficiarios.Insert(e.RowIndex, frmEditar.Beneficiario);
                            ActualizarListado(ref dataGrid);
                        }
                    }
                    else if (e.ColumnIndex == 10)
                    {
                        if (MessageBox.Show("¿Esta seguro de querer eliminar al beneficiario?", "Eliminación de beneficiario: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            _beneficiarios.RemoveAt(e.RowIndex);
                            ActualizarListado(ref dataGrid);
                        }
                    }
                }
            }
        }

        private bool ValidarEntradasRequeridas()
        {
            if (string.IsNullOrEmpty(TxtCodigo.Text))
            {
                ErrPControles.SetError(TxtCodigo, "El código es requerido");
            }
            else
            {
                ErrPControles.Clear();

                if (string.IsNullOrEmpty(TxtPNombre.Text))
                {
                    ErrPControles.SetError(TxtPNombre, "El primer nombre es requerido!");
                }
                else
                {
                    ErrPControles.Clear();

                    if (string.IsNullOrEmpty(TxtPApellido.Text))
                    {
                        ErrPControles.SetError(TxtPApellido, "El primer apellido es requerido!");
                    }
                    else
                    {
                        ErrPControles.Clear();

                        if (MTxtDui.MaskFull == false)
                        {
                            ErrPControles.SetError(MTxtDui, "El número de DUI es requerido!");
                        }
                        else
                        {
                            ErrPControles.Clear();
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool VerificarEntradasUnicas(string dui, string nit, string telefono, string id)
        {
            var asociados = _asociadoLogic.List();
            var resultado = (from asociado in asociados where asociado.Dui == dui || asociado.Nit == nit || asociado.Telefono == telefono || asociado.Codigo == id select asociado).FirstOrDefault();

            if (resultado == null)
            {
                return true;
            }

            return false;
        }

        private void AgregarBeneficiarios(int asociadoId)
        {
            if (_beneficiarios.Count > 0)
            {
                foreach (Beneficiario beneficiario in _beneficiarios)
                {
                    beneficiario.AsociadoId = asociadoId;
                }

                if (_beneficiarioLogic.CreateMany(_beneficiarios) == false)
                {
                    MessageBox.Show("No se pudo agregar a los beneficiarios, por favor intente de nuevo!", "Agregar beneficiarios: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarEntradasRequeridas())
            {
                string dui = MTxtDui.Text;
                string nit = MTxtNit.Text;
                string telefono = MTxtTelefono.Text;
                string asociadoId = TxtCodigo.Text;

                if (VerificarEntradasUnicas(dui, nit, telefono, asociadoId))
                {
                    string genero = CmbGeneros.SelectedIndex == 0
                        ? string.Empty
                        : CmbGeneros.SelectedItem.ToString();

                    string departamento = CmbDepartamentos.SelectedIndex == 0
                        ? string.Empty
                        : CmbDepartamentos.SelectedItem.ToString();

                    string municipio = CmbMunicipios.SelectedIndex == 0
                        ? string.Empty
                        : CmbMunicipios.SelectedItem.ToString();

                    string categoria = CmbCategoria.SelectedIndex == 0
                        ? string.Empty
                        : CmbCategoria.SelectedItem.ToString();

                    Socio asociado = new Socio()
                    {
                        Codigo = asociadoId,
                        Pnombre = TxtPNombre.Text,
                        Snombre = TxtSNombre.Text,
                        Tnombre = TxtTNombre.Text,
                        Papellido = TxtPApellido.Text,
                        Sapellido = TxtSApellido.Text,
                        Tapellido = TxtTApellido.Text,
                        Email = TxtEmail.Text,
                        Nacimiento = DtpFNacimiento.Value,
                        Genero = genero,
                        Direccion = TxtDireccion.Text,
                        Departamento = departamento,
                        Municipio = municipio,
                        Nit = nit,
                        Dui = dui,
                        Telefono = telefono,
                        Estado = "Activo",
                        Ingreso = DateTime.Today,
                        Categoria = categoria
                    };

                    if (_asociadoLogic.Create(asociado))
                    {
                        AgregarBeneficiarios(asociado.SocioId);

                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No fue posible crear al socio, por favor intente de nuevo!", "Crear socio: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}