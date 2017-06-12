using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Models
{
    public class TaxLineDetailResponse : BaseTaxLineDetail
    {
        public decimal ExemptAmount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal SalesTaxAmount { get; set; }

        public object ExtendedProperties { get; set; }
    }
}
