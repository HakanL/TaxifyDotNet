using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal abstract class BaseRequest
    {
        [JsonProperty(Order = -2)]
        public Models.Security Security { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Models.TaxRequestOption[] Options { get; set; }
    }
}
