using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class CommitTaxRoot
    {
        [JsonProperty("CommitTax")]
        public CommitTaxRequest Request { get; set; }
    }
}
