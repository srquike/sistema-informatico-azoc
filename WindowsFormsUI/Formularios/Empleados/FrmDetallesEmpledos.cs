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
    public partial class FrmDetallesEmpledos : Form
    {
        private readonly EmpleadoBLL _empleadoLogic;
        private Empleado _empleado;

        public FrmDetallesEmpledos(int empleadoId)
        {
            InitializeComponent();

            _empleadoLogic = new EmpleadoBLL();
            _empleado = _empleadoLogic.Find(empleadoId);
        }

        private void FrmDetallesEmpledos_Load(object sender, EventArgs e)
        {
            TxtCodigo.Text = _empleado.EmpleadoId.ToString();
            TxtPNombre.Text = _empleado.PrimerNombre;
            TxtSNombre.Text = _empleado.SegundoNombre;
            TxtTNombre.Text = _empleado.TercerNombre;
            TxtPApellido.Text = _empleado.PrimerApellido;
            TxtSApellido.Text = _empleado.SegundoApellido;
            TxtTApellido.Text = _empleado.TercerApellido;
            TxtCargo.Text = _empleado.Cargo.Nombre;
            TxtEmail.Text = _empleado.Email;
            TxtFNacimiento.Text = _empleado.Nacimiento.ToShortDateString();

            if (_empleado.Genero == "F")
            {
                TxtGenero.Text = "Femenino";
            }
            else
            {
                TxtGenero.Text = "Masculino";
            }

            TxtDireccion.Text = _empleado.Direccion;
            TxtDepartamento.Text = _empleado.Departamento;
            TxtMunicipio.Text = _empleado.Municipio;
            MTxtNit.Text = _empleado.Nit;
            MTxtDui.Text = _empleado.Dui;
            MTxtTelefono.Text = _empleado.Telefono;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
