using Models;
using System.Collections.Generic;

namespace Contracts.DataContracts
{
    public interface IUserData
    {
        public User GetUser(string userName, string password);
        public User GetUserByContact(string Contact);
        public UserDTO GetUserByUserName(string userName);
        public User GetUserById(int Id);
        public User GetUserByEmail(string Email);
        public User UpdateUser(User user);
        
    }
}
