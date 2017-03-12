using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using SchoolsAuditDomainModel.Persistence;

namespace SchoolsAuditDomainModel.Membership.Stores
{
    public class MembershipRoleStore : RoleStore<Role, ApplicationDbContext, int, UserRole, RoleClaim>
    {
        public MembershipRoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        protected override RoleClaim CreateRoleClaim(Role role, Claim claim)
        {
            return new RoleClaim
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
        }

    }
}