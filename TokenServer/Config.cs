using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace TokenServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources =>
            new List<ApiResource>
            {
                new ApiResource {
                    Name = "myresourceapi",
                    DisplayName = "My Resource Api",
                    ApiSecrets = { new Secret("a75a559d-1dab-4c65-9bc0-f8e590cb388d".Sha256()) },
                    Scopes = new List<Scope> {
                        new Scope("apiscope"),
                        
                    }
                }
            };

        public static IEnumerable<Client> GetClients =>
            new List<Client>
            {
                    new Client
                    {
                         ClientId = "secret_client_id",
                         AllowedGrantTypes = GrantTypes.ClientCredentials,
                         ClientSecrets = { new Secret("secret".Sha256()) },
                         AllowedScopes = { "apiscope"}
                    },
                    new Client
                    {
                         ClientId = "secret_user_client_id",
                         AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                         ClientSecrets = { new Secret("secret".Sha256()) },
                         AllowedScopes = { "apiscope" }
                    }
            };

        public static List<TestUser> GetTestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "user",
                    Password = "user",
                    Claims = new[]
                    {
                        new Claim("roleType","CanReaddata")
                    },
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "admin",
                    Password = "admin",
                    Claims = new[]
                    {
                        new Claim("roleType","CanUpdatedata")
                    },
                },
            };
    }
}
