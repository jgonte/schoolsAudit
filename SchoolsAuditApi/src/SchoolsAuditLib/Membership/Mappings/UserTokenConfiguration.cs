using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolsAuditDomainModel.Membership.Persistence
{
    public static class UserTokenConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<UserToken>();

            entityBuilder.ToTable("UserToken", schema: "Membership");
        }

    }
}