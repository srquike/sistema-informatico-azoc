
namespace Reports.Formularios
{
    partial class FrmAgendaPagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CuotaReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RvAgendaPagos = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CuotaReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CuotaReportBindingSource
            // 
            this.CuotaReportBindingSource.DataSource = typeof(Reports.Models.CuotaReport);
            // 
            // RvAgendaPagos
            // 
            this.RvAgendaPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CuotasDataSet";
            reportDataSource1.Value = this.CuotaReportBindingSource;
            this.RvAgendaPagos.LocalReport.DataSources.Add(reportDataSource1);
            this.RvAgendaPagos.LocalReport.ReportEmbeddedResource = "Reports.Informes.RptAgendaPagos.rdlc";
            this.RvAgendaPagos.Location = new System.Drawing.Point(0, 0);
            this.RvAgendaPagos.Name = "RvAgendaPagos";
            this.RvAgendaPagos.ServerReport.BearerToken = null;
            this.RvAgendaPagos.Size = new System.Drawing.Size(800, 450);
            this.RvAgendaPagos.TabIndex = 0;
            // 
            // FrmAgendaPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RvAgendaPagos);
            this.Name = "FrmAgendaPagos";
            this.Text = "Cooperativa AZOC de R. L. - Agenda de pagos de cuota";
            this.Load += new System.EventHandler(this.FrmAgendaPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CuotaReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvAgendaPagos;
        private System.Windows.Forms.BindingSource CuotaReportBindingSource;
    }
}