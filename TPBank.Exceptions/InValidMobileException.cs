using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBank.Exceptions
{
    public class InValidMobileException : Exception
    {
        public InValidMobileException(string message = "The phone number cannot be duplicated in the database and must contain 10 digits") : base(message)
        {
        }
    }
}
