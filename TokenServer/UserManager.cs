using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TokenServer
{
    public class UserManager
    {
        public async Task<User> FindByNameAsync(string UserName)
        {
            var user = GetUser.SingleOrDefault(x=>x.Username == UserName);

            return await Task.FromResult(user);
        }

        public async Task<bool> ChekPasswordAsync(User user, string password)
        {
            if(user.Password == password)
                return await Task.FromResult(true);
            
            return await Task.FromResult(false);
        }

        public async Task<List<Claim>> GetClaimsAsync(User user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("roleType", "CanReaddata"));

            return await Task.FromResult(claims);

        }

        public List<User> GetUser =>
            new List<User>
            {
                new User
                {

                    Id = 1,
                    Username = "alice",
                    Password = "Bunny11",
                    //Contact = "12345678",
                    //Email = "test@test.com",
                    //RoleId = 1,
                    //IsActive = true,
                    //CreatedBy = 1,
                    //CreatedDate = DateTime.Now
                }
            };
    }
}
