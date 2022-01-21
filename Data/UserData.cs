using Contracts.DataContracts;
using Data.EntityFramework;
using Models;
using System;
using System.Linq;

namespace Data
{
    public class UserData : IUserData
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserData(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public User GetUser(string userName, string password)
        {
            return _dbcontext.Users.FirstOrDefault(x => x.Name == userName && x.Password == password);
        }
        

        public User GetUserById(int Id)
        {
            return _dbcontext.Users.FirstOrDefault(x => x.Id == Id);
        }

        public UserDTO GetUserByUserName(string userName)
        {
            var result = from u in _dbcontext.Users
                         join r in _dbcontext.UserRoles
                         on u.RoleId equals (r.Id)
                         where u.Name == userName   
                         select new UserDTO
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Password = u.Password,
                             Role = r.Name,
                             IsActive = u.IsActive,
                             RefreshToken = u.RefreshToken
                             
                         };

            return result.FirstOrDefault();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
