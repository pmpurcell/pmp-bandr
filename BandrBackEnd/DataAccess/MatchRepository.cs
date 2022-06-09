using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BandrBackEnd.DataAccess
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IConfiguration _configuration;

        public MatchRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public Match getMatchByIds(int recId, int swiperId)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                       SELECT
                                       Id,
                                       SwiperId,
                                       SwiperMatch,
                                       RecId,
                                       RecMatch
                                       
                                       FROM
                                       [Match] WHERE recId = @recId AND SwiperId = @swiperId
                                       ";

                    cmd.Parameters.AddWithValue("@recId", recId);
                    cmd.Parameters.AddWithValue("@swiperId", swiperId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Match match = new Match
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            swiperId = reader.GetInt32(reader.GetOrdinal("swiperId")),
                            swiperMatch = reader.GetBoolean(reader.GetOrdinal("swiperMatch")),
                            recId = reader.GetInt32(reader.GetOrdinal("recId")),
                            recMatch = reader.GetBoolean(reader.GetOrdinal("recMatch"))
                        };

                        reader.Close();
                        return match;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public bool checkMatchExists(int recId, int swiperId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *
                                        FROM [Match]
										WHERE RecId = @recId
                                        AND SwiperId = @swiperId";

                    // Check for SwiperId As Well//

                    cmd.Parameters.AddWithValue("@recId", recId);
                    cmd.Parameters.AddWithValue("@swiperId", swiperId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
            }
        }

        public void createMatch(Match match)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO [Match]
                                        (SwiperId,
                                        SwiperMatch,
                                        RecId,
                                        RecMatch)
                                        
                                        OUTPUT Inserted.Id
                                        VALUES (@swiperId, @swiperMatch, @recId, @recMatch)";

                    cmd.Parameters.AddWithValue("@swiperId", match.swiperId);
                    cmd.Parameters.AddWithValue("@swiperMatch", match.swiperMatch);
                    cmd.Parameters.AddWithValue("@recId", match.recId);
                    cmd.Parameters.AddWithValue("@recMatch", match.recMatch);

                    int id = (int)cmd.ExecuteScalar();

                    match.Id = id;
                }
            }
        }

        public void updateMatch(Match match)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      UPDATE [Match]
                                      SET
                                      SwiperId = @swiperId,
                                      SwiperMatch = @swiperMatch,
                                      RecId = @recId,
                                      RecMatch = recMatch
                                      
                                      WHERE Id = @id";


                    cmd.Parameters.AddWithValue("@swiperId", match.swiperId);
                    cmd.Parameters.AddWithValue("@swiperMatch", match.swiperMatch);
                    cmd.Parameters.AddWithValue("@recId", match.recId);
                    cmd.Parameters.AddWithValue("@recMatch", match.recMatch);
                    cmd.Parameters.AddWithValue("@id", match.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deleteMatch(int id)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"
                                      DELETE FROM [Match]
                                      WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
