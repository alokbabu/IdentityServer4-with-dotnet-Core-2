using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

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
                    ClientId = "client.api",
					AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "web.api" }
                },
				new Client
				{
					ClientId = "client.mvc",
					ClientName = "MVC Client",
					AllowedGrantTypes = GrantTypes.Implicit,
					RequireConsent = false,
					//ClientSecrets = {
					//	new Secret("secret".Sha256())
					//},

					RedirectUris = { "http://localhost:8080/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:8080/signout-callback-oidc"},

					AllowedScopes = new List<string>
					{ 
						"web.api",
						IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
					}
     			}
            };
        }

		public static List<IdentityResource> GetIdentityResources()
        {
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile()
			};
        }
       

		public static List<TestUser> GetUsers()
		{
			return new List<TestUser>
			{
				new TestUser
				{
					SubjectId = "1",
					Username = "bob",
					Password = "password"                   
				}
			};
		}
    }
}
