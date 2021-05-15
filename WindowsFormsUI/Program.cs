using System;
using System.Windows.Forms;
using WindowsFormsUI.Formularios;

namespace WindowsFormsUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmInicioSesion frmInicioSesion = new FrmInicioSesion();
            frmInicioSesion.StartPosition = FormStartPosition.CenterScreen;
            frmInicioSesion.ShowDialog();

            if (frmInicioSesion.DialogResult == DialogResult.OK)
            {
                Application.Run(new FrmPrincipal(frmInicioSesion.UsuarioLogIn));
            }
        }
    }
}
