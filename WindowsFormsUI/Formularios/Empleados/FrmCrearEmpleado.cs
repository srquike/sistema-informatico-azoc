using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using BusinessObjectsLayer.Models;
using BusinessLogicLayer.Logics;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCrearEmpleado : Form
    {
        private readonly CargoBLL _cargoLogic;
        private readonly EmpleadoBLL _empleadoLogic;

        public FrmCrearEmpleado()
        {
            InitializeComponent();

            _cargoLogic = new CargoBLL();
            _empleadoLogic = new EmpleadoBLL();
        }

        private void CargarCargos(ref ComboBox comboBox)
        {
            var cargos = _cargoLogic.List();

            comboBox.DataSource = cargos;
            comboBox.DisplayMember = "Nombre";
            comboBox.ValueMember = "CargoId";
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
            var empleados = _empleadoLogic.List();
            var resultado = (from empleado in empleados where empleado.Dui == dui || empleado.Nit == nit || empleado.Telefono == telefono select empleado).FirstOrDefault();

            if (resultado == null)
            {
                return true;
            }

            return false;
        }

        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            CargarCargos(ref CmbCargos);
            CmbDepartamentos.SelectedIndex = 0;
            CmbGeneros.SelectedIndex = 0;
            CmbMunicipios.SelectedIndex = 0;
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
                    string municipio = CmbMunicipios.SelectedIndex == 0 
                        ? string.Empty 
                        : CmbMunicipios.SelectedItem.ToString();

                    string departamento = CmbDepartamentos.SelectedIndex == 0 
                        ? string.Empty 
                        : CmbDepartamentos.SelectedItem.ToString();

                    int cargoId = Convert.ToInt32(CmbCargos.SelectedValue);

                    string genero = CmbGeneros.SelectedItem.ToString() == "Femenino" 
                        ? "F" 
                        : "M";

                    Empleado empleado = new Empleado
                    {
                        PrimerNombre = TxtPNombre.Text,
                        SegundoNombre = TxtSNombre.Text,
                        TercerNombre = TxtTNombre.Text,
                        PrimerApellido = TxtPApellido.Text,
                        SegundoApellido = TxtSApellido.Text,
                        TercerApellido = TxtTApellido.Text,
                        Nacimiento = DtpFNacimiento.Value,
                        Municipio = municipio,
                        Departamento = departamento,
                        Dui = MTxtDui.Text,
                        Nit = MTxtNit.Text,
                        Email = TxtEmail.Text,
                        Direccion = TxtDireccion.Text,
                        Telefono = MTxtTelefono.Text,
                        CargoId = cargoId,
                        Genero = genero
                    };

                    if (_empleadoLogic.Create(empleado))
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No fue posible crear al empleado, por favor intente de nuevo!", "Crear empleado: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ya exite un empleado con el mismo número de DUI, NIT o Teléfono!", "Crear empleado: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void BtnLimpiarControles_Click(object sender, EventArgs e)
        {
            TxtPNombre.Clear();
            TxtSNombre.Clear();
            TxtTNombre.Clear();
            TxtPApellido.Clear();
            TxtSApellido.Clear();
            TxtTApellido.Clear();
            CmbGeneros.SelectedIndex = 0;
            TxtDireccion.Clear();
            CmbDepartamentos.SelectedIndex = 0;
            CmbMunicipios.SelectedIndex = 0;
            TxtEmail.Clear();
            MTxtDui.Clear();
            MTxtNit.Clear();
            MTxtTelefono.Clear();
            TxtPNombre.Focus();
        }
    }
}
