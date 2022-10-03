using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBank.Exceptions
{
    public class InValidCustomerNameException : Exception
    {
        public InValidCustomerNameException(string message = "Customer name must be greater than 0 and must contain no more than 40 characters") : base(message)
        {
        }
    }
}
