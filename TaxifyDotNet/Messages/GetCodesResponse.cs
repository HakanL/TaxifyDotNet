using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class GetCodesResponse : BaseResponse
    {
        public string CodeType { get; set; }

        public string[] Codes { get; set; }
    }
}
