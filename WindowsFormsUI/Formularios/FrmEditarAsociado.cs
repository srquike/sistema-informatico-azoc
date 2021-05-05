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
    public partial class FrmEditarAsociado : Form
    {
        private Asociado _asociado;
        private readonly AsociadoBLL _asociadoLogic;

        public FrmEditarAsociado(int asociadoId)
        {
            InitializeComponent();

            _asociadoLogic = new AsociadoBLL();
            _asociado = _asociadoLogic.Find(asociadoId);
        }
    }
}
