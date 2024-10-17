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
using System.Data;

namespace PP.Dao
{
    public class AdoptionEventDao
    {
        private string connectionString;

        public AdoptionEventDao(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<AdoptionEvent> GetUpcomingEvents()
        {
            List<AdoptionEvent> events = new List<AdoptionEvent>();
            using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM AdoptionEvent WHERE EventDate > GETDATE()", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming you have a constructor for AdoptionEvent
                            events.Add(new AdoptionEvent(reader.GetInt32("EventID"), reader["EventName"].ToString()));
                        }
                    }
                }
            }
            return events;
        }

        public void RegisterParticipant(int eventId, string participantName, int shelterId, int petId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EventParticipant (ShelterID, EventID, PetID, ParticipantName) VALUES (@ShelterID, @EventID, @PetID, @ParticipantName)", conn))
                {
                    cmd.Parameters.AddWithValue("@ShelterID", shelterId);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    cmd.Parameters.AddWithValue("@PetID", petId);  // Ensure PetID is provided
                    cmd.Parameters.AddWithValue("@ParticipantName", participantName);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new DatabaseException("Error while registering participant: " + ex.Message);
                    }
                }
            }
        }

    }
}


