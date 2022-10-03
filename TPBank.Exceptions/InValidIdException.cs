using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBank.Exceptions
{
    public class InValidIdException : Exception
    {
        public InValidIdException(string message = "Id must be no null!") : base(message)
        {
        }
    }
}
