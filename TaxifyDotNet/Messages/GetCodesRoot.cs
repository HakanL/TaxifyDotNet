using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class GetCodesRoot
    {
        [JsonProperty("GetCodes")]
        public GetCodesRequest Request { get; set; }
    }
}
