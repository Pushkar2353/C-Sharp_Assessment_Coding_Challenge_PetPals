using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string fileName)
        {
            return File.ReadAllText(fileName).Trim();
        }
    }
}


