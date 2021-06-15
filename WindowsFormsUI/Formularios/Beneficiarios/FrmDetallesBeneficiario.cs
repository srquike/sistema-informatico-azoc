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
    public partial class FrmDetallesBeneficiario : Form
    {
        private readonly Beneficiario _beneficiario;
        private readonly BeneficiarioBLL _beneficiarioLogica = new BeneficiarioBLL();
        public FrmDetallesBeneficiario(int beneficiarioId)
        {
            InitializeComponent();

            _beneficiario = _beneficiarioLogica.Find(beneficiarioId);
        }

        public FrmDetallesBeneficiario(Beneficiario beneficiario)
        {
            InitializeComponent();

            _beneficiario = beneficiario;
        }

        private void LlenarControles()
        {
            if (_beneficiario != null)
            {
                string nombre = string.Concat(_beneficiario.PrimerNombre, " ", _beneficiario.SegundoNombre, " ", _beneficiario.TercerNombre, " ", _beneficiario.PrimerApellido, " ", _beneficiario.SegundoApellido, " ", _beneficiario.TercerApellido);

                TxtCodigo.Text = _beneficiario.BeneficiarioId.ToString();
                TxtPorcentaje.Text = string.Format("{0:P2}", (_beneficiario.Porcentaje / 100));
                TxtNombre.Text = nombre;
                TxtEmail.Text = _beneficiario.Email;
                TxtFNacimiento.Text = _beneficiario.FechaNacimiento.ToShortDateString();
                TxtGenero.Text = _beneficiario.Genero;
                TxtDireccion.Text = _beneficiario.Direccion;
                TxtDepartamento.Text = _beneficiario.Departamento;
                TxtMunicipio.Text = _beneficiario.Municipio;
                MTxtNit.Text = _beneficiario.Nit;
                MTxtDui.Text = _beneficiario.Dui;
                MTxtTelefono.Text = _beneficiario.Telefono;
            }
        }

        private void FrmDetallesBeneficiario_Load(object sender, EventArgs e)
        {
            LlenarControles();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
