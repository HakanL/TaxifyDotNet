using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Haukcode.TaxifyDotNet.Messages
{
    public class CalculateTaxResponse : BaseResponse
    {
        public string DocumentKey { get; set; }

        public float SalesTaxAmount { get; set; }

        public string TaxJurisdictionSummary { get; set; }

        public Models.VerifyAddress DestinationAddress { get; set; }

        public Models.VerifyAddress OriginAddress { get; set; }

        public Models.TaxJurisdictionDetail[] TaxJurisdictionDetails { get; set; }

        public Models.TaxLineDetailResponse[] TaxLineDetails { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime EffectiveTaxDate { get; set; }

        public string CustomerTaxabilityCode { get; set; }

        public bool IsCommitted { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EffectiveTaxAddressTypes EffectiveTaxAddressType { get; set; }

        public Models.VerifyAddress EffectiveTaxAddress { get; set; }

        public string TaxFilingLocationCode { get; set; }
    }
}
