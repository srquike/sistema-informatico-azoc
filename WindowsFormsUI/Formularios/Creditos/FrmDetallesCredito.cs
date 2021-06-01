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
    public partial class FrmDetallesCredito : Form
    {
        private readonly CreditoBLL _creditoBLL;
        private Credito _credito;

        public FrmDetallesCredito(int creditoId)
        {
            InitializeComponent();

            _creditoBLL = new CreditoBLL();
            _credito = _creditoBLL.Find(creditoId);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LlenarCampos()
        {
            string nombreAsociado = string.Concat(_credito.Asociado.PrimerNombre, " ", _credito.Asociado.SegundoNombre, " ", _credito.Asociado.TercerNombre, " ", _credito.Asociado.PrimerApellido, " ", _credito.Asociado.SegundoApellido, " ", _credito.Asociado.TercerApellido);
            int canceladas = 0;
            int pendientes = 0;
            int cuotas = 0;
            decimal deducciones = 0;
            decimal capital = 0;
            decimal interes = 0;
            decimal deuda = 0;


            TxtNombreAsociado.Text = nombreAsociado;
            TxtCodigoAsociado.Text = _credito.AsociadoId.ToString();
            TxtCodigoCredito.Text = _credito.CreditoId.ToString();
            TxtMontoCuota.Text = _credito.Monto.ToString();
            TxtFechaInicio.Text = _credito.FechaInicio.ToShortDateString();
            TxtFechaAprobacion.Text = _credito.FechaAprobacion.ToShortDateString();
            TxtPInteres.Text = _credito.Interes.ToString() + " %";
            TxtPTramite.Text = _credito.Tramite.ToString() + " %";

            foreach (Cuota cuota in _credito.Cuotas)
            {
                cuotas++;

                if (cuota.EstadoCuotaId == 1) // Cuota pendiente
                {
                    pendientes++;
                }
                else if (cuota.EstadoCuotaId == 2) // Cuota cancelada
                {
                    canceladas++;
                }
            }

            TxtCantidadCuotas.Text = cuotas.ToString();
            TxtPendientes.Text = pendientes.ToString();
            TxtCanceladas.Text = canceladas.ToString();

            capital = _credito.Monto / cuotas;
            interes = (_credito.Monto * (_credito.Interes / 100)) / 2;

            TxtCapital.Text = capital.ToString();
            TxtInteres.Text = interes.ToString();
            TxtMontoCuota.Text = (capital + interes).ToString();

            foreach (DeduccionCredito deduccion in _credito.DeduccionesCreditos)
            {
                deducciones += deduccion.Monto;
            }

            TxtLiquidoRecibido.Text = (_credito.Monto - deducciones).ToString();
            TxtSaldo.Text = (capital * canceladas).ToString();
            TxtInteresAcumulado.Text = (interes * canceladas).ToString();
            TxtDeudaAdquirida.Text = (((_credito.Tramite / 100) * _credito.Monto) + _credito.Monto).ToString();

            foreach (Credito credito in _credito.Asociado.Creditos)
            {
                if (credito.EstadoCreditoId == 2)
                {
                    deuda += (credito.Monto * (credito.Tramite / 100)) + credito.Monto;
                }
            }

            TxtDeudaTotal.Text = deuda.ToString();
        }

        private void FrmDetallesCredito_Load(object sender, EventArgs e)
        {
            if (_credito != null)
            {
                LlenarCampos();
            }
        }
    }
}
