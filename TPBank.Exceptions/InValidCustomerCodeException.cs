using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBank.Exceptions
{
    public class InValidCustomerCodeException : Exception
    {
        public InValidCustomerCodeException(string message = "Customer code must be greater than 0") : base(message)
        {
        }
    }
}
