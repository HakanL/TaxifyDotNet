using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haukcode.TaxifyDotNet
{
    public class TaxifyException : Exception
    {
        public int Code { get; private set; }

        public int Type { get; private set; }

        public TaxifyException(string message) : base(message)
        {
        }

        public TaxifyException(Models.Error error)
            : base(error.Message)
        {
            Code = error.Code;
            Type = error.Type;
        }

        public TaxifyException(Models.Error[] errors)
            : this(errors.First())
        {
        }
    }
}
