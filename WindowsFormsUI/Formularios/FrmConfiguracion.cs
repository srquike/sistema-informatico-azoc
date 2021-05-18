using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Data.SqlClient;
using System.IO;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void BtnRespaldar_Click(object sender, EventArgs e)
        {
            if (FbdUbicacion.ShowDialog() == DialogResult.OK)
            {
                PbProgreso.Value = 0;

                try
                {
                    Server server = new Server(new ServerConnection("DESKTOP-2NF0HEH\\SQLEXPRESS", "sa", "_Mi@Sqlserver$Jevc&27!"));
                    Backup backup = new Backup()
                    {
                        Action = BackupActionType.Database,
                        Database = "AzocDb"
                    };

                    string archivo = string.Concat(FbdUbicacion.SelectedPath, "\\AzocDb-", DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second, ".bak");

                    backup.Devices.AddDevice(archivo, DeviceType.File);
                    backup.Initialize = true;
                    backup.PercentComplete += Backup_PercentComplete;
                    backup.Complete += Backup_Complete;
                    backup.SqlBackup(server);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.Data + ex.InnerException, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Backup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                LblEstado.Invoke((MethodInvoker)delegate
                {
                    LblEstado.Text = e.Error.Message;
                });
            }
        }

        private void Backup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            PbProgreso.Invoke((MethodInvoker)delegate
            {
                PbProgreso.Value = e.Percent;
                PbProgreso.Update();
            });

            LblPorcentaje.Invoke((MethodInvoker)delegate
            {
                LblPorcentaje.Text = $"{e.Percent} %";
            });
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            if (OfdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                PbProgreso.Value = 0;

                try
                {
                    Server server = new Server(new ServerConnection("DESKTOP-2NF0HEH\\SQLEXPRESS", "sa", "_Mi@Sqlserver$Jevc&27!"));
                    Restore restore = new Restore()
                    {
                        Database = "AzocDb",
                        Action = RestoreActionType.Database,
                        ReplaceDatabase = true,
                        NoRecovery = false
                    };

                    server.KillAllProcesses(restore.Database);
                    restore.Devices.AddDevice(OfdSeleccionar.FileName, DeviceType.File);
                    restore.PercentComplete += Restore_PercentComplete;
                    restore.Complete += Restore_Complete;
                    restore.SqlRestore(server);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.Data + ex.InnerException, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Restore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            PbProgreso.Invoke((MethodInvoker)delegate
            {
                PbProgreso.Value = e.Percent;
                PbProgreso.Update();
            });

            LblPorcentaje.Invoke((MethodInvoker)delegate
            {
                LblPorcentaje.Text = $"{e.Percent} %";
            });
        }

        private void Restore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                LblEstado.Invoke((MethodInvoker)delegate
                {
                    LblEstado.Text = e.Error.Message;
                });
            }
        }
    }
}
