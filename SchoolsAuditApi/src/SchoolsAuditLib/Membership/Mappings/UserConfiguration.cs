using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolsAuditDomainModel.Schools;

namespace SchoolsAuditDomainModel.Membership.Persistence
{
    public static class UserConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<User>();

            entityBuilder.ToTable("User", schema: "Membership");

            entityBuilder.HasMany(t => t.Documents)
                .WithOne()
                .HasForeignKey(t => t.UserId)
                .HasConstraintName("User_Documents_FK")
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}