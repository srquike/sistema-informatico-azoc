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

        public Beneficiario Beneficiario { get; set; }

        public FrmEditarBeneficiario(int beneficiarioId)
        {
            InitializeComponent();

            Beneficiario = _beneficiarioLogica.Find(beneficiarioId);
            _editar = true;
        }

        public FrmEditarBeneficiario(Beneficiario beneficiario)
        {
            InitializeComponent();

            Beneficiario = beneficiario;
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
            TxtCodigo.Text = Beneficiario.BeneficiarioId.ToString();
            NudPorcentaje.Value = Beneficiario.Porcentaje;
            TxtPNombre.Text = Beneficiario.PrimerNombre;
            TxtSNombre.Text = Beneficiario.SegundoNombre;
            TxtTNombre.Text = Beneficiario.TercerNombre;
            TxtPApellido.Text = Beneficiario.PrimerApellido;
            TxtSApellido.Text = Beneficiario.SegundoApellido;
            TxtTApellido.Text = Beneficiario.TercerApellido;
            TxtEmail.Text = Beneficiario.Email;
            DtpFNacimiento.Value = Beneficiario.FechaNacimiento;
            CmbGeneros.SelectedItem = Beneficiario.Genero == "F" ? "Femenino" : "Masculino";
            TxtDireccion.Text = Beneficiario.Direccion;
            CmbDepartamentos.SelectedItem = Beneficiario.Departamento;
            CmbMunicipios.SelectedItem = Beneficiario.Municipio;
            MTxtNit.Text = Beneficiario.Nit;
            MTxtDui.Text = Beneficiario.Dui;
            MTxtTelefono.Text = Beneficiario.Telefono;
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
                    string genero = CmbGeneros.SelectedItem.ToString() == "Femenino" ? "F" : "M";
                    string departamento = CmbDepartamentos.SelectedItem.ToString();
                    string municipio = CmbMunicipios.SelectedItem.ToString();
                    int porcentaje = Convert.ToInt32(NudPorcentaje.Value);

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
    }
}
