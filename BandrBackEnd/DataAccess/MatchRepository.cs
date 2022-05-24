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

        public Match getMatch(int id)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                       SELECT
                                       Id,
                                       swiperId,
                                       swiperMatch,
                                       recId
                                       recMatch
                                       
                                       FROM
                                       Match WHERE Id = @id
                                       ";

                    cmd.Parameters.AddWithValue("id", id);

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

        public void createMatch(Match match)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO Match
                                        swiperId,
                                        swiperMatch,
                                        recId,
                                        recMatch
                                        
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
                                      UPDATE Match
                                      SET
                                      swiperId = @swiperId
                                      swiperMatch = @swiperMatch
                                      recId = @recId
                                      recMatch = recMatch
                                      
                                      WHERE Id = @id";


                    cmd.Parameters.AddWithValue("@swiperId", match.swiperId);
                    cmd.Parameters.AddWithValue("@swiperMatch", match.swiperMatch);
                    cmd.Parameters.AddWithValue("@recId", match.recId);
                    cmd.Parameters.AddWithValue("@recMatch", match.recMatch);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deleteMatch(int id)
        {
            using(SqlConnection conn = Connection)
            {
                Connection.Open();

                using (SqlCommand cmd = Connection.CreateCommand())
                {

                    cmd.CommandText = @"
                                      DELETE FROM Match
                                      WHERE ID = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
