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
                    Server server = new Server(new ServerConnection("LAPTOP-2NF0HEH\\SQLEXPRESS", "sa", "_Mi@Sqlserver$Jevc&27!"));
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
                    Server server = new Server(new ServerConnection("LAPTOP-2NF0HEH\\SQLEXPRESS", "sa", "_Mi@Sqlserver$Jevc&27!"));
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidarClaves()
        {
            if (string.IsNullOrEmpty(TxtClave.Text))
            {
                EpClaves.SetError(TxtClave, "Por favor ingrese la clave");
            }
            else
            {
                EpClaves.Clear();

                if (string.IsNullOrEmpty(TxtRepetirClave.Text) || TxtClave.Text != TxtRepetirClave.Text)
                {
                    EpClaves.SetError(TxtRepetirClave, "Por favor la claves debeb ser iguales!");
                }
                else
                {
                    EpClaves.Clear();
                    return true;
                }
            }

            return false;
        }

        private void GuardarArchivoConfiguracion()
        {
            string archivo = "configuracion.bin";

            using (FileStream fileStream = new FileStream(archivo, FileMode.Create, FileAccess.Write))
            {
                BinaryWriter binaryWriter = new BinaryWriter(fileStream);

                string clave = TxtClave.Text;
                string user = "000000000";

                binaryWriter.Write(clave);
                binaryWriter.Write(user);
                binaryWriter.Close();

                MessageBox.Show("Configuración guarda con exito!", "Guardar configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarClaves())
            {
                GuardarArchivoConfiguracion();
            }
        }

        private void ChkVerClaves_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkVerClaves.Checked)
            {
                TxtClave.UseSystemPasswordChar = false;
                TxtRepetirClave.UseSystemPasswordChar = false;
            }
            else
            {
                TxtClave.UseSystemPasswordChar = true;
                TxtRepetirClave.UseSystemPasswordChar = true;
            }
        }
    }
}
