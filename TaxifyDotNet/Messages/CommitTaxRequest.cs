using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class CommitTaxRequest : BaseRequest
    {
        public string DocumentKey { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CommitedDocumentKey { get; set; }
    }
}
