using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            PermisoUsuarios = new HashSet<PermisoUsuario>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<PermisoUsuario> PermisoUsuarios { get; set; }
    }
}
