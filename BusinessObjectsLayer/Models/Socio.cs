using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Socio
    {
        public Socio()
        {
            Aportaciones = new HashSet<Aportacion>();
            Beneficiarios = new HashSet<Beneficiario>();
            Creditos = new HashSet<Credito>();
        }

        public int SocioId { get; set; }
        public string Codigo { get; set; }
        public string Pnombre { get; set; }
        public string Snombre { get; set; }
        public string Tnombre { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }
        public string Tapellido { get; set; }
        public DateTime? Nacimiento { get; set; }
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
        public int? CategoriaAsociadoId { get; set; }

        public virtual CategoriaAsociado CategoriaAsociado { get; set; }
        public virtual ICollection<Aportacion> Aportaciones { get; set; }
        public virtual ICollection<Beneficiario> Beneficiarios { get; set; }
        public virtual ICollection<Credito> Creditos { get; set; }
    }
}
