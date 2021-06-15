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
    public partial class FrmEditarAsociado : Form
    {
        private Socio _asociado;
        private bool _continuar = false;
        private readonly SocioBLL _asociadoLogic;
        private readonly BeneficiarioBLL _beneficiarioLogic;
        private ICollection<Beneficiario> _beneficiarios;

        public FrmEditarAsociado(int asociadoId)
        {
            InitializeComponent();

            _asociadoLogic = new SocioBLL();
            _beneficiarioLogic = new BeneficiarioBLL();
            _beneficiarios = new List<Beneficiario>();
            _asociado = _asociadoLogic.Find(asociadoId);
        }

        private void LlenarListado(ref DataGridView dataGrid, ICollection<Beneficiario> beneficiarios)
        {
            dataGrid.Rows.Clear();

            foreach (Beneficiario beneficiario in beneficiarios)
            {
                string nombre = string.Concat(beneficiario.PrimerNombre, " ", beneficiario.SegundoNombre, " ", beneficiario.TercerNombre, " ", beneficiario.PrimerApellido, " ", beneficiario.SegundoApellido, " ", beneficiario.TercerApellido);

                dataGrid.Rows.Add(beneficiario.BeneficiarioId, beneficiario.Codigo, nombre, beneficiario.Dui, beneficiario.Nit, beneficiario.Telefono, beneficiario.Genero, beneficiario.Porcentaje);
            }

            dataGrid.ClearSelection();
        }

        private void LlenarControles()
        {
            if (_asociado != null)
            {
                TxtCodigo.Text = _asociado.Codigo;
                CmbCategoria.SelectedItem = _asociado.Categoria;
                TxtPNombre.Text = _asociado.Pnombre;
                TxtSNombre.Text = _asociado.Snombre;
                TxtTNombre.Text = _asociado.Tnombre;
                TxtPApellido.Text = _asociado.Papellido;
                TxtSApellido.Text = _asociado.Sapellido;
                TxtTApellido.Text = _asociado.Tapellido;
                TxtEmail.Text = _asociado.Email;
                DtpFNacimiento.Value = _asociado.Nacimiento.Value;
                CmbGenero.SelectedItem = _asociado.Genero;
                ChkEstado.Checked = _asociado.Estado == "Activo" ? true : false;
                TxtDireccion.Text = _asociado.Direccion;
                CmbDepartamentos.SelectedItem = _asociado.Departamento;
                CmbMunicipios.SelectedItem = _asociado.Municipio;
                MTxtDui.Text = _asociado.Dui;
                MTxtNit.Text = _asociado.Nit;
                MTxtTelefono.Text = _asociado.Telefono;
                _beneficiarios = _asociado.Beneficiarios;

                LlenarListado(ref DgvListado, _beneficiarios);
            }
        }

        private void FrmEditarAsociado_Load(object sender, EventArgs e)
        {
            LlenarControles();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private decimal ObtenerPorcentajeRestante()
        {
            decimal porcentaje = 0;

            if (_beneficiarios.Count > 0)
            {

                foreach (Beneficiario beneficiario in _beneficiarios)
                {
                    porcentaje += beneficiario.Porcentaje;
                }

                return 100 - porcentaje;
            }

            return porcentaje;
        }

        private void BtnAgregarBeneficiario_Click(object sender, EventArgs e)
        {
            if (_beneficiarios.Count < 6)
            {
                FrmCrearBeneficiario frmCrearBeneficiario = new FrmCrearBeneficiario(false, ObtenerPorcentajeRestante());
                frmCrearBeneficiario.StartPosition = FormStartPosition.CenterScreen;
                frmCrearBeneficiario.ShowDialog();

                if (frmCrearBeneficiario.DialogResult == DialogResult.OK)
                {
                    _beneficiarios.Add(frmCrearBeneficiario.Beneficiario);
                    LlenarListado(ref DgvListado, _beneficiarios);
                }
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dataGrid = (DataGridView)sender;

            //if (e.RowIndex >= 0)
            //{
            //    if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            //    {
            //        int beneficiarioId = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["Id"].Value);

            //        if (e.ColumnIndex == 8)
            //        {
            //            FrmEditarBeneficiario frmEditar = new FrmEditarBeneficiario(beneficiarioId);
            //            frmEditar.StartPosition = FormStartPosition.CenterScreen;
            //            frmEditar.ShowDialog();

            //            if (frmEditar.DialogResult == DialogResult.OK)
            //            {
            //                _beneficiarios.Remove(beneficiario);
            //                _beneficiarios.Add(frmEditar.Beneficiario);
            //                LlenarListado(ref DgvListado, _beneficiarios);
            //            }
            //        }
            //        else if (e.ColumnIndex == 9)
            //        {
            //            if (MessageBox.Show("¿Esta seguro de querer eliminar al beneficiario?", "Eliminar beneficiario: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //            {
            //                _beneficiarios.Remove(beneficiario);
            //                LlenarListado(ref dataGrid, _beneficiarios);
            //            }
            //        }
            //    }
            //}
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

                    if (CmbGenero.SelectedIndex == 0)
                    {
                        ErrPControles.SetError(CmbGenero, "Seleccione un genero!");
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

                            if (string.IsNullOrEmpty(TxtCodigo.Text))
                            {
                                ErrPControles.SetError(TxtCodigo, "El código es requerido");
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

        private void ActualizarBeneficiarios(int asociadoId)
        {
            var beneficiariosDiferentes = _asociado.Beneficiarios.Except(_beneficiarios).ToList();

            if (beneficiariosDiferentes.Count == 0)
            {
                var beneficiarios = _beneficiarios.Except(_asociado.Beneficiarios).ToList();

                foreach (Beneficiario beneficiario in beneficiarios)
                {
                    var busqueda = _beneficiarioLogic.Find(beneficiario.BeneficiarioId);

                    if (busqueda == null)
                    {
                        beneficiario.AsociadoId = asociadoId;
                        _beneficiarioLogic.Create(beneficiario);
                    }
                    else
                    {
                        _beneficiarioLogic.Delete(beneficiario.BeneficiarioId);
                    }
                }
            }
            else
            {
                foreach (Beneficiario beneficiario in beneficiariosDiferentes)
                {
                    var busqueda = _beneficiarioLogic.Find(beneficiario.BeneficiarioId);

                    if (busqueda == null)
                    {
                        beneficiario.AsociadoId = asociadoId;
                        _beneficiarioLogic.Create(beneficiario);
                    }
                    else
                    {
                        _beneficiarioLogic.Delete(beneficiario.BeneficiarioId);
                    }
                }
            }
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            ValidarEntradasRequeridas();

            if (_continuar)
            {
                string dui = MTxtDui.Text;
                string nit = MTxtNit.Text;
                string telefono = MTxtTelefono.Text;
                string codigo = TxtCodigo.Text;

                string genero = CmbGenero.SelectedIndex == 0
                        ? string.Empty
                        : CmbGenero.SelectedItem.ToString();

                string departamento = CmbDepartamentos.SelectedIndex == 0
                    ? string.Empty
                    : CmbDepartamentos.SelectedItem.ToString();

                string municipio = CmbMunicipios.SelectedIndex == 0
                    ? string.Empty
                    : CmbMunicipios.SelectedItem.ToString();

                string categoria = CmbCategoria.SelectedIndex == 0
                    ? string.Empty
                    : CmbCategoria.SelectedItem.ToString();

                string estado = ChkEstado.Checked ? "Activo" : "Inactivo";

                _asociado.Codigo = codigo;
                _asociado.Pnombre = TxtPNombre.Text;
                _asociado.Snombre = TxtSNombre.Text;
                _asociado.Tnombre = TxtTNombre.Text;
                _asociado.Papellido = TxtPApellido.Text;
                _asociado.Sapellido = TxtSApellido.Text;
                _asociado.Tapellido = TxtTApellido.Text;
                _asociado.Email = TxtEmail.Text;
                _asociado.Nacimiento = DtpFNacimiento.Value;
                _asociado.Genero = genero;
                _asociado.Direccion = TxtDireccion.Text;
                _asociado.Departamento = departamento;
                _asociado.Municipio = municipio;
                _asociado.Nit = nit;
                _asociado.Dui = dui;
                _asociado.Telefono = telefono;
                _asociado.Estado = estado;
                _asociado.Ingreso = DateTime.Today;
                _asociado.Categoria = categoria;

                if (_asociadoLogic.Edit(_asociado))
                {
                    ActualizarBeneficiarios(_asociado.SocioId);

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("El socio no pudo ser editado, por favor intente de nuevo", "Editar socio: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            else
            {
                e.Handled = true;
            }
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
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