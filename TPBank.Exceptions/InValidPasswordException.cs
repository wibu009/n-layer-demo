using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBank.Exceptions
{
    public class InValidPasswordException : Exception
    {
        public InValidPasswordException(string message = "Password cannot be null and must contain 6 or more characters including uppercase, lowercase and number") : base(message)
        {
        }
    }
}
