using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class CategoriaAsociado
    {
        public CategoriaAsociado()
        {
            Socios = new HashSet<Socio>();
        }

        public int CategoriaAsociadoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Socio> Socios { get; set; }
    }
}
