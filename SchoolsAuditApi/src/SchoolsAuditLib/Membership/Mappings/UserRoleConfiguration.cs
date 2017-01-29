using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolsAuditDomainModel.Membership.Persistence
{
    public static class UserRoleConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<UserRole>();

            entityBuilder.ToTable("UserRole", schema: "Membership");
        }

    }
}