using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessObjectsLayer.Models;
using BusinessLogicLayer.Logics;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmAgregarEmpleado : Form
    {
        private readonly CargoBLL _cargoLogic;
        public FrmAgregarEmpleado()
        {
            InitializeComponent();

            _cargoLogic = new CargoBLL();
        }

        private void CargarCargos(ref ComboBox comboBox)
        {
            var cargos = _cargoLogic.List();

            comboBox.DataSource = cargos;
            comboBox.DisplayMember = "Nombre";
            comboBox.ValueMember = "CargoId";

        }

        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            CargarCargos(ref CmbCargos);
        }
    }
}
