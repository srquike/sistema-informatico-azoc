using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Cuota
    {
        public int CuotaId { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Monto { get; set; }
        public int Numero { get; set; }
        public DateTime FechaPago { get; set; }
        public int TipoCuotaId { get; set; }
        public int EstadoCuotaId { get; set; }
        public int CreditoId { get; set; }

        public virtual Credito Credito { get; set; }
        public virtual EstadoCuota EstadoCuota { get; set; }
        public virtual TipoCuota TipoCuota { get; set; }
    }
}
