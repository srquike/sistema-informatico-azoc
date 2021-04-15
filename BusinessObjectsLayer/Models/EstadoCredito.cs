using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class EstadoCredito
    {
        public EstadoCredito()
        {
            Creditos = new HashSet<Credito>();
        }

        public int EstadoCreditoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Credito> Creditos { get; set; }
    }
}
