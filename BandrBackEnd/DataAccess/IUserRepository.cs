using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;


namespace BandrBackEnd.DataAccess
{
    public interface IUserRepository
    {
        public List<User> getAllUsers(int userId);
        public User getSingleUser(int firebaseUid);

        public User getUserByFirebaseId(string uid);
        public void createUser(User user);
        public void updateUser(User user);
        public void deleteUser(int id);
        public bool checkUserExists(string uid);
    }
}
