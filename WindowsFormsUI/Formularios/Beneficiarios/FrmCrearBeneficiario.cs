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
        private bool _continuar;
        private bool _crear;
        public Beneficiario Beneficiario { get; set; }

        public FrmCrearBeneficiario(bool crear)
        {
            InitializeComponent();

            _beneficiarioLogic = new BeneficiarioBLL();
            _crear = crear;
        }

        private void FrmAgregarBeneficiario_Load(object sender, EventArgs e)
        {
            CmbDepartamentos.SelectedIndex = 0;
            CmbGeneros.SelectedIndex = 0;
            CmbMunicipios.SelectedIndex = 0;
        }

        private void ValidarEntradasRequeridas()
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

                        if (CmbDepartamentos.SelectedIndex == 0)
                        {
                            ErrPControles.SetError(CmbDepartamentos, "Seleccione un departamento!");
                        }
                        else
                        {
                            ErrPControles.Clear();

                            if (CmbMunicipios.SelectedIndex == 0)
                            {
                                ErrPControles.SetError(CmbMunicipios, "Seleccione un municipio!");
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

                                    if (MTxtNit.MaskFull == false)
                                    {
                                        ErrPControles.SetError(MTxtNit, "El número de NIT es requerido!");
                                    }
                                    else
                                    {
                                        ErrPControles.Clear();

                                        if (MTxtTelefono.MaskFull == false)
                                        {
                                            ErrPControles.SetError(MTxtTelefono, "El número de teléfono es requerido!");
                                        }
                                        else
                                        {
                                            ErrPControles.Clear();

                                            if (string.IsNullOrEmpty(TxtDireccion.Text))
                                            {
                                                ErrPControles.SetError(TxtDireccion, "La direccion es requerida!");
                                            }
                                            else
                                            {
                                                ErrPControles.Clear();
                                                _continuar = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            ValidarEntradasRequeridas();

            if (_continuar)
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

                    Beneficiario beneficiario = new Beneficiario()
                    {
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
                        Porcentaje = porcentaje
                    };

                    if (_crear)
                    {
                        _beneficiarioLogic.Create(beneficiario);
                    }
                    else
                    {
                        Beneficiario = beneficiario;
                    }

                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
