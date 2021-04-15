using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectsLayer.Models
{
    public partial class DeduccionCredito
    {
        public int DeduccionCreditoId { get; set; }
        public int DeduccionId { get; set; }
        public int CreditoId { get; set; }

        public virtual Credito Credito { get; set; }
        public virtual Deduccion Deduccion { get; set; }
    }
}
