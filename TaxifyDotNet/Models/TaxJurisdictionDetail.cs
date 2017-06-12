using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Models
{
    public class TaxJurisdictionDetail
    {
        public string AppliedTo { get; set; }

        public string JurisdictionType { get; set; }

        public string JurisdictionName { get; set; }

        public decimal JurisdictionTaxRate { get; set; }

        public decimal JurisdictionTaxAmount { get; set; }

        public bool IsPaidToState { get; set; }

        public object ExtendedProperties { get; set; }
    }
}
