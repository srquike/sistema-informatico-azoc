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
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmConfiguracion : Form
    {
        private readonly Usuario _usuarioLogeado;
        private readonly RegistroUsuarioBLL _registroUsuarioBLL;

        public FrmConfiguracion(Usuario usuarioLogeado)
        {
            InitializeComponent();

            _registroUsuarioBLL = new RegistroUsuarioBLL();
            _usuarioLogeado = usuarioLogeado;
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

                    RegistroUsuario registro = new RegistroUsuario()
                    {
                        UsuarioId = _usuarioLogeado.UsuarioId,
                        RegistroId = 1006,
                        Fecha = DateTime.Now,
                        Informacion = $"Respaldo de la base de datos por parte del usuario {_usuarioLogeado.Nombre}"
                    };

                    if (_registroUsuarioBLL.Create(registro) == false)
                    {
                        MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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

                    RegistroUsuario registro = new RegistroUsuario()
                    {
                        UsuarioId = _usuarioLogeado.UsuarioId,
                        RegistroId = 1007,
                        Fecha = DateTime.Now,
                        Informacion = $"Restauración de la base de datos por parte del usuario {_usuarioLogeado.Nombre}"
                    };

                    if (_registroUsuarioBLL.Create(registro) == false)
                    {
                        MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            DialogResult = DialogResult.OK;
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
            string directorio = @"Configuracion\";
            string archivo = "configuracion.bin";

            if (!Directory.Exists(directorio))
            {
                try
                {
                    Directory.CreateDirectory(directorio);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "La carpeta para almacenar la configuracion no se pudo crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string ruta = string.Concat(directorio, archivo);

            using (FileStream fileStream = new FileStream(ruta, FileMode.Create, FileAccess.Write))
            {
                BinaryWriter binaryWriter = new BinaryWriter(fileStream);

                string clave = TxtClave.Text;
                string user = "000000000";

                binaryWriter.Write(clave);
                binaryWriter.Write(user);
                binaryWriter.Close();

                RegistroUsuario registro = new RegistroUsuario()
                {
                    UsuarioId = _usuarioLogeado.UsuarioId,
                    RegistroId = 1008,
                    Fecha = DateTime.Now,
                    Informacion = $"Cambio de configuracipon por parte del usuario {_usuarioLogeado.Nombre}"
                };

                if (_registroUsuarioBLL.Create(registro) == false)
                {
                    MessageBox.Show("No se pudo crear el registro de acciones del usuario, pero puede continuar!", "Crear registro: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
