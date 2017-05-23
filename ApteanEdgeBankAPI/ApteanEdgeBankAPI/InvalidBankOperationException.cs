using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
   public class InvalidBankOperationException : InvalidOperationException
    {
       public InvalidBankOperationException() { }

       public InvalidBankOperationException(string message)
           : base(message)
       { }
    }
}
