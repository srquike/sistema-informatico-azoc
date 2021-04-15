using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class TipoCuota
    {
        public TipoCuota()
        {
            Cuota = new HashSet<Cuota>();
        }

        public int TipoCuotaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cuota> Cuota { get; set; }
    }
}
