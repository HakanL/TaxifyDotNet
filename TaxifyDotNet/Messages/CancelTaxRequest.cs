using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class CancelTaxRequest : BaseRequest
    {
        public string DocumentKey { get; set; }
    }
}
