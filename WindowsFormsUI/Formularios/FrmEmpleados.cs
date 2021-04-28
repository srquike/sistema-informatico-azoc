using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarEmpleado frmAgregar = new FrmAgregarEmpleado();
            frmAgregar.StartPosition = FormStartPosition.CenterParent;
            frmAgregar.ShowDialog();

            if (frmAgregar.DialogResult == DialogResult.OK)
            {
                // Actualizar DataGridView
            }
            else
            {
                frmAgregar.Close();
            }
        }
    }
}
