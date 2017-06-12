using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Haukcode.TaxifyDotNet.Models
{
    public class TaxLineDetail : BaseTaxLineDetail
    {
        public decimal ActualExtendedPrice
        {
            get
            {
                return Quantity * Amount;
            }

            set
            {
                Quantity = 1;
                Amount = value;
            }
        }

        public decimal Quantity { get; set; } = 1;

        public string ItemDescription { get; set; }

        public bool TaxIncludedInPrice { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ItemCategories { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ItemTags { get; set; }
    }
}
