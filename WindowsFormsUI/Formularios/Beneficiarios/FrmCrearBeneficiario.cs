using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessObjectsLayer.Models;
using BusinessLogicLayer.Logics;
using System.Linq;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCrearBeneficiario : Form
    {
        private readonly BeneficiarioBLL _beneficiarioLogic;
        private bool _crear;
        private readonly decimal _porcentaje;

        public Beneficiario Beneficiario { get; set; }

        public FrmCrearBeneficiario(bool crear, decimal porcentaje)
        {
            InitializeComponent();

            _beneficiarioLogic = new BeneficiarioBLL();
            _crear = crear;
            _porcentaje = porcentaje;
        }

        private void FrmAgregarBeneficiario_Load(object sender, EventArgs e)
        {
            CmbDepartamentos.SelectedIndex = 0;
            CmbGeneros.SelectedIndex = 0;
            CmbMunicipios.SelectedIndex = 0;
            NudPorcentaje.Value = _porcentaje;
            NudPorcentaje.Maximum = _porcentaje > 0 ? _porcentaje : 100;
        }

        private bool ValidarEntradasRequeridas()
        {
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

            return false;
        }

        private bool VerificarEntradasUnicas(string dui, string nit, string telefono)
        {
            var beneficiarios = _beneficiarioLogic.List();
            var resultado = (from beneficiario in beneficiarios where beneficiario.Dui == dui || beneficiario.Nit == nit || beneficiario.Telefono == telefono select beneficiario).FirstOrDefault();

            if (resultado == null)
            {
                return true;
            }

            return false;
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarEntradasRequeridas())
            {
                string dui = MTxtDui.Text;
                string nit = MTxtNit.Text;
                string telefono = MTxtTelefono.Text;

                if (VerificarEntradasUnicas(dui, nit, telefono))
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

                    Beneficiario beneficiario = new Beneficiario()
                    {
                        Codigo = TxtCodigo.Text,
                        PrimerNombre = TxtPNombre.Text,
                        SegundoNombre = TxtSNombre.Text,
                        TercerNombre = TxtTNombre.Text,
                        PrimerApellido = TxtPApellido.Text,
                        SegundoApellido = TxtSApellido.Text,
                        TercerApellido = TxtTApellido.Text,
                        Email = TxtEmail.Text,
                        FechaNacimiento = DtpFNacimiento.Value,
                        Genero = genero,
                        Direccion = TxtDireccion.Text,
                        Departamento = departamento,
                        Municipio = municipio,
                        Nit = MTxtNit.Text,
                        Dui = MTxtDui.Text,
                        Telefono = MTxtTelefono.Text,
                        Porcentaje = NudPorcentaje.Value
                    };

                    if (_crear)
                    {
                        if (_beneficiarioLogic.Create(beneficiario) == false)
                        {
                            MessageBox.Show("No fue posible crear al beneficiario, por favor intente de nuevo!", "Crear beneficiario: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (beneficiario != null)
                        {
                            Beneficiario = beneficiario;
                        }
                        else
                        {
                            MessageBox.Show("No fue posible agregar al beneficiario, por favor intente de nuevo!", "Crear beneficiario: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtCodigo.Clear();
            NudPorcentaje.Value = 0;
            TxtPNombre.Clear();
            TxtSNombre.Clear();
            TxtTNombre.Clear();
            TxtPApellido.Clear();
            TxtSApellido.Clear();
            TxtTApellido.Clear();
            TxtEmail.Clear();
            CmbGeneros.SelectedIndex = 0;
            TxtDireccion.Clear();
            CmbDepartamentos.SelectedIndex = 0;
            CmbMunicipios.SelectedIndex = 0;
            MTxtDui.Clear();
            MTxtNit.Clear();
            MTxtTelefono.Clear();
            TxtCodigo.Focus();
        }
    }
}
