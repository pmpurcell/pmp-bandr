using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BandrBackEnd.DataAccess
{
    public class PlayedGenreRepository : IPlayedGenreRepository
    {

        private readonly IConfiguration _configuration;

        public PlayedGenreRepository(IConfiguration configuration)
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

        public List<PlayedGenre> getPlayedGenresByUser(int userId)
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
                                       p.GenreId,
                                       g.GenreName
                                       
                                       FROM PlayedGenres as p
                                       LEFT JOIN Genre as g on p.GenreId = g.Id
                                       WHERE UserId = @userId
                                        ";

                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<PlayedGenre> playedGenres = new List<PlayedGenre>();
                    while (reader.Read())
                    {
                        PlayedGenre playedGenre = new PlayedGenre
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            GenreId = reader.GetInt32(reader.GetOrdinal("GenreId")),
                            Genre = new Genre()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                GenreName = reader.GetString(reader.GetOrdinal("GenreName"))
                            }
                        };
                        playedGenres.Add(playedGenre);
                    }
                    reader.Close();
                    return playedGenres;
                }
            }
        }

        public PlayedGenre getSinglePlayedGenre(int id)
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
                                        p.GenreId,
                                        g.GenreName
                                        
                                        FROM PlayedGenres as p
                                        LEFT JOIN Genre as g on p.GenreId = g.Id
                                        WHERE p.Id = @id
                                        ";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        PlayedGenre playedGenre = new PlayedGenre
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            GenreId = reader.GetInt32(reader.GetOrdinal("GenreId")),
                            Genre = new Genre()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                GenreName = reader.GetString(reader.GetOrdinal("GenreName"))
                            }
                        };

                        reader.Close();
                        return playedGenre;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public void addPlayedGenre(PlayedGenre playedGenre)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO PlayedGenres
                                       (UserId,
                                       GenreId)
                                        
                                        OUTPUT Inserted.Id
                                        VALUES (@UserId, @GenreId)";

                    cmd.Parameters.AddWithValue("@UserId", playedGenre.UserId);
                    cmd.Parameters.AddWithValue("@GenreId", playedGenre.GenreId);

                    int id = (int)cmd.ExecuteScalar();

                    playedGenre.Id = id;
                }
            }
        }

        public void removePlayedGenre(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      DELETE FROM PlayedGenres
                                      WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
