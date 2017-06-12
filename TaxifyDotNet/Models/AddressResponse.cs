using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Models
{
    public class AddressResponse : Address
    {
        public string County { get; set; }

        public object ExtendedProperties { get; set; }
    }
}
