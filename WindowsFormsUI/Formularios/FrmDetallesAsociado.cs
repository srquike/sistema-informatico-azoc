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

        private void RellenarControles()
        {
            string nombre = string.Concat(_asociado.PrimerNombre, " ", _asociado.SegundoNombre, " ", _asociado.TercerNombre, " ", _asociado.PrimerApellido, " ", _asociado.SegundoApellido, " ", _asociado.TercerApellido);
            string genero = _asociado.Genero == "F" ? "Femenino" : "Masculino";

            TxtCodigo.Text = _asociado.AsociadoId.ToString();
            TxtCategoria.Text = _asociado.CategoriaAsociado.Nombre;
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
        }

        private void FrmDetallesAsociado_Load(object sender, EventArgs e)
        {
            RellenarControles();
        }
    }
}
