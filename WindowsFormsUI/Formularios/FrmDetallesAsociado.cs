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
        private readonly AsociadoBLL _asociadoLogic;
        private Asociado _asociado;

        public FrmDetallesAsociado(int asociadoId)
        {
            InitializeComponent();

            _asociadoLogic = new AsociadoBLL();
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
            string nombre = string.Concat(_asociado.PrimerNombre, " ", _asociado.SegundoNombre, " ", _asociado.TercerNombre, " ", _asociado.PrimerApellido, " ", _asociado.SegundoApellido, " ", _asociado.TercerApellido);
            string genero = _asociado.Genero == "F" ? "Femenino" : "Masculino";
            string estado = _asociado.Estado == "1" ? "Activo" : "Inactivo";

            TxtCodigo.Text = _asociado.AsociadoId.ToString();
            TxtCategoria.Text = _asociado.CategoriaAsociado.Nombre;
            TxtEstado.Text = estado;
            TxtNombre.Text = nombre;
            TxtFNacimiento.Text = _asociado.FechaNacimiento.ToShortDateString();
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
            RellenarControles();
        }
    }
}
