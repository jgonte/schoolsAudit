using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace SchoolsAudit
{
    public static class Clients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "serviceLogWebClient",
                    ClientName = "Service Log Web Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = 
                    {
                        "http://localhost:5002/auth-redirect.html"
                    },
                    PostLogoutRedirectUris = 
                    {
                        "http://localhost:5002/index.html"
                    },
                    AllowedCorsOrigins = 
                    {
                        "http://localhost:5002"
                    },
                    AllowedScopes = 
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "serviceLogApi"
                    }
                }
            };
        }

    }
}