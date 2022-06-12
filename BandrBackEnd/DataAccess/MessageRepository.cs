using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BandrBackEnd.DataAccess
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IConfiguration _configuration;

        public MessageRepository(IConfiguration config)
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

        public List <Message> GetMessagesByMatchId(int matchId)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                       SELECT
                                       Id,
                                       MatchId,
                                       ParticipantId,
                                       Body,
                                       TimeSent
                                       
                                       FROM
                                       [Message] WHERE MatchId = @matchId
                                       ";

                    cmd.Parameters.AddWithValue("MatchId", matchId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List <Message> messages = new List<Message>();
                    while (reader.Read())
                    {
                        Message message = new Message
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            matchId = reader.GetInt32(reader.GetOrdinal("MatchId")),
                            participantId = reader.GetInt32(reader.GetOrdinal("ParticipantId")),
                            body = reader.GetString(reader.GetOrdinal("Body")),
                            timeSent = reader.GetDateTime(reader.GetOrdinal("TimeSent")),
                        };

                        messages.Add(message);

                    }
                        reader.Close();
                        return messages;
                }
            }
        }

        public Message GetMessageById(int id)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                       SELECT
                                       Id,
                                       MatchId,
                                       ParticipantId,
                                       Body,
                                       TimeSent
                                       
                                       FROM
                                       [Message] WHERE Id = @id
                                       ";

                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Message message = new Message
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            matchId = reader.GetInt32(reader.GetOrdinal("MatchId")),
                            participantId = reader.GetInt32(reader.GetOrdinal("ParticipantId")),
                            body = reader.GetString(reader.GetOrdinal("Body")),
                            timeSent = reader.GetDateTime(reader.GetOrdinal("TimeSent")),
                        };

                        reader.Close();
                        return message;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public void createMessage(Message message)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        INSERT INTO [Message]
                                       (ParticipantId,
                                       MatchId,
                                       Body,
                                       TimeSent)
                                        
                                        OUTPUT Inserted.Id
                                        VALUES (@ParticipantId, @MatchId, @Body, @TimeSent)";

                    cmd.Parameters.AddWithValue("@ParticipantId", message.participantId);
                    cmd.Parameters.AddWithValue("@MatchId", message.matchId);
                    cmd.Parameters.AddWithValue("@Body", message.body);
                    cmd.Parameters.AddWithValue("@TimeSent", message.timeSent);

                    int id = (int)cmd.ExecuteScalar();

                    message.Id = id;
                }
            }
        }

        public void updateMessage(Message message)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      UPDATE [Message]
                                      SET
                                      ParticipantId = @ParticipantId,
                                      MatchId = @MatchId,
                                      Body = @Body,
                                      TimeSent = @TimeSent
                                      
                                      WHERE Id = @id";


                    cmd.Parameters.AddWithValue("@ParticipantId", message.participantId);
                    cmd.Parameters.AddWithValue("@MatchId", message.matchId);
                    cmd.Parameters.AddWithValue("@Body", message.body);
                    cmd.Parameters.AddWithValue("@TimeSent", message.timeSent);
                    cmd.Parameters.AddWithValue("@id", message.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deleteMessage(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"
                                      DELETE FROM [Message]
                                      WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
