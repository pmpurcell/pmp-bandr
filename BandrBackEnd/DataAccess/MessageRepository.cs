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

        public List <Message> GetMessagesByPartId(int participantId)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                       SELECT
                                       Id,
                                       ParticipantId,
                                       Body,
                                       TimeSent
                                       
                                       FROM
                                       [Message] WHERE ParticipantId = @participantId
                                       ";

                    cmd.Parameters.AddWithValue("ParticipantId", participantId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List <Message> messages = new List<Message>();
                    while (reader.Read())
                    {
                        Message message = new Message
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
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
                                       Body,
                                       TimeSent)
                                        
                                        OUTPUT Inserted.Id
                                        VALUES (@ParticipantId, @Body, @TimeSent)";

                    cmd.Parameters.AddWithValue("@ParticipantId", message.participantId);
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
                                      Body = @Body,
                                      TimeSent = @TimeSent
                                      
                                      WHERE Id = @id";


                    cmd.Parameters.AddWithValue("@ParticipantId", message.participantId);
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
