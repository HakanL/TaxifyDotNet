using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Messages
{
    internal class ResponseRoot<T> where T : Messages.BaseResponse
    {
        public T d { get; set; }
    }
}
