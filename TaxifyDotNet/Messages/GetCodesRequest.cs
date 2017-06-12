using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class GetCodesRequest : BaseRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CodeTypes CodeType { get; set; }
    }
}
