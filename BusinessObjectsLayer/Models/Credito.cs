using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Credito
    {
        public Credito()
        {
            Cuota = new HashSet<Cuota>();
            DeduccionCreditos = new HashSet<DeduccionCredito>();
        }

        public int CreditoId { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal Monto { get; set; }
        public int TasaInteres { get; set; }
        public int CantidadCuotas { get; set; }
        public int EstadoCreditoId { get; set; }
        public int AsociadoId { get; set; }

        public virtual Asociado Asociado { get; set; }
        public virtual EstadoCredito EstadoCredito { get; set; }
        public virtual ICollection<Cuota> Cuota { get; set; }
        public virtual ICollection<DeduccionCredito> DeduccionCreditos { get; set; }
    }
}
