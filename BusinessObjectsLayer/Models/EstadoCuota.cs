using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class EstadoCuota
    {
        public EstadoCuota()
        {
            Cuota = new HashSet<Cuota>();
        }

        public int EstadoCuotaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cuota> Cuota { get; set; }
    }
}
