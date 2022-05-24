using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BandrBackEnd.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }  

        public SqlConnection Connection
        {
            get { 
                
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            
            }
        }

        public User getSingleUser(int firebaseUid)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT
                                        Id,
                                        firebaseUid,
                                        photo,
                                        userName,
                                        userAge,
                                        userBio,
                                        location,
                                        skillLevel
                                        FROM
                                        [User] WHERE firebaseUid = @firebaseUid
                                        ";

                    cmd.Parameters.AddWithValue("@firebaseUid", firebaseUid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User user = new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("userId")),
                            firebaseUid = reader.GetInt32(reader.GetOrdinal("firebaseUid")),
                            photo = reader.GetString(reader.GetOrdinal("photos")),
                            userName = reader.GetString(reader.GetOrdinal("username")),
                            userAge = reader.GetInt32(reader.GetOrdinal("userAge")),
                            userBio = reader.GetString(reader.GetOrdinal("userBio")),
                            skillLevel = reader.GetString(reader.GetOrdinal("skillLevel")),
                        };

                        reader.Close();
                        return user;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public void createUser(User user)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                                        INSERT INTO User
                                        photo,
                                        userName,
                                        userAge,
                                        userBio,
                                        location,
                                        skillLevel,

                                        OUTPUT Inserted.Id
                                        VALUES (@photo, @userName, @userBio, location, skillLevel)";

                        cmd.Parameters.AddWithValue("@photo", user.photo);
                        cmd.Parameters.AddWithValue("@userName", user.userName);
                        cmd.Parameters.AddWithValue("@userAge", user.userAge);
                        cmd.Parameters.AddWithValue("@userBio", user.userBio);
                        cmd.Parameters.AddWithValue("@location", user.location);
                        cmd.Parameters.AddWithValue("@skillLevel", user.skillLevel);

                        int id = (int)cmd.ExecuteScalar();

                        user.Id = id;
                    }
                }
            }

        public void updateUser(User user)
        {
            using (SqlConnection conn = Connection)
            {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      UPDATE User
                                      SET
                                      photo = @photo
                                      userName = @userName
                                      userAge = @userAge
                                      userBio = @userBio
                                      location = @location
                                      skillLevel = @skillLevel

                                      WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@photo", user.photo);
                    cmd.Parameters.AddWithValue("@userName", user.userName);
                    cmd.Parameters.AddWithValue("@userAge", user.userAge);
                    cmd.Parameters.AddWithValue("@userBio", user.userBio);
                    cmd.Parameters.AddWithValue("@location", user.location);
                    cmd.Parameters.AddWithValue("@skillLevel", user.skillLevel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deleteUser(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                                      DELETE FROM User
                                      WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        }
    }