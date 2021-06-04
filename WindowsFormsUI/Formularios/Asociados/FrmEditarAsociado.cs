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
        private readonly CategoriaAsociadoBLL _categoriaAsociadoLogic;
        private ICollection<Beneficiario> _beneficiarios;

        public FrmEditarAsociado(int asociadoId)
        {
            InitializeComponent();

            _asociadoLogic = new SocioBLL();
            _categoriaAsociadoLogic = new CategoriaAsociadoBLL();
            _beneficiarioLogic = new BeneficiarioBLL();
            _beneficiarios = new List<Beneficiario>();
            _asociado = _asociadoLogic.Find(asociadoId);
        }

        private void LlenarComboBoxCategorias(ref ComboBox combo)
        {
            var categorias = _categoriaAsociadoLogic.List();
            var items = (from categoria in categorias
                         select new
                         {
                             Id = categoria.CategoriaAsociadoId,
                             Nombre = categoria.Nombre
                         }).ToList();

            combo.DataSource = items;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";
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

        private void LlenarControles()
        {
            if (_asociado != null)
            {
                LlenarComboBoxCategorias(ref CmbCategoria);

                TxtCodigo.Text = _asociado.Codigo;
                CmbCategoria.SelectedItem = _asociado.CategoriaAsociado.Nombre;
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

                LlenarListado(ref DgvListado, _beneficiarios);
            }
        }

        private void FrmEditarAsociado_Load(object sender, EventArgs e)
        {
            foreach (Beneficiario beneficiario in _asociado.Beneficiarios)
            {
                _beneficiarios.Add(beneficiario);
            }

            LlenarControles();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAgregarBeneficiario_Click(object sender, EventArgs e)
        {
            if (_beneficiarios.Count < 6)
            {
                FrmCrearBeneficiario frmCrearBeneficiario = new FrmCrearBeneficiario(false);
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
            DataGridView dataGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    Beneficiario beneficiario = _beneficiarios.ElementAt(e.RowIndex);

                    if (e.ColumnIndex == 7)
                    {
                        FrmDetallesBeneficiario frmDetalles = new FrmDetallesBeneficiario(beneficiario);
                        frmDetalles.StartPosition = FormStartPosition.CenterScreen;
                        frmDetalles.ShowDialog();

                        if (frmDetalles.DialogResult == DialogResult.OK)
                        {
                            Close();
                        }
                    }
                    else if (e.ColumnIndex == 8)
                    {
                        FrmEditarBeneficiario frmEditar = new FrmEditarBeneficiario(beneficiario);
                        frmEditar.StartPosition = FormStartPosition.CenterScreen;
                        frmEditar.ShowDialog();

                        if (frmEditar.DialogResult == DialogResult.OK)
                        {
                            _beneficiarios.Remove(beneficiario);
                            _beneficiarios.Add(frmEditar.Beneficiario);
                            LlenarListado(ref DgvListado, _beneficiarios);
                        }
                    }
                    else if (e.ColumnIndex == 9)
                    {
                        if (MessageBox.Show("¿Esta seguro de querer eliminar al beneficiario?", "Eliminar beneficiario: Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            _beneficiarios.Remove(beneficiario);
                            LlenarListado(ref dataGrid, _beneficiarios);
                        }
                    }
                }
            }
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

                string genero = CmbGenero.SelectedItem.ToString();
                string departamento = CmbDepartamentos.SelectedItem.ToString();
                string municipio = CmbMunicipios.SelectedItem.ToString();
                int categoriaId = Convert.ToInt32(CmbCategoria.SelectedValue);
                string estado = ChkEstado.Checked ? "Activo" : "Inactivo";

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
                _asociado.CategoriaAsociadoId = categoriaId;

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
    }
}