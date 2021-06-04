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
using AutoMapper;
using Reports.Formularios;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCrearCredito : Form
    {
        private readonly SocioBLL _asociadoLogic;
        private readonly CreditoBLL _creditoLogic;
        private readonly CuotaBLL _cuotaBLL;
        private readonly DeducccionCreditoBLL _deducccionCreditoBLL;

        public FrmCrearCredito()
        {
            InitializeComponent();

            _asociadoLogic = new SocioBLL();
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
                                        Nombre = string.Concat(asociado.Pnombre, " ", asociado.Snombre, " ", asociado.Tnombre, " ", asociado.Papellido, " ", asociado.Sapellido, " ", asociado.Tapellido),
                                        Id = asociado.SocioId
                                    }).ToList();

            comboBox.DataSource = asociadosNombres;
            comboBox.DisplayMember = "Nombre";
            comboBox.ValueMember = "Id";
        }

        private void FrmCrearCredito_Load(object sender, EventArgs e)
        {
            ActualizarAsociados(ref CmbAsociados);
        }

        private decimal ObtenerDeducciones()
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

        private decimal ObtenerCuota(decimal montoSolicitado, int plazo, decimal tasaInteres)
        {
            decimal capital = montoSolicitado / plazo;
            decimal interes = (montoSolicitado * (tasaInteres / 100)) / 2;
            decimal cuota = capital + interes;

            return cuota;
        }

        private decimal ObtenerMontoTramite(decimal monto)
        {
            decimal montoTramite = 0;

            if (monto >= 1 && monto <= 100)
            {
                montoTramite = 2.00M;
            }
            else if (monto > 100 && monto <= 200)
            {
                montoTramite = 3.00M;
            }
            else if (monto > 200)
            {
                montoTramite = monto * 0.015M;
            }

            return montoTramite;
        }

        private decimal ObtenerTasaInteres(decimal monto)
        {
            decimal tasaInteres = 0;

            if (monto >= 1 && monto <= 300)
            {
                tasaInteres = 5;
            }
            else if (monto > 300 && monto <= 450)
            {
                tasaInteres = 3.33M;
            }
            else if (monto > 450)
            {
                tasaInteres = 1.67M;
            }

            return tasaInteres;
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

                        if (NudTasaInteres.Value <= 0)
                        {
                            EpControles.SetError(NudTasaInteres, "Por favor, ingrese un valor mayor a cero para continuar!");
                        }
                        else
                        {
                            EpControles.Clear();

                            if (NudMontoTramite.Value <= 0)
                            {
                                EpControles.SetError(NudMontoTramite, "Por favor, ingrese un valor mayor a cero para continuar!");
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
                int codigoCredito = Convert.ToInt32(TxtCodigoCredito.Text);
                int plazo = Convert.ToInt32(NudPlazo.Value);
                decimal cuota = NudMontoCuota.Value;

                Credito credito = new Credito()
                {
                    Codigo = codigoCredito,
                    Inicio = DtpFechaInicio.Value.Date,
                    Monto = NudMontoSolicitado.Value,
                    SocioId = asociadoId,
                    Plazo = plazo,
                    TasaInteres = NudTasaInteres.Value,
                    EstadoCreditoId = ChkAprobarCredito.Checked ? 2 : 1
                };

                if (credito.EstadoCreditoId == 2)
                {
                    credito.Aprobacion = DateTime.Today;
                }

                if (_creditoLogic.Create(credito))
                {
                    if (CrearCuotas(credito.CreditoId, cuota, plazo))
                    {
                        if (CrearDeducciones(credito.CreditoId))
                        {
                            FrmAgendaPagos frmAgendaPagos = new FrmAgendaPagos(credito.CreditoId);
                            frmAgendaPagos.StartPosition = FormStartPosition.CenterScreen;
                            frmAgendaPagos.ShowDialog();

                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("No fue posible crear las deducciones, por favor intente de nuevo!", "Crear deducciones: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No fue posible crear las cuotas, por favor intente de nuevo!", "Crear cuotas: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No fue posible crear el crédito, por favor intente de nuevo!", "Crear crédito: error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CrearDeducciones(int creditoId)
        {
            DeduccionCredito deduccion;
            ICollection<DeduccionCredito> deducciones = new List<DeduccionCredito>();

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

            if (_deducccionCreditoBLL.CreateMany(deducciones))
            {
                return true;
            }

            return false;
        }

        private bool CrearCuotas(int creditoId, decimal monto, int plazo)
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
                return true;
            }

            return false;
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            if (NudMontoSolicitado.Value > 0 && NudPlazo.Value > 0)
            {
                decimal montoSolicitado, tasaInteres, montoTramite, cuota, deducciones, prestamoAnterior;
                int plazo;

                plazo = Convert.ToInt32(NudPlazo.Value);
                montoSolicitado = NudMontoSolicitado.Value;
                tasaInteres = ObtenerTasaInteres(montoSolicitado);
                montoTramite = ObtenerMontoTramite(montoSolicitado);
                cuota = ObtenerCuota(montoSolicitado, plazo, tasaInteres);
                prestamoAnterior = NudPrestamoAnterior.Value;

                NudTramites.Value = montoTramite;

                deducciones = ObtenerDeducciones();

                NudTasaInteres.Value = tasaInteres;
                NudMontoTramite.Value = montoTramite;
                NudMontoCuota.Value = cuota;
                NudCapitalCuota.Value = montoSolicitado / plazo;
                NudInteresCuota.Value = (montoSolicitado * (tasaInteres / 100)) / 2;
                NudTotalDeducciones.Value = deducciones;
                NudLiquidoRecibir.Value = montoSolicitado - deducciones;
                NudDeudaAdquirida.Value = montoSolicitado + montoTramite;
                NudDeudaTotal.Value = montoSolicitado + montoTramite + prestamoAnterior;
            }
            else
            {
                MessageBox.Show("El monto solicitado o el plazo debe ser diferente de cero!");
            }
        }

        private void CmbAsociados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int asociadoId = Convert.ToInt32(CmbAsociados.SelectedValue);
            Socio asociado = _asociadoLogic.Find(asociadoId);

            if (asociado != null)
            {
                TxtCodigoAsociado.Text = asociado.Codigo;

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
            NudTasaInteres.Value = 0;
            NudDocumentoAutenticado.Value = 0;
            NudMontoTramite.Value = 0;
            NudAhorroSimultaneo.Value = 0;
            NudHipotecaAbierta.Value = 0;
            NudTramites.Value = 0;
            NudInteresSobrePrestamo.Value = 0;
            NudAportaciones.Value = 0;
            NudOtros.Value = 0;
            NudTotalDeducciones.Value = 0;
            NudMontoCuota.Value = 0;
            NudCapitalCuota.Value = 0;
            NudInteresCuota.Value = 0;
            NudLiquidoRecibir.Value = 0;
            NudDeudaAdquirida.Value = 0;
            NudDeudaTotal.Value = 0;
            TxtCodigoCredito.Focus();
        }

        private void LlblVerDetallesAsociado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int asociadoId = Convert.ToInt32(CmbAsociados.SelectedValue);

            FrmDetallesAsociado frmDetallesAsociado = new FrmDetallesAsociado(asociadoId);
            frmDetallesAsociado.StartPosition = FormStartPosition.CenterScreen;
            frmDetallesAsociado.ShowDialog();

            if (frmDetallesAsociado.DialogResult == DialogResult.OK)
            {
                frmDetallesAsociado.Close();
            }
        }
    }
}