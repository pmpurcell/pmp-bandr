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

        public List<User> getAllUsers()
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
                                        [User]
                                        ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List <User> users = new List<User>();

                   while (reader.Read())
                    {
                        User user = new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            firebaseUid = reader.GetString(reader.GetOrdinal("firebaseUid")),
                            photo = reader.GetString(reader.GetOrdinal("photo")),
                            userName = reader.GetString(reader.GetOrdinal("username")),
                            userAge = reader.GetInt32(reader.GetOrdinal("userAge")),
                            userBio = reader.GetString(reader.GetOrdinal("userBio")),
                            location = reader.GetString(reader.GetOrdinal("location")),
                            skillLevel = reader.GetString(reader.GetOrdinal("skillLevel")),
                        };

                        users.Add(user);

                    }
                        reader.Close();
                        return users;
                }
            }
        }

        public User getSingleUser(int Id)
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
                                        [User] WHERE Id = @Id
                                        ";

                    cmd.Parameters.AddWithValue("@Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User user = new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            firebaseUid = reader.GetString(reader.GetOrdinal("firebaseUid")),
                            photo = reader.GetString(reader.GetOrdinal("photo")),
                            userName = reader.GetString(reader.GetOrdinal("username")),
                            userAge = reader.GetInt32(reader.GetOrdinal("userAge")),
                            userBio = reader.GetString(reader.GetOrdinal("userBio")),
                            location = reader.GetString(reader.GetOrdinal("location")),
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

        public User getUserByFirebaseId(string uid)
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
                                        Photo,
                                        UserName,
                                        UserAge,
                                        UserBio,
                                        [Location],
                                        SkillLevel
                                        FROM
                                        [User] WHERE firebaseUid = @uid
                                        ";

                    cmd.Parameters.AddWithValue("@uid", uid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User user = new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            firebaseUid = reader.GetString(reader.GetOrdinal("firebaseUid")),
                            photo = reader.GetString(reader.GetOrdinal("photo")),
                            userName = reader.GetString(reader.GetOrdinal("username")),
                            userAge = reader.GetInt32(reader.GetOrdinal("userAge")),
                            userBio = reader.GetString(reader.GetOrdinal("userBio")),
                            location = reader.GetString(reader.GetOrdinal("location")),
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
                                        INSERT INTO [User]
                                        (
                                        firebaseUid,
                                        Photo,
                                        UserName,
                                        UserAge,
                                        UserBio,
                                        [Location],
                                        SkillLevel)

                                        OUTPUT Inserted.Id
                                        VALUES (@firebaseUid, @photo, @userName, @userAge, @userBio, @location, @skillLevel)";

                        cmd.Parameters.AddWithValue("@firebaseUid", user.firebaseUid);
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
                                      UPDATE [User]
                                      SET
                                      Photo = @photo,
                                      UserName = @userName,
                                      UserAge = @userAge,
                                      UserBio = @userBio,
                                      [Location] = @location,
                                      SkillLevel = @skillLevel

                                      WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@photo", user.photo);
                    cmd.Parameters.AddWithValue("@userName", user.userName);
                    cmd.Parameters.AddWithValue("@userAge", user.userAge);
                    cmd.Parameters.AddWithValue("@userBio", user.userBio);
                    cmd.Parameters.AddWithValue("@location", user.location);
                    cmd.Parameters.AddWithValue("@skillLevel", user.skillLevel);
                    cmd.Parameters.AddWithValue("@id", user.Id);

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
                                      DELETE FROM [User]
                                      WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        public bool checkUserExists(string uid)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *
                                        FROM [User]
										WHERE firebaseUid = @uid";
                    
                    cmd.Parameters.AddWithValue("@uid", uid);

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
        }
    }