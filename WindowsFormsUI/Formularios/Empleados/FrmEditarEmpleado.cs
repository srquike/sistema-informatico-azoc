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
        private bool _continuar;

        public FrmEditarEmpleado(int empleadoId)
        {
            InitializeComponent();

            _empleadoLogic = new EmpleadoBLL();
            _cargoLogic = new CargoBLL();
            _empleado = _empleadoLogic.Find(empleadoId);
            _continuar = false;
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
        }

        private void CargarCargos(ref ComboBox comboBox)
        {
            var cargos = _cargoLogic.List();

            comboBox.DataSource = cargos;
            comboBox.DisplayMember = "Nombre";
            comboBox.ValueMember = "CargoId";
        }

        private void LlenarComboBoxes()
        {
            if (_empleado.Genero == "F")
            {
                CmbGeneros.SelectedIndex = 1;
            }
            else
            {
                CmbGeneros.SelectedIndex = 2;
            }

            CmbMunicipios.SelectedItem = _empleado.Municipio;
            CmbDepartamentos.SelectedItem = _empleado.Departamento;
            CmbCargos.SelectedItem = _empleado.Cargo.Nombre;
        }

        private void FrmEditarEmpleado_Load(object sender, EventArgs e)
        {
            LlenarControles();
            CargarCargos(ref CmbCargos);
            LlenarComboBoxes();
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
            if (!_empleado.Dui.Equals(dui) || !_empleado.Nit.Equals(nit) || !_empleado.Telefono.Equals(telefono))
            {
                var empleados = _empleadoLogic.List();
                var resultado = (from empleado in empleados where empleado.Dui == dui || empleado.Nit == nit || empleado.Telefono == telefono select empleado).FirstOrDefault();

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

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            ValidarEntradasRequeridas();

            if (_continuar)
            {
                string dui = MTxtDui.Text;
                string nit = MTxtNit.Text;
                string telefono = MTxtTelefono.Text;

                if (VerificarEntradasUnicas(dui, nit, telefono))
                {
                    _empleado.PrimerNombre = TxtPNombre.Text;
                    _empleado.SegundoNombre = TxtSNombre.Text;
                    _empleado.TercerNombre = TxtTNombre.Text;
                    _empleado.PrimerApellido = TxtPApellido.Text;
                    _empleado.SegundoApellido = TxtSApellido.Text;
                    _empleado.TercerApellido = TxtTApellido.Text;
                    _empleado.Nacimiento = DtpFNacimiento.Value;
                    _empleado.Municipio = CmbMunicipios.SelectedItem.ToString();
                    _empleado.Departamento = CmbDepartamentos.SelectedItem.ToString();
                    _empleado.Dui = MTxtDui.Text;
                    _empleado.Nit = MTxtNit.Text;
                    _empleado.Email = TxtEmail.Text;
                    _empleado.Direccion = TxtDireccion.Text;
                    _empleado.Telefono = MTxtTelefono.Text;
                    _empleado.CargoId = Convert.ToInt32(CmbCargos.SelectedValue);
                    _empleado.Genero = CmbCargos.SelectedItem.ToString() == "Femenino" ? "F" : "M";

                    if (_empleadoLogic.Edit(_empleado))
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No fue posible editar al empleado, por favor intente de nuevo!", "Editar empleado: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Ya exite un empleado con el mismo número de DUI, NIT o Teléfono!", "Editar empleado: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
