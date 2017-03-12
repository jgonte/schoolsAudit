using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolsAuditDomainModel.Membership.Persistence
{
    public static class UserRegistrationConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<UserRegistration>();

            entityBuilder.ToTable("UserRegistration", schema: "Membership");

            entityBuilder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}