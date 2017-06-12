using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class VerifyAddressRoot
    {
        [JsonProperty("VerifyAddress")]
        public VerifyAddressRequest Request { get; set; }
    }
}
