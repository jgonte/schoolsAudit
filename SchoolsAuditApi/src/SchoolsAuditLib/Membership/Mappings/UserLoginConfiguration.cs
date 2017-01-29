using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolsAuditDomainModel.Membership.Persistence
{
    public static class UserLoginConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<UserLogin>();

            entityBuilder.ToTable("UserLogin", schema: "Membership");
        }

    }
}