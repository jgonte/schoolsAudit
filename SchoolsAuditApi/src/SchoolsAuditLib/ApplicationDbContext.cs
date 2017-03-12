using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolsAuditDomainModel.Membership;
using SchoolsAuditDomainModel.Membership.Persistence;
using SchoolsAuditDomainModel.Schools;
using SchoolsAuditDomainModel.Schools.Persistence;

namespace SchoolsAuditDomainModel.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Role> Roles { get; set; }

        public DbSet<RoleClaim> RoleClaims { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<UserSchool> UsersSchools { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RoleConfiguration.Configure(modelBuilder);

            RoleClaimConfiguration.Configure(modelBuilder);

            UserConfiguration.Configure(modelBuilder);

            UserClaimConfiguration.Configure(modelBuilder);

            UserLoginConfiguration.Configure(modelBuilder);

            UserRoleConfiguration.Configure(modelBuilder);

            UserTokenConfiguration.Configure(modelBuilder);

            SchoolConfiguration.Configure(modelBuilder);

            DocumentConfiguration.Configure(modelBuilder);

            UserSchoolConfiguration.Configure(modelBuilder);
        }

    }
}