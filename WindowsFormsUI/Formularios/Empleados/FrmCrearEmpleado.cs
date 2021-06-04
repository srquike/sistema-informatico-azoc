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
        private bool _continuar;

        public FrmCrearEmpleado()
        {
            InitializeComponent();

            _cargoLogic = new CargoBLL();
            _empleadoLogic = new EmpleadoBLL();
            _continuar = false;
        }

        private void CargarCargos(ref ComboBox comboBox)
        {
            var cargos = _cargoLogic.List();

            comboBox.DataSource = cargos;
            comboBox.DisplayMember = "Nombre";
            comboBox.ValueMember = "CargoId";
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
            ValidarEntradasRequeridas();

            if (_continuar)
            {
                string dui = MTxtDui.Text;
                string nit = MTxtNit.Text;
                string telefono = MTxtTelefono.Text;

                if (VerificarEntradasUnicas(dui, nit, telefono))
                {
                    Empleado empleado = new Empleado
                    {
                        PrimerNombre = TxtPNombre.Text,
                        SegundoNombre = TxtSNombre.Text,
                        TercerNombre = TxtTNombre.Text,
                        PrimerApellido = TxtPApellido.Text,
                        SegundoApellido = TxtSApellido.Text,
                        TercerApellido = TxtTApellido.Text,
                        Nacimiento = DtpFNacimiento.Value,
                        Municipio = CmbMunicipios.SelectedItem.ToString(),
                        Departamento = CmbDepartamentos.SelectedItem.ToString(),
                        Dui = MTxtDui.Text,
                        Nit = MTxtNit.Text,
                        Email = TxtEmail.Text,
                        Direccion = TxtDireccion.Text,
                        Telefono = MTxtTelefono.Text,
                        CargoId = Convert.ToInt32(CmbCargos.SelectedValue)
                    };

                    if (CmbGeneros.SelectedItem.ToString() == "Femenino")
                    {
                        empleado.Genero = "F";
                    }
                    else if (CmbGeneros.SelectedItem.ToString() == "Masculino")
                    {
                        empleado.Genero = "M";
                    }

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
    }
}
