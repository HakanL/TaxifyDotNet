using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet.Models
{
    public class Error
    {
        public int Code { get; set; }

        public object Data { get; set; }

        public string Key { get; set; }

        public string Message { get; set; }

        public int Target { get; set; }

        public int Type { get; set; }

        public bool IsWarning { get; set; }
    }
}
