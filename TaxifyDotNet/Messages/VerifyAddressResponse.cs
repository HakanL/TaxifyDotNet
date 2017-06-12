using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class VerifyAddressResponse : BaseResponse
    {
        public Models.VerifyAddress Address { get; set; }
    }
}
