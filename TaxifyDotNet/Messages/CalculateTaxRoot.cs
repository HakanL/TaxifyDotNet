using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class CalculateTaxRoot
    {
        [JsonProperty("CalculateTax")]
        public CalculateTaxRequest Request { get; set; }
    }
}
