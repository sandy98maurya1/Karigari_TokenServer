using Models;
using System.Collections.Generic;

namespace Contracts.DataContracts
{
    public interface IUserData
    {
        public User GetUser(string userName, string password);
        public UserDTO GetUserByUserName(string userName);
        public User GetUserById(int Id);
        public User UpdateUser(User user);
        
    }
}
