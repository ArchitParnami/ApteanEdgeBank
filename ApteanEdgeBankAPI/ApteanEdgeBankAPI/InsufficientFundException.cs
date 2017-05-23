using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
    public class InsufficientFundException : Exception
    {
        public InsufficientFundException() { }
        public InsufficientFundException(string message) : base(message) { }
    }
}
