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
        public int Codigo { get; set; }
        public DateTime? Aprobacion { get; set; }
        public DateTime Inicio { get; set; }
        public decimal Monto { get; set; }
        public int Plazo { get; set; }
        public decimal TasaInteres { get; set; }
        public int? SocioId { get; set; }
        public int? EstadoCreditoId { get; set; }

        public virtual Socio Socio { get; set; }
        public virtual EstadoCredito EstadoCredito { get; set; }
        public virtual ICollection<Cuota> Cuotas { get; set; }
        public virtual ICollection<DeduccionCredito> DeduccionesCreditos { get; set; }
    }
}
