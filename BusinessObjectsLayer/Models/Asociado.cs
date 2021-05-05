using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Asociado
    {
        public Asociado()
        {
            Aportaciones = new HashSet<Aportacion>();
            Beneficiarios = new HashSet<Beneficiario>();
            Creditos = new HashSet<Credito>();
        }

        public int AsociadoId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string TercerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string TercerApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime? Retiro { get; set; }
        public DateTime Ingreso { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Dui { get; set; }
        public string Nit { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int CategoriaAsociadoId { get; set; }

        public virtual CategoriaAsociado CategoriaAsociado { get; set; }
        public virtual ICollection<Aportacion> Aportaciones { get; set; }
        public virtual ICollection<Beneficiario> Beneficiarios { get; set; }
        public virtual ICollection<Credito> Creditos { get; set; }
    }
}
