using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class CalculateTaxRequest : BaseRequest
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DocumentKey { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? TaxDate { get; set; }

        public Models.TaxLineDetail[] Lines { get; set; }

        public Models.Address DestinationAddress { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Models.Address OriginAddress { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CustomerTaxabilityCode { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CustomerRegistrationNumber { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] Tags { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Models.Discount[] Discounts { get; set; }

        public bool IsCommitted { get; set; }

        public decimal? OverrideTaxCollectedAmount { get; set; }
    }
}
