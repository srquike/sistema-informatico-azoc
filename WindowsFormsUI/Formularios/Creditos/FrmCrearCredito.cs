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
        private readonly CuotaBLL _cuotaBLL;
        private readonly DeducccionCreditoBLL _deducccionCreditoBLL;

        public FrmCrearCredito()
        {
            InitializeComponent();

            _asociadoLogic = new AsociadoBLL();
            _creditoLogic = new CreditoBLL();
            _cuotaBLL = new CuotaBLL();
            _deducccionCreditoBLL = new DeducccionCreditoBLL();
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

                if (NudMontoSolicitado.Value <= 0)
                {
                    EpControles.SetError(NudMontoSolicitado, "Por favor, ingrese un valor mayor a cero para continuar!");
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
                int creditoId = Convert.ToInt32(TxtCodigoCredito.Text);
                int plazo = Convert.ToInt32(NudPlazo.Value);
                decimal cuota = Convert.ToDecimal(TxtMontoCuota.Text.Replace("$", ""));

                Credito credito = new Credito()
                {
                    CreditoId = creditoId,
                    FechaInicio = DtpFechaInicio.Value.Date,
                    Monto = NudMontoSolicitado.Value,
                    Interes = NudPorcentajeInteres.Value,
                    Tramite = NudPorcentajeTramite.Value,
                    AsociadoId = asociadoId,
                    Plazo = plazo,
                    EstadoCreditoId = ChkAprobarCredito.Checked ? 2 : 1
                };

                if (credito.EstadoCreditoId == 2)
                {
                    credito.FechaAprobacion = DateTime.Today;
                }

                if (_creditoLogic.Create(credito))
                {
                    var cuotas = CrearCuotas(credito.CreditoId, cuota, plazo);

                    if (cuotas != null && cuotas.Count > 0)
                    {
                        CrearDeducciones(credito.CreditoId);

                        DialogResult = DialogResult.OK;
                    }                    
                }
            }
        }

        private void CrearDeducciones(int creditoId)
        {
            DeduccionCredito deduccion;
            IList<DeduccionCredito> deducciones = new List<DeduccionCredito>();

            if (NudAhorroSimultaneo.Value > 0)
            {
                deduccion = new DeduccionCredito()
                {
                    CreditoId = creditoId,
                    DeduccionId = 1,
                    Monto = NudAhorroSimultaneo.Value
                };

                deducciones.Add(deduccion);
            }
            if (NudDocumentoAutenticado.Value > 0)
            {
                deduccion = new DeduccionCredito()
                {
                    CreditoId = creditoId,
                    DeduccionId = 2,
                    Monto = NudDocumentoAutenticado.Value
                };

                deducciones.Add(deduccion);
            }
            if (NudHipotecaAbierta.Value > 0)
            {
                deduccion = new DeduccionCredito()
                {
                    CreditoId = creditoId,
                    DeduccionId = 3,
                    Monto = NudHipotecaAbierta.Value
                };

                deducciones.Add(deduccion);
            }
            if (NudPrestamoAnterior.Value > 0)
            {
                deduccion = new DeduccionCredito()
                {
                    CreditoId = creditoId,
                    DeduccionId = 4,
                    Monto = NudPrestamoAnterior.Value
                };

                deducciones.Add(deduccion);
            }
            if (NudTramites.Value > 0)
            {
                deduccion = new DeduccionCredito()
                {
                    CreditoId = creditoId,
                    DeduccionId = 5,
                    Monto = NudTramites.Value
                };

                deducciones.Add(deduccion);
            }
            if (NudInteresSobrePrestamo.Value > 0)
            {
                deduccion = new DeduccionCredito()
                {
                    CreditoId = creditoId,
                    DeduccionId = 6,
                    Monto = NudInteresSobrePrestamo.Value
                };

                deducciones.Add(deduccion);
            }
            if (NudAportaciones.Value > 0)
            {
                deduccion = new DeduccionCredito()
                {
                    CreditoId = creditoId,
                    DeduccionId = 7,
                    Monto = NudAportaciones.Value
                };

                deducciones.Add(deduccion);
            }
            if (NudOtros.Value > 0)
            {
                deduccion = new DeduccionCredito()
                {
                    CreditoId = creditoId,
                    DeduccionId = 8,
                    Monto = NudOtros.Value
                };

                deducciones.Add(deduccion);
            }

            foreach (DeduccionCredito deduccionCredito in deducciones)
            {
                if (_deducccionCreditoBLL.Create(deduccionCredito) == false)
                {
                    MessageBox.Show("No se pudo crear la deducción", "Crear deducción: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private ICollection<Cuota> CrearCuotas(int creditoId, decimal monto, int plazo)
        {
            Cuota cuota, cuotaAnterior;
            ICollection<Cuota> cuotas;

            cuotas = new List<Cuota>();
            cuotaAnterior = new Cuota();

            for (int i = 1; i <= plazo; i++)
            {
                cuota = new Cuota()
                {
                    Monto = monto,
                    Numero = i,
                    EstadoCuotaId = 1,
                    TipoCuotaId = 1,
                    CreditoId = creditoId,
                };

                if (i == 1)
                {
                    cuota.FechaVencimiento = DateTime.Today;
                }
                else
                {
                    cuota.FechaVencimiento = cuotaAnterior.FechaVencimiento.AddDays(15);
                }

                cuotaAnterior = cuota;
                cuotas.Add(cuota);
            }

            if (_cuotaBLL.CreateMany(cuotas))
            {
                return cuotas;
            }

            return null;
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            if (NudMontoSolicitado.Value > 0 && NudPlazo.Value > 0)
            {
                decimal monto = NudMontoSolicitado.Value;
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
            NudMontoSolicitado.Value = 0;
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