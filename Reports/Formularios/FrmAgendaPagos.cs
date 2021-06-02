using Microsoft.Reporting.WinForms;
using Reports.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reports.Formularios
{
    public partial class FrmAgendaPagos : Form
    {
        private ICollection<Cuota> _cuotas;

        public FrmAgendaPagos(ICollection<Cuota> cuotas)
        {
            InitializeComponent();

            _cuotas = cuotas;
        }

        private void FrmAgendaPagos_Load(object sender, EventArgs e)
        {
            RvAgendaPagos.LocalReport.DataSources.Clear();
            RvAgendaPagos.LocalReport.DisplayName = "Agenda de pagos de cuotas";
            RvAgendaPagos.SetDisplayMode(DisplayMode.PrintLayout);
            RvAgendaPagos.ZoomMode = ZoomMode.Percent;
            RvAgendaPagos.ZoomPercent = 100;
            RvAgendaPagos.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _cuotas));
            this.RvAgendaPagos.RefreshReport();
        }
    }
}
