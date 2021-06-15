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

namespace WindowsFormsUI.Formularios
{
    public partial class FrmEditarBeneficiario : Form
    {
        private readonly BeneficiarioBLL _beneficiarioLogica = new BeneficiarioBLL();
        private bool _continuar = false;
        private bool _editar = false;
        private readonly decimal _porcentaje;

        public Beneficiario Beneficiario { get; set; }

        public FrmEditarBeneficiario(int beneficiarioId)
        {
            InitializeComponent();

            Beneficiario = _beneficiarioLogica.Find(beneficiarioId);
            _editar = true;
        }

        public FrmEditarBeneficiario(Beneficiario beneficiario, decimal porcentaje)
        {
            InitializeComponent();

            Beneficiario = beneficiario;
            _porcentaje = porcentaje;
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

                    if (CmbGeneros.SelectedIndex == 0)
                    {
                        ErrPControles.SetError(CmbGeneros, "Seleccione un genero!");
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

        private bool VerificarEntradasUnicas(string dui, string nit, string telefono)
        {
            if (!Beneficiario.Dui.Equals(dui) || !Beneficiario.Nit.Equals(nit) || !Beneficiario.Telefono.Equals(telefono))
            {
                var beneficiarios = _beneficiarioLogica.List();
                var resultado = (from beneficiario in beneficiarios where beneficiario.Dui == dui || beneficiario.Nit == nit || beneficiario.Telefono == telefono select beneficiario).FirstOrDefault();

                if (resultado == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void LlenarControles()
        {
            if (Beneficiario != null)
            {
                TxtCodigo.Text = Beneficiario.BeneficiarioId.ToString();
                NudPorcentaje.Value = Beneficiario.Porcentaje;
                NudPorcentaje.Maximum = _porcentaje > 0 ? _porcentaje : 100;
                TxtPNombre.Text = Beneficiario.PrimerNombre;
                TxtSNombre.Text = Beneficiario.SegundoNombre;
                TxtTNombre.Text = Beneficiario.TercerNombre;
                TxtPApellido.Text = Beneficiario.PrimerApellido;
                TxtSApellido.Text = Beneficiario.SegundoApellido;
                TxtTApellido.Text = Beneficiario.TercerApellido;
                TxtEmail.Text = Beneficiario.Email;
                DtpFNacimiento.Value = Beneficiario.FechaNacimiento;
                CmbGeneros.SelectedItem = Beneficiario.Genero;
                TxtDireccion.Text = Beneficiario.Direccion;
                CmbDepartamentos.SelectedItem = Beneficiario.Departamento;
                CmbMunicipios.SelectedItem = Beneficiario.Municipio;
                MTxtNit.Text = Beneficiario.Nit;
                MTxtDui.Text = Beneficiario.Dui;
                MTxtTelefono.Text = Beneficiario.Telefono;
            }
        }

        private void FrmEditarBeneficiario_Load(object sender, EventArgs e)
        {
            LlenarControles();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
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

                    int porcentaje = Convert.ToInt32(NudPorcentaje.Value);

                    Beneficiario.Codigo = TxtCodigo.Text;
                    Beneficiario.PrimerNombre = TxtPNombre.Text;
                    Beneficiario.SegundoNombre = TxtSNombre.Text;
                    Beneficiario.TercerNombre = TxtTNombre.Text;
                    Beneficiario.PrimerApellido = TxtPApellido.Text;
                    Beneficiario.SegundoApellido = TxtSApellido.Text;
                    Beneficiario.TercerApellido = TxtTApellido.Text;
                    Beneficiario.Email = TxtEmail.Text;
                    Beneficiario.FechaNacimiento = DtpFNacimiento.Value;
                    Beneficiario.Genero = genero;
                    Beneficiario.Direccion = TxtDireccion.Text;
                    Beneficiario.Departamento = departamento;
                    Beneficiario.Municipio = municipio;
                    Beneficiario.Nit = MTxtNit.Text;
                    Beneficiario.Dui = MTxtDui.Text;
                    Beneficiario.Telefono = MTxtTelefono.Text;
                    Beneficiario.Porcentaje = porcentaje;

                    if (_editar)
                    {
                        if (_beneficiarioLogica.Edit(Beneficiario) == false)
                        {
                            MessageBox.Show("No fue posible editar al beneficiario, por favor intente de nuevo!", "Editar beneficiario: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}