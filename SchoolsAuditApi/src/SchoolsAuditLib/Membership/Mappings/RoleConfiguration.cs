using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolsAuditDomainModel.Membership.Persistence
{
    public static class RoleConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Role>();

            entityBuilder.ToTable("Role", schema: "Membership");
        }

    }
}