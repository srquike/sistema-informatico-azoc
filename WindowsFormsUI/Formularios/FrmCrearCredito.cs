using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System.Linq;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCrearCredito : Form
    {
        private readonly AsociadoBLL _asociadoLogic;
        private readonly CreditoBLL _creditoLogic;

        public FrmCrearCredito()
        {
            InitializeComponent();

            _asociadoLogic = new AsociadoBLL();
            _creditoLogic = new CreditoBLL();
        }

        private void ActualizarAsociados(ref ComboBox comboBox)
        {
            var asociados = _asociadoLogic.List();
            var asociadosNombres = (from asociado in asociados
                                   select new
                                   {
                                       Nombre = string.Concat(asociado.PrimerNombre, " ", asociado.SegundoNombre, " ", asociado.TercerNombre, " ", asociado.PrimerApellido, " ", asociado.SegundoApellido, " ", asociado.TercerApellido),
                                       Id = asociado.AsociadoId
                                   }).ToList();

            comboBox.DataSource = asociadosNombres;
            comboBox.DisplayMember = "Nombre";
            comboBox.ValueMember = "Id";
        }

        private void FrmCrearCredito_Load(object sender, EventArgs e)
        {
            ActualizarAsociados(ref CmbAsociados);
        }

        private void CmbAsociados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TxtCodigo.Text = CmbAsociados.SelectedValue.ToString();
        }
    }
}
