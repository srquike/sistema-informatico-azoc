using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class RegistroUsuario
    {
        public int RegistroUsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public int RegistroId { get; set; }
        public string Informacion { get; set; }

        public virtual Registro Registro { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
