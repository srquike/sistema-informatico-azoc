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
    public partial class FrmEditarBeneficiario : Form
    {
        public Beneficiario Beneficiario { get; set; }

        public FrmEditarBeneficiario(int beneficiarioId)
        {
            InitializeComponent();
        }
        
        public FrmEditarBeneficiario(Beneficiario beneficiario)
        {
            InitializeComponent();
        }
    }
}
