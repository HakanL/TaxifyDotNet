using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Converters;

namespace Haukcode.TaxifyDotNet
{
    internal class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
