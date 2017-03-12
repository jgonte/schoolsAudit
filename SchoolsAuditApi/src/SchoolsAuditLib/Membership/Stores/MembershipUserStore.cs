using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using SchoolsAuditDomainModel.Persistence;

namespace SchoolsAuditDomainModel.Membership.Stores
{
    public class MembershipUserStore : UserStore<User, Role, ApplicationDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
    {
        public MembershipUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        protected override UserClaim CreateUserClaim(User user, Claim claim)
        {
            var userClaim = new UserClaim
            {
                UserId = user.Id
            };

            userClaim.InitializeFromClaim(claim);

            return userClaim;
        }

        protected override UserLogin CreateUserLogin(User user, UserLoginInfo login)
        {
            return new UserLogin
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };
        }

        protected override UserRole CreateUserRole(User user, Role role)
        {
            return new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            };
        }

        protected override UserToken CreateUserToken(User user, string loginProvider, string name, string value)
        {
            return new UserToken
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
        }

    }
}