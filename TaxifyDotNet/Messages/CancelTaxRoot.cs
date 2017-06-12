using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class CancelTaxRoot
    {
        [JsonProperty("CancelTax")]
        public CancelTaxRequest Request { get; set; }
    }
}
