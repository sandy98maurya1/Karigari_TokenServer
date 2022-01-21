using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TokenServer
{
    public class ProfileService : IProfileService
    {
        UserManager _userManager;
        public ProfileService()
        {
            _userManager = new UserManager();
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.FindFirst("sub")?.Value;
            
            if (sub != null)
            {
                var user = await _userManager.FindByNameAsync(sub);
                var cp = await getClaims(user);
                var claims = cp.Claims;
                if (context.RequestedClaimTypes != null && context.RequestedClaimTypes.Any())
                {
                   claims = claims.Where(x=> context.RequestedClaimTypes.Contains(x.Type)).ToArray().AsEnumerable();    
                }
                context.IssuedClaims = claims.ToList();
            }
        }
        
        private async Task<ClaimsPrincipal> getClaims(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var id = new ClaimsIdentity();
            id.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, user.Username));
            id.AddClaims(await _userManager.GetClaimsAsync(user));
            return new ClaimsPrincipal(id);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                //get subject from context (set in ResourceOwnerPasswordValidator.ValidateAsync),
                // var userId = context.Subject.Claims.FirstOrDefault(x => x.Value == "user_id");
                var sub = context.Subject.FindFirst("sub")?.Value;

                if (!string.IsNullOrEmpty(sub))
                {
                    var user = await _userManager.FindByNameAsync(sub);

                    if (user != null)
                    {
                        context.IsActive = true;
                        //if (user.IsActive)
                        //{
                        //    context.IsActive = user.IsActive;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                //handle error logging
            }
        }
    }
}
