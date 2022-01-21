using Contracts;
using Contracts.DataContracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserDomain : IUser
    {
        private readonly IUserData userData;

        public UserDomain(IUserData _userData)
        {
            userData = _userData;
        }

         public User GetUser(string userName, string password)
        {
            return userData.GetUser(userName, password);
        }

        public UserDTO GetUserByUserName(string userName)
        {
            return userData.GetUserByUserName(userName);
        }

        public User GetUserByEmail(string Email)
        {
            return userData.GetUserByEmail(Email);
        }

        public User GetUserById(int Id)
        {
            return userData.GetUserById(Id);
        }

        public User GetUserByContact(string Contact)
        {
            return userData.GetUserByContact(Contact);
        }

        public User UpdateUser(User user)
        {
            return userData.UpdateUser(user);
        }
    }
}
