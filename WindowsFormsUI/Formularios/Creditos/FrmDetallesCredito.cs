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
            DialogResult = DialogResult.OK;
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
            TxtMontoSolicitado.Text = string.Format("{0:C2}", _credito.Monto);
            TxtFechaInicio.Text = _credito.FechaInicio.ToShortDateString();
            TxtFechaAprobacion.Text = _credito.FechaAprobacion.ToShortDateString();
            TxtPInteres.Text = string.Format("{0:N2}", _credito.Interes);
            TxtPTramite.Text = string.Format("{0:C2}", _credito.Tramite);
            TxtPlazo.Text = _credito.Plazo.ToString();

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

            TxtCapital.Text = string.Format("{0:C2}", capital);
            TxtInteres.Text = string.Format("{0:C2}", interes);
            TxtMontoCuota.Text = string.Format("{0:C2}", (capital + interes));

            deducciones = ObtenerDeducciones();

            decimal deudaAdquirida = _credito.Monto + _credito.Tramite;

            TxtLiquidoRecibido.Text = string.Format("{0:C2}", (_credito.Monto - deducciones));
            TxtInteresAcumulado.Text = string.Format("{0:C2}", (interes * canceladas));
            TxtDeudaAdquirida.Text = string.Format("{0:C2}", deudaAdquirida);
            TxtSaldo.Text = string.Format("{0:C2}", (capital * pendientes));

            foreach (Credito credito in _credito.Asociado.Creditos)
            {
                if (credito.EstadoCreditoId == 2)
                {
                    deuda += (credito.Monto * (credito.Tramite / 100)) + credito.Monto;
                }
            }

            TxtDeudaTotal.Text = string.Format("{0:C2}", (deuda + deudaAdquirida));
        }

        private decimal ObtenerDeducciones()
        {
            decimal deducciones = 0;

            foreach (DeduccionCredito deduccionCredito in _credito.DeduccionesCreditos)
            {
                switch (deduccionCredito.DeduccionId)
                {
                    case 1:
                        TxtAhorroSimultaneo.Text = string.Format("{0:C2}", deduccionCredito.Monto);
                        break;
                    case 2:
                        TxtDocumentoAutenticado.Text = string.Format("{0:C2}", deduccionCredito.Monto);
                        break;
                    case 3:
                        TxtHipotecaAbierta.Text = string.Format("{0:C2}", deduccionCredito.Monto);
                        break;
                    case 4:
                        TxtPagoPrestamoAnterior.Text = string.Format("{0:C2}", deduccionCredito.Monto);
                        break;
                    case 5:
                        TxtTramites.Text = string.Format("{0:C2}", deduccionCredito.Monto);
                        break;
                    case 6:
                        TxtInteresSobrePrestamo.Text = string.Format("{0:C2}", deduccionCredito.Monto);
                        break;
                    case 7:
                        TxtAportaciones.Text = string.Format("{0:C2}", deduccionCredito.Monto);
                        break;
                    case 8:
                        TxtOtros.Text = string.Format("{0:C2}", deduccionCredito.Monto);
                        break;
                    default:
                        break;
                }

                deducciones += deduccionCredito.Monto;
            }

            TxtTotalDeducciones.Text = string.Format("{0:C2}", deducciones);

            return deducciones;
        }

        private void FrmDetallesCredito_Load(object sender, EventArgs e)
        {
            if (_credito != null)
            {
                LlenarCampos();
            }
        }

        private void LlblDetallesAsociado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int asociadoId = Convert.ToInt32(TxtCodigoAsociado.Text);
            FrmDetallesAsociado frmDetallesAsociado = new FrmDetallesAsociado(asociadoId);
            frmDetallesAsociado.StartPosition = FormStartPosition.CenterScreen;
            frmDetallesAsociado.ShowDialog();
        }
    }
}