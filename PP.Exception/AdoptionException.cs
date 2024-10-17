using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Exception
{
    public class AdoptionException : ApplicationException
    {
        public AdoptionException(string message) : base(message) { }
    }
}

