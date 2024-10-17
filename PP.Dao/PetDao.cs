using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PP.Exception;
using PP.Entity;
using PP.Util;
using System.Data;

namespace PP.Dao
{
    public class PetDao
    {
        private string connectionString;

        public PetDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pet> GetAvailablePets()
        {
            List<Pet> pets = new List<Pet>();
            using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
            {
                // Correct SQL command to select required columns
                using (SqlCommand cmd = new SqlCommand("SELECT Name, Age, Breed FROM Pet", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Ensure you have a constructor for Pet that accepts Name, Age, and Breed
                            // Handle potential NULL values (if applicable)
                            string name = reader["Name"].ToString();
                            int age = reader.IsDBNull(reader.GetOrdinal("Age")) ? 0 : reader.GetInt32(reader.GetOrdinal("Age"));
                            string breed = reader["Breed"].ToString();

                            pets.Add(new Pet(name, age, breed));
                        }
                    }
                }
            }
            return pets;
        }
    }
    }

