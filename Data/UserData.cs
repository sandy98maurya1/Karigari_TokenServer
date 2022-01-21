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

        public User GetUserByContact(string Contact)
        {
            return _dbcontext.Users.FirstOrDefault(x => x.Contact == Contact);

        }

        public User GetUserByEmail(string Email)
        {
            return _dbcontext.Users.FirstOrDefault(x => x.Email == Email);
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
                             Email = u.Email,
                             Password = u.Password,
                             Role = r.Name,
                             Contact = u.Contact,
                             IsActive = u.IsActive,
                             CreatedBy = u.CreatedBy,
                             CreatedDate = u.CreatedDate,
                             ModifiedDate = u.ModifiedDate,
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
