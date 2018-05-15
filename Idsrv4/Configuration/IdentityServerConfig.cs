using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace Idsrv4.Configuration
{
    public class IdentityServerConfig
    {
        public IdentityServerConfig()
        {
        }

		public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("web.api", "My API")
            };
        }

		public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "web.api" }
                }
            };
        }
    }
}
