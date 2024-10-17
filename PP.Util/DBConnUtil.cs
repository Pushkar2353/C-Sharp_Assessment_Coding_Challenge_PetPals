using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PP.Exception;

namespace PP.Util
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (SqlException sqlEx)
            {
                throw new DatabaseException("SQL Connection error: " + sqlEx.Message);
            }
            catch (InvalidOperationException invOpEx)
            {
                throw new DatabaseException("Invalid operation: " + invOpEx.Message);
            }
            catch (ApplicationException ex)
            {
                throw new DatabaseException("General error: " + ex.Message);
            }
        }
    }
}






