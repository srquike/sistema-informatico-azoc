using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Permiso
    {
        public Permiso()
        {
            PermisoUsuarios = new HashSet<PermisoUsuario>();
        }

        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PermisoUsuario> PermisoUsuarios { get; set; }
    }
}
