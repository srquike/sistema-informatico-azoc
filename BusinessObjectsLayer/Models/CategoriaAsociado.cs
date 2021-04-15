using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class CategoriaAsociado
    {
        public CategoriaAsociado()
        {
            Asociados = new HashSet<Asociado>();
        }

        public int CategoriaAsociadoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Asociado> Asociados { get; set; }
    }
}
