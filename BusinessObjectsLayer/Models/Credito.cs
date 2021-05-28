using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Credito
    {
        public Credito()
        {
            Cuotas = new HashSet<Cuota>();
            DeduccionesCreditos = new HashSet<DeduccionCredito>();
        }

        public int CreditoId { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal Monto { get; set; }
        public int TasaInteres { get; set; }
        public int EstadoCreditoId { get; set; }
        public int AsociadoId { get; set; }

        public virtual Asociado Asociado { get; set; }
        public virtual EstadoCredito EstadosCreditos { get; set; }
        public virtual ICollection<Cuota> Cuotas { get; set; }
        public virtual ICollection<DeduccionCredito> DeduccionesCreditos { get; set; }
    }
}
