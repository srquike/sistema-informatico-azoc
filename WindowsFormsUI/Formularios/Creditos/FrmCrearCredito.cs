using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System.Linq;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCrearCredito : Form
    {
        private readonly AsociadoBLL _asociadoLogic;
        private readonly CreditoBLL _creditoLogic;
        private readonly DeduccionBLL _deduccionLogic;

        public FrmCrearCredito()
        {
            InitializeComponent();

            _asociadoLogic = new AsociadoBLL();
            _creditoLogic = new CreditoBLL();
            _deduccionLogic = new DeduccionBLL();
        }

        private void ActualizarAsociados(ref ComboBox comboBox)
        {
            var asociados = _asociadoLogic.List();
            var asociadosNombres = (from asociado in asociados
                                    select new
                                    {
                                        Nombre = string.Concat(asociado.PrimerNombre, " ", asociado.SegundoNombre, " ", asociado.TercerNombre, " ", asociado.PrimerApellido, " ", asociado.SegundoApellido, " ", asociado.TercerApellido),
                                        Id = asociado.AsociadoId
                                    }).ToList();

            comboBox.DataSource = asociadosNombres;
            comboBox.DisplayMember = "Nombre";
            comboBox.ValueMember = "Id";
        }

        private void FrmCrearCredito_Load(object sender, EventArgs e)
        {
            ActualizarAsociados(ref CmbAsociados);
        }

        private decimal CalcularDeducciones()
        {
            decimal deducciones = 0;
            decimal ahorroSimultaneo = NudAhorroSimultaneo.Value;
            decimal documentoAutenticado = NudDocumentoAutenticado.Value;
            decimal hipotecaAbierta = NudHipotecaAbierta.Value;
            decimal prestamoAnterior = NudPrestamoAnterior.Value;
            decimal tramites = NudTramites.Value;
            decimal interesSobrePrestamo = NudInteresSobrePrestamo.Value;
            decimal aportaciones = NudAportaciones.Value;
            decimal otros = NudOtros.Value;

            deducciones = ahorroSimultaneo + documentoAutenticado + hipotecaAbierta + prestamoAnterior + tramites + interesSobrePrestamo + aportaciones + otros;

            return deducciones;
        }

        private void CalcularPrestamoAnterior(ICollection<Credito> creditos)
        {
            decimal prestamoAnterior = 0;

            foreach (Credito credito in creditos)
            {
                if (credito.EstadoCreditoId == 2) // Solo el credito que esta activo
                {
                    foreach (Cuota cuota in credito.Cuotas)
                    {
                        if (cuota.EstadoCuotaId == 1) // Solo la cuota que no ha sido cancelada
                        {
                            prestamoAnterior += cuota.Monto;
                        }
                    }
                }
            }

            NudPrestamoAnterior.Value = prestamoAnterior;
        }

        private void CalcularCuota(decimal montoSolicitado, int plazo, decimal Porcentajeinteres)
        {
            decimal capital = montoSolicitado / plazo;
            decimal interes = (montoSolicitado * (Porcentajeinteres / 100)) / 2;
            decimal monto = capital + interes;

            TxtMontoCuota.Text = string.Format("{0:C2}", monto);
            TxtInteres.Text = string.Format("{0:C2}", interes);
            TxtCapital.Text = string.Format("{0:C2}", capital);
        }

        private void CalcularPorcentajeTramite(decimal monto)
        {
            if (monto >= 1 && monto <= 100)
            {
                NudPorcentajeTramite.Value = 2.00M;
            }
            else if (monto > 100 && monto <= 200)
            {
                NudPorcentajeTramite.Value = 3.00M;
            }
            else if (monto > 200)
            {
                NudPorcentajeTramite.Value = monto * 0.015M;
            }
        }

        private void CalcularPorcentajeInteres(decimal monto)
        {
            if (monto >= 1 && monto <= 300)
            {
                NudPorcentajeInteres.Value = 5;
            }
            else if (monto > 300 && monto <= 450)
            {
                NudPorcentajeInteres.Value = 3.33M;
            }
            else if (monto > 450)
            {
                NudPorcentajeInteres.Value = 1.67M;
            }
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrEmpty(TxtCodigoCredito.Text))
            {
                EpControles.SetError(TxtCodigoCredito, "Por favor, ingrese el código del crédito!");
            }
            else
            {
                EpControles.Clear();

                if (NudMonto.Value <= 0)
                {
                    EpControles.SetError(NudMonto, "Por favor, ingrese un valor mayor a cero para continuar!");
                }
                else
                {
                    EpControles.Clear();

                    if (NudPlazo.Value <= 0)
                    {
                        EpControles.SetError(NudPlazo, "Por favor, ingrese un valor mayor a cero para continuar!");
                    }
                    else
                    {
                        EpControles.Clear();

                        if (NudPorcentajeInteres.Value <= 0)
                        {
                            EpControles.SetError(NudPorcentajeInteres, "Por favor, ingrese un valor mayor a cero para continuar!");
                        }
                        else
                        {
                            EpControles.Clear();

                            if (NudPorcentajeTramite.Value <= 0)
                            {
                                EpControles.SetError(NudPorcentajeTramite, "Por favor, ingrese un valor mayor a cero para continuar!");
                            }
                            else
                            {
                                EpControles.Clear();
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarEntradas())
            {
                int asociadoId = Convert.ToInt32(CmbAsociados.SelectedValue);
                int plazo = Convert.ToInt32(NudPlazo.Value);

                Credito credito = new Credito()
                {
                    FechaAprobacion = DateTime.Today,
                    FechaInicio = DtpFechaInicio.Value.Date,
                    Monto = NudMonto.Value,
                    Interes = NudPorcentajeInteres.Value,
                    Tramite = NudPorcentajeTramite.Value,
                    AsociadoId = asociadoId,
                    EstadoCreditoId = 1,
                    Plazo = plazo
                };

                if (_creditoLogic.Create(credito))
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            if (NudMonto.Value > 0 && NudPlazo.Value > 0)
            {
                decimal monto = NudMonto.Value;
                int plazo = Convert.ToInt32(NudPlazo.Value);

                CalcularPorcentajeInteres(monto);
                CalcularPorcentajeTramite(monto);

                decimal porcentajeTramite = NudPorcentajeTramite.Value;
                decimal interes = NudPorcentajeInteres.Value;

                CalcularCuota(monto, plazo, interes);

                //NudInteresSobrePrestamo.Value = monto * (interes / 100);
                NudTramites.Value = porcentajeTramite;
                NudTotalDeducciones.Value = CalcularDeducciones();

                TxtLiquidoRecibido.Text = string.Format("{0:C2}", (monto - NudTotalDeducciones.Value));
                TxtDeudaAdquirida.Text = string.Format("{0:C2}", (monto + porcentajeTramite));
                TxtDeudaTotal.Text = string.Format("{0:C2}", (monto + porcentajeTramite + NudPrestamoAnterior.Value));
            }
            else
            {
                MessageBox.Show("El monto solicitado o el plazo debe ser diferente de cero!");
            }            
        }

        private void CmbAsociados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int asociadoId = Convert.ToInt32(CmbAsociados.SelectedValue);
            Asociado asociado = _asociadoLogic.Find(asociadoId);

            if (asociado != null)
            {
                TxtCodigoAsociado.Text = asociado.AsociadoId.ToString();
                MTxtDui.Text = asociado.Dui;

                CalcularPrestamoAnterior(asociado.Creditos);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnLimpiarControles_Click(object sender, EventArgs e)
        {
            TxtCodigoCredito.Clear();
            NudMonto.Value = 0;
            NudPlazo.Value = 0;
            NudPorcentajeInteres.Value = 0;
            NudDocumentoAutenticado.Value = 0;
            NudPorcentajeTramite.Value = 0;
            NudAhorroSimultaneo.Value = 0;
            NudHipotecaAbierta.Value = 0;
            NudTramites.Value = 0;
            NudInteresSobrePrestamo.Value = 0;
            NudAportaciones.Value = 0;
            NudOtros.Value = 0;
            NudTotalDeducciones.Value = 0;
            TxtMontoCuota.Clear();
            TxtCapital.Clear();
            TxtInteres.Clear();
            TxtLiquidoRecibido.Clear();
            TxtDeudaAdquirida.Clear();
            TxtDeudaTotal.Clear();
            TxtCodigoCredito.Focus();
        }
    }
}