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
        public DbSet<School> Schools { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<UserSchool> UsersSchools { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SchoolConfiguration.Configure(modelBuilder);

            DocumentConfiguration.Configure(modelBuilder);

            UserSchoolConfiguration.Configure(modelBuilder);
        }

    }
}