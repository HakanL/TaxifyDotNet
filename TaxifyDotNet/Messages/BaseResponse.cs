using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Messages
{
    public abstract class BaseResponse
    {
        public string __type { get; set; }

        public object ExtendedProperties { get; set; }

        public Models.Error[] Errors { get; set; }

        public int ResponseStatus { get; set; }
    }
}
