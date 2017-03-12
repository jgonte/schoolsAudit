using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace SchoolsAudit
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("schoolsAuditApi", "SchoolsAudit API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "schoolsAuditWebClient",
                    ClientName = "Schools Audit Web Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = 
                    {
                        "http://localhost:5002/index.html"
                    },
                    PostLogoutRedirectUris = 
                    {
                        "http://localhost:5002/login.html"
                    },
                    AllowedCorsOrigins = 
                    {
                        "http://localhost:5002"
                    },
                    AllowedScopes = 
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "schoolsAuditApi"
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

    }
}