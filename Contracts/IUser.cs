using Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IUser
    {
        public User GetUser(string userName, string password);
        public UserDTO GetUserByUserName(string userName);
        public User GetUserById(int Id);
        public User UpdateUser(User user);
        
    }
}
