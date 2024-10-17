using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Exception
{
    public class InvalidPetAgeException : ApplicationException
    {
        public InvalidPetAgeException(string message) : base(message) { }
    }
}
