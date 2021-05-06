using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCrearAsociado : Form
    {
        private readonly AsociadoBLL _asociadoLogic;
        private readonly CategoriaAsociadoBLL _categoriaAsociadoLogic;

        public FrmCrearAsociado()
        {
            InitializeComponent();

            _asociadoLogic = new AsociadoBLL();
            _categoriaAsociadoLogic = new CategoriaAsociadoBLL();
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

        private void FrmCrearAsociado_Load(object sender, EventArgs e)
        {
            CmbAcciones.SelectedIndex = 0;
            CmbMunicipios.SelectedIndex = 0;
            CmbDepartamentos.SelectedIndex = 0;
            CmbGenero.SelectedIndex = 0;
            LlenarComboBoxCategorias(ref CmbCategoria);
        }
    }
}
