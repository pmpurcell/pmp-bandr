using BandrBackEnd.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;


namespace BandrBackEnd.DataAccess
{
    public interface IUserRepository
    {
        public User getSingleUser(int firebaseUid);
        public void createUser(User user);
        public void updateUser(User user);
        public void deleteUser(int id);
    }
}
