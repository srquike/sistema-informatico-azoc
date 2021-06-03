using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Aportacion
    {
        public int AportacionId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Fuente { get; set; }
        public int AsociadoId { get; set; }

        public virtual Socio Asociado { get; set; }
    }
}
