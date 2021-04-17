using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            FrmInicioSesion inicioSesion = new FrmInicioSesion();
            inicioSesion.ShowDialog();

            if (inicioSesion.DialogResult == DialogResult.OK)
            {
                Application.Run(new FrmPrincipal(inicioSesion.Usuario));
            }
            else if (inicioSesion.DialogResult == DialogResult.Retry)
            {
                inicioSesion.ShowDialog();
            }
            else
            {
                inicioSesion.Close();
            }         
        }
    }
}
