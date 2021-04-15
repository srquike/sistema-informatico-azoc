using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Deduccion
    {
        public Deduccion()
        {
            DeduccionCreditos = new HashSet<DeduccionCredito>();
        }

        public int DeduccionId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<DeduccionCredito> DeduccionCreditos { get; set; }
    }
}
