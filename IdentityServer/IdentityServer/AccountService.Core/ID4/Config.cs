using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace AccountService.Core.ID4
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new ApiResource[]
            {
                new ApiResource("api","Web Api"),
            };
        }

        public static IEnumerable<IdentityResource> GetAllIdentityResource()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                //new IdentityResources.Email(),
                //new IdentityResources.Profile(),
                //new IdentityResources.Phone(),
                //new IdentityResources.Address()
            };
        }

        public static IEnumerable<Client> GetAllClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "js",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,
                    //ClientSecrets = new List<Secret>{new Secret("secret")},
                    RedirectUris = new List<string>{"http://localhost:3000/callback.html"},
                    AllowedScopes = new List<string>{"api", IdentityServerConstants.StandardScopes.OpenId},
                    PostLogoutRedirectUris = new List<string>{ "http://localhost:3000" }
                },
                new Client
                {
                    ClientId = "portal-external-sso",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,
                    //ClientSecrets = new List<Secret>{new Secret("secret")},
                    RedirectUris = new List<string>{"http://localhost:3000/"},
                    AllowedScopes = new List<string>{"portal-api", IdentityServerConstants.StandardScopes.OpenId},
                    PostLogoutRedirectUris = new List<string>{ "http://localhost:3000" }
                }
            };
        }
    }
}
