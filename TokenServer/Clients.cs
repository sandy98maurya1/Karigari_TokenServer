using IdentityServer4.Models;
using System.Collections.Generic;

namespace TokenServer
{
    public class Clients
    {
        public static IEnumerable<Client> GetClients =>
            new List<Client>
            {
                    new Client
                    {
                         ClientId = "secret_user_client_id",
                         ClientSecrets = { new Secret("secret".Sha256()) },
                         AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                         AllowedScopes = { "apiscope" }
                    }
            };
    }
}
