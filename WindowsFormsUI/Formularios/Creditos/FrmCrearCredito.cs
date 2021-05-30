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

        private void CalcularDeducciones()
        {

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

        private void CalcularPrestamoAnterior(ICollection<Credito> creditos)
        {
            foreach (Credito credito in creditos)
            {
                if (credito.EstadoCreditoId == 2) // Solo el credito que esta activo
                {
                    foreach (Cuota cuota in credito.Cuotas)
                    {
                        if (cuota.EstadoCuotaId == 1) // Solo la cuota que no ha sido cancelada
                        {
                            NudPrestamoAnterior.Value += cuota.Monto;
                        }
                    }
                }
            }
        }

        private void NudMonto_ValueChanged(object sender, EventArgs e)
        {
            decimal monto = NudMonto.Value;
            int plazo = Convert.ToInt32(NudPlazo.Value);

            CalcularInteres(monto);
            CalcularTramite(monto);

            decimal interes = NudInteres.Value;

            CalcularCuota(monto, plazo, interes);
        }

        private void CalcularCuota(decimal monto, int plazo, decimal interes)
        {

        }

        private void CalcularTramite(decimal monto)
        {
            if (monto >= 1 && monto <= 100)
            {
                NudTramite.Value = 2.00M;
            }
            else if (monto > 100 && monto <= 200)
            {
                NudTramite.Value = 3.00M;
            }
            else if (monto > 200)
            {
                NudTramite.Value = monto * 0.015M;
            }
        }

        private void CalcularInteres(decimal monto)
        {
            if (monto >= 1 && monto <= 300)
            {
                NudInteres.Value = 5;
            }
            else if (monto > 300 && monto <= 450)
            {
                NudInteres.Value = 3.33M;
            }
            else if (monto > 450)
            {
                NudInteres.Value = 1.67M;
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

                        if (NudInteres.Value <= 0)
                        {
                            EpControles.SetError(NudInteres, "Por favor, ingrese un valor mayor a cero para continuar!");
                        }
                        else
                        {
                            EpControles.Clear();

                            if (NudTramite.Value <= 0)
                            {
                                EpControles.SetError(NudTramite, "Por favor, ingrese un valor mayor a cero para continuar!");
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
                    Interes = NudInteres.Value,
                    Tramite = NudTramite.Value,
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
    }
}
