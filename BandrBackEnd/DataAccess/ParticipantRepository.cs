using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BandrBackEnd.DataAccess
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly IConfiguration _config;

        public ParticipantRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public Participant GetParticipantById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      UserId
                                      
                                      FROM
                                      Participant
                                      WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Participant participant = new Participant
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            userId = reader.GetInt32(reader.GetOrdinal("id")),
                        };

                        reader.Close();
                        return participant;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public void CreateParticipant(Participant participant)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      INSERT INTO Participant
                                      (UserId)
                                      OUTPUT Inserted.Id
                                      VALUES (@userId)";

                    cmd.Parameters.AddWithValue("@userId", participant.userId);

                    int id = (int)cmd.ExecuteScalar();

                    participant.Id = id; 
                }
            }
        }

        public void DeleteParticipant(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      DELETE FROM Participant
                                        WHERE Id = id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
