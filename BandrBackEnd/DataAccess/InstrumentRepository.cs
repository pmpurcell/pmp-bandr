using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BandrBackEnd.DataAccess
{
    public class InstrumentRepository : IInstrumentRepository
    {

        private readonly IConfiguration _configuration;

        public InstrumentRepository(IConfiguration config)
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

        public List<Instrument> getAllInstruments()
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      InstrumentName
                                      
                                      FROM Instrument
                                      ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instrument> instruments = new List<Instrument>();

                    while (reader.Read())
                    {
                        Instrument instrument = new Instrument
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            InstrumentName = reader.GetString(reader.GetOrdinal("InstrumentName")),
                        };

                        instruments.Add(instrument);
                    }

                    reader.Close();
                    return instruments;
                }
            }
        }

        public Instrument getInstrumentById(int id)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      InstrumentName
                                      
                                      FROM
                                      Instrument WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Instrument instrument = new Instrument
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            InstrumentName = reader.GetString(reader.GetOrdinal("InstrumentName")),
                        };

                        reader.Close();
                        return instrument;
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
