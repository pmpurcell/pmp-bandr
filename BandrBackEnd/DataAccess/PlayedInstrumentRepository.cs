using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BandrBackEnd.DataAccess
{
    public class PlayedInstrumentRepository : IPlayedInstrumentRepository
    {

        private readonly IConfiguration _configuration;

        public PlayedInstrumentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public List<PlayedInstrument> getPlayedInstrumentsByUser(int userId)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                                       SELECT
                                       p.Id,
                                       p.UserId,
                                       p.InstrumentId,
                                       i.InstrumentName
                                       
                                       FROM PlayedInstruments as p
                                       LEFT JOIN Instrument as i on p.InstrumentId = i.Id
                                       WHERE UserId = @userId
                                        ";

                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<PlayedInstrument> playedInstruments = new List<PlayedInstrument>();
                    while (reader.Read())
                    {
                        PlayedInstrument playedInstrument = new PlayedInstrument
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            InstrumentId = reader.GetInt32(reader.GetOrdinal("InstrumentId")),
                            Instrument = new Instrument() {Id = reader.GetInt32(reader.GetOrdinal("Id")),InstrumentName = reader.GetString(reader.GetOrdinal("InstrumentName"))
                            }
                        };
                        playedInstruments.Add(playedInstrument);
                    }
                    reader.Close();
                    return playedInstruments;
                }
            }
        }

        public PlayedInstrument getSinglePlayedInstrument(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT
                                        p.Id,
                                        p.UserId,
                                        p.InstrumentId,
                                        i.InstrumentName
                                        
                                        FROM PlayedInstruments as p
                                        LEFT JOIN Instrument as i on p.InstrumentId = i.Id
                                        WHERE p.Id = @id
                                        ";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        PlayedInstrument playedInstrument = new PlayedInstrument
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            InstrumentId = reader.GetInt32(reader.GetOrdinal("InstrumentId")),
                            Instrument = new Instrument()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                InstrumentName = reader.GetString(reader.GetOrdinal("InstrumentName"))
                            }
                        };

                        reader.Close();
                        return playedInstrument;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public void addPlayedInstrument(PlayedInstrument playedInstrument)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO PlayedInstruments
                                       (UserId,
                                       InstrumentId)
                                        
                                        OUTPUT Inserted.Id
                                        VALUES (@UserId, @InstrumentId)";

                    cmd.Parameters.AddWithValue("@UserId", playedInstrument.UserId);
                    cmd.Parameters.AddWithValue("@InstrumentId", playedInstrument.InstrumentId);

                    int id = (int)cmd.ExecuteScalar();

                    playedInstrument.Id = id;
                }
            }
        }

        public void removePlayedInstrument(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      DELETE FROM PlayedInstruments
                                      WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
