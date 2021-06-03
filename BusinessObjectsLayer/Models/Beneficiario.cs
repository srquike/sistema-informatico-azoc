using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class Beneficiario
    {
        public int BeneficiarioId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string TercerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string TercerApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Dui { get; set; }
        public string Nit { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Porcentaje { get; set; }
        public int AsociadoId { get; set; }

        public virtual Socio Asociado { get; set; }
    }
}
