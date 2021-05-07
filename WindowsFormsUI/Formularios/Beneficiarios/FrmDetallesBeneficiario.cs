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
    public partial class FrmDetallesBeneficiario : Form
    {
        public FrmDetallesBeneficiario(int beneficiarioId)
        {
            InitializeComponent();
        }

        public FrmDetallesBeneficiario(Beneficiario beneficiario)
        {
            InitializeComponent();
        }

        private void FrmDetallesBeneficiario_Load(object sender, EventArgs e)
        {

        }
    }
}
