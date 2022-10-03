using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBank.Exceptions
{
    public class InValidUsernameException : Exception
    {
        public InValidUsernameException(string message = "Username cannot be null and cannot be duplicated in the database") : base(message)
        {
        }
    }
}
