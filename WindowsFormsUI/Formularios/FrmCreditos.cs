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
    public partial class FrmCreditos : Form
    {
        private readonly CreditoBLL _creditoLogic;

        public FrmCreditos()
        {
            InitializeComponent();

            _creditoLogic = new CreditoBLL();
        }

        private void ActualizarDataGridView(ref DataGridView data, IEnumerable<Credito> creditos)
        {
            data.Rows.Clear();

            foreach (Credito credito in creditos)
            {
                string fechaInicio = string.Format("{0:dd/MM/yyyy}", credito.FechaInicio);
                string monto = string.Format("{0:C}", credito.Monto);
                string nombreAsociado = string.Concat(credito.Asociado.PrimerNombre, " ", credito.Asociado.SegundoNombre, " ", credito.Asociado.TercerNombre, " ", credito.Asociado.PrimerApellido, " ", credito.Asociado.SegundoApellido, " ", credito.Asociado.TercerNombre);

                data.Rows.Add(false, credito.CreditoId, monto, credito.TasaInteres, credito.Cuotas.Count, fechaInicio, credito.EstadoCredito.Nombre, nombreAsociado);
            }

            data.ClearSelection();
        }

        private void FrmCreditos_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView(ref DgvLista, _creditoLogic.List());
        }

        private void BtnCrearNuevo_Click(object sender, EventArgs e)
        {
            FrmCrearCredito frmCrear = new FrmCrearCredito();
            frmCrear.StartPosition = FormStartPosition.CenterParent;
            frmCrear.ShowDialog();
        }
    }
}
