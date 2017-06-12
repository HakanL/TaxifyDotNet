using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Models
{
    public class Discount
    {
        public int Order { get; set; }

        public string Code { get; set; }

        public decimal Amount { get; set; }

        public string DiscountType { get; set; }
    }
}
