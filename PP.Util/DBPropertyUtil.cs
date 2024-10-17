using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Util
{
    public static class DBPropertyUtil
    {
        private static IConfigurationRoot configuration;
        static string s = null;
        static DBPropertyUtil()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("C:\\Users\\pushk\\source\\repos\\PetPals_PP\\PP.Util\\appsettings.json",
            optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }
        public static string ReturnCn(string key)
        {
            s = configuration.GetConnectionString("dbCn");
            return s;
        }
    }
}



