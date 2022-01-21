using IdentityServer4.Models;
using System.Collections.Generic;

namespace TokenServer
{
    public class Scopes
    {
        public static IEnumerable<Scope> GetScope =>
            new List<Scope>
            {
                new Scope
                {
                    Name ="apiscope",
                    DisplayName ="API 1",
                    Description = "API 1 feature and data",
                }
            };
    }
}
