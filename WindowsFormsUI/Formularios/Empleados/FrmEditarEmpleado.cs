using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;

namespace WindowsFormsUI.Formularios
{

    public partial class FrmEditarEmpleado : Form
    {
        private readonly EmpleadoBLL _empleadoLogic;
        private readonly CargoBLL _cargoLogic;
        private Empleado _empleado;

        public FrmEditarEmpleado(int empleadoId)
        {
            InitializeComponent();

            _empleadoLogic = new EmpleadoBLL();
            _cargoLogic = new CargoBLL();
            _empleado = _empleadoLogic.Find(empleadoId);
        }

        private void LlenarControles()
        {
            TxtPNombre.Text = _empleado.PrimerNombre;
            TxtSNombre.Text = _empleado.SegundoNombre;
            TxtTNombre.Text = _empleado.TercerNombre;
            TxtPApellido.Text = _empleado.PrimerApellido;
            TxtSApellido.Text = _empleado.SegundoApellido;
            TxtTApellido.Text = _empleado.TercerApellido;
            TxtEmail.Text = _empleado.Email;
            DtpFNacimiento.Value = _empleado.Nacimiento;
            TxtDireccion.Text = _empleado.Direccion;
            MTxtNit.Text = _empleado.Nit;
            MTxtDui.Text = _empleado.Dui;
            MTxtTelefono.Text = _empleado.Telefono;
            CmbGeneros.SelectedItem = _empleado.Genero == "F" ? "Femenino" : "Masculino";
            CmbMunicipios.SelectedItem = _empleado.Municipio == string.Empty ? "-- Seleccionar --" : _empleado.Municipio;
            CmbDepartamentos.SelectedItem = _empleado.Departamento == string.Empty ? "-- Seleccionar --" : _empleado.Departamento;
        }

        private void CargarCargos(ref ComboBox comboBox)
        {
            var cargos = _cargoLogic.List();

            comboBox.DataSource = cargos;
            comboBox.DisplayMember = "Nombre";
            comboBox.ValueMember = "CargoId";
            comboBox.SelectedItem = _empleado.Cargo.Nombre;
        }

        private void FrmEditarEmpleado_Load(object sender, EventArgs e)
        {
            if (_empleado != null)
            {
                CargarCargos(ref CmbCargos);
                LlenarControles();
            }
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            string municipio = CmbMunicipios.SelectedIndex == 0
                ? string.Empty
                : CmbMunicipios.SelectedItem.ToString();

            string departamento = CmbDepartamentos.SelectedIndex == 0
                ? string.Empty
                : CmbDepartamentos.SelectedItem.ToString();

            string genero = CmbGeneros.SelectedItem.ToString() == "Femenino"
                ? "F"
                : "M";

            int cargoId = Convert.ToInt32(CmbCargos.SelectedValue);

            _empleado.PrimerNombre = TxtPNombre.Text;
            _empleado.SegundoNombre = TxtSNombre.Text;
            _empleado.TercerNombre = TxtTNombre.Text;
            _empleado.PrimerApellido = TxtPApellido.Text;
            _empleado.SegundoApellido = TxtSApellido.Text;
            _empleado.TercerApellido = TxtTApellido.Text;
            _empleado.Nacimiento = DtpFNacimiento.Value;
            _empleado.Municipio = municipio;
            _empleado.Departamento = departamento;
            _empleado.Dui = MTxtDui.Text;
            _empleado.Nit = MTxtNit.Text;
            _empleado.Email = TxtEmail.Text;
            _empleado.Direccion = TxtDireccion.Text;
            _empleado.Telefono = MTxtTelefono.Text;
            _empleado.CargoId = cargoId;
            _empleado.Genero = genero;

            if (_empleadoLogic.Edit(_empleado))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No fue posible editar al empleado, por favor intente de nuevo!", "Editar empleado: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (char.IsSeparator(e.KeyChar))
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
