using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Models
{
    public class CuotaReport
    {
        public int CuotaId { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Monto { get; set; }
        public int Numero { get; set; }
        public DateTime FechaPago { get; set; }
        public int TipoCuotaId { get; set; }
        public int EstadoCuotaId { get; set; }
        public int CreditoId { get; set; }
    }
}
