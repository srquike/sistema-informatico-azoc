using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmDetallesUsuario : Form
    {
        private int _userId;

        public FrmDetallesUsuario(int userId)
        {
            InitializeComponent();

            _userId = userId;

            MessageBox.Show(_userId.ToString());
        }
    }
}
