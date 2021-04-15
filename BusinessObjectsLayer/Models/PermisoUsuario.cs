using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class PermisoUsuario
    {
        public int PermisoUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int PermisoId { get; set; }

        public virtual Permiso Permiso { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
