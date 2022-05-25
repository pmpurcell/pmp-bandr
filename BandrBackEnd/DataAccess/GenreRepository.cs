using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BandrBackEnd.DataAccess
{
    public class GenreRepository : IGenreRepository
    {

        private readonly IConfiguration _configuration;

        public GenreRepository(IConfiguration config)
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

        public List<Genre> getAllGenres()
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      GenreName
                                      
                                      FROM Genre
                                      ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Genre> genres = new List<Genre>();

                    while (reader.Read())
                    {
                        Genre genre = new Genre
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            GenreName = reader.GetString(reader.GetOrdinal("GenreName")),
                        };

                       genres.Add(genre);
                    }

                    reader.Close();
                    return genres;
                }
            }
        }

        public Genre getGenreById(int id)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      GenreName
                                      
                                      FROM
                                      Genre WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Genre genre = new Genre
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            GenreName = reader.GetString(reader.GetOrdinal("GenreName")),
                        };

                        reader.Close();
                        return genre;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }

        }
    }
}
