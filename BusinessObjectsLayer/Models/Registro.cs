using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Registro
    {
        public Registro()
        {
            RegistroUsuarios = new HashSet<RegistroUsuario>();
        }

        public int RegistroId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RegistroUsuario> RegistroUsuarios { get; set; }
    }
}
