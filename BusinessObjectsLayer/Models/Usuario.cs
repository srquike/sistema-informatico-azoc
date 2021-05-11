using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string Respuesta1 { get; set; }
        public string Respuesta2 { get; set; }
        public string Respuesta3 { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int EmpleadoId { get; set; }
        public char Estado { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<PermisoUsuario> PermisoUsuarios { get; set; }
        public virtual ICollection<RegistroUsuario> RegistroUsuarios { get; set; }
    }
}
