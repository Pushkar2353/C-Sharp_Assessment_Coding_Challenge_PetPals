using PP.Entity;
using PP.Exception;
using PP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PP.Dao
{
    public class DonationDao
    {
        private string connectionString;

        public DonationDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void RecordDonation(Donation donation)
        {
            using (SqlConnection connection = DBConnUtil.GetConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Donation (DonorName, Amount) VALUES (@DonorName, @Amount)", connection);
                command.Parameters.AddWithValue("@DonorName", donation.DonorName);
                command.Parameters.AddWithValue("@Amount", donation.Amount);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (ApplicationException ex)
                {
                    throw new DatabaseException("Error recording donation: " + ex.Message);
                }
            }
        }
    }
}


