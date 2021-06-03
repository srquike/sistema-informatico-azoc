using Microsoft.Reporting.WinForms;
using Reports.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reports.Formularios
{
    public partial class FrmAgendaPagos : Form
    {
        private readonly int _creditoId;

        public FrmAgendaPagos(int creditoId)
        {
            InitializeComponent();

            _creditoId = creditoId;
        }

        private DataTable GetSPResult()
        {
            DataTable ResultsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AzocDbConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    using (SqlCommand command = new SqlCommand("GetCuotasCredito", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CreditoId", _creditoId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(ResultsTable);
                        }
                    }
                }
            }

            return ResultsTable;
        }

        private void FrmAgendaPagos_Load(object sender, EventArgs e)
        {
            //RvAgendaPagos.LocalReport.DataSources.Clear();
            //RvAgendaPagos.LocalReport.DisplayName = "Agenda de pagos de cuotas";
            //RvAgendaPagos.SetDisplayMode(DisplayMode.PrintLayout);
            //RvAgendaPagos.ZoomMode = ZoomMode.Percent;
            //RvAgendaPagos.ZoomPercent = 100;
            //RvAgendaPagos.LocalReport.DataSources.Add(new ReportDataSource("CreditoCuotasDataSet", GetSPResult()));
            //RvAgendaPagos.RefreshReport();
        }
    }
}
