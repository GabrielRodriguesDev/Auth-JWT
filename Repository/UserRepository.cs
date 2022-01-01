using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_JWT.Models;

namespace Auth_JWT.Repository
{
    public class UserRepository
    {
        public static UserEntity Get(string username, string password)
        {
            var users = new List<UserEntity>();
            users.Add(new UserEntity { Id = Guid.NewGuid(), UserName = "Gabriel", Password = "fx870", Role = "manager" });
            users.Add(new UserEntity { Id = Guid.NewGuid(), UserName = "Drika", Password = "fx870", Role = "employee" });
            return users.Where(user => user.UserName.Equals(username) && user.Password.Equals(password)).FirstOrDefault();
        }
    }
}
