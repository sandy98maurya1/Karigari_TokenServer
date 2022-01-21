using IdentityServer4.Models;
using IdentityServer4.Validation;
using Models;
using System;
using System.Threading.Tasks;

namespace TokenServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private UserManager userManager {get;set;}

        public ResourceOwnerPasswordValidator()
        {
            userManager = new UserManager();        
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user =  userManager.FindByNameAsync(context.UserName).Result;
            try
            {
                //get your user model from db (by username - in my case its email)
                if (user != null)
                {
                    //check if password match - remember to hash password if stored as hash in db
                    if (user.Password == context.Password)
                    {
                        //set the result
                        context.Result = new GrantValidationResult(
                            subject: user.Id.ToString(),
                            authenticationMethod: "custom",
                            claims: userManager.GetClaimsAsync(user).Result);

                        return;
                    }

                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                    return;
                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
                return;
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }

        }
    }
}
