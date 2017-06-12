using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Haukcode.TaxifyDotNet.Models
{

    public class VerifyAddress : AddressResponse
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public AddressTypes ResidentialOrBusinessType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ValidationStatuses ValidationStatus { get; set; }
    }
}
