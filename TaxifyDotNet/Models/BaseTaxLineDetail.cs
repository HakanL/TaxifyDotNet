using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Haukcode.TaxifyDotNet.Models
{
    public abstract class BaseTaxLineDetail
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LineNumber { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ItemKey { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ItemTaxabilityCode { get; set; }

        public decimal Amount { get; set; }
    }
}
