using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace SchoolsAudit
{
    public static class ApiResources
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("serviceLogApi", "SchoolsAudit API")
            };
        }

    }
}