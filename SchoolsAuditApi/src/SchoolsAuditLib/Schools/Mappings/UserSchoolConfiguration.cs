using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolsAuditDomainModel.Membership;

namespace SchoolsAuditDomainModel.Schools.Persistence
{
    public static class UserSchoolConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<UserSchool>();

            entityBuilder.ToTable("UserSchool", schema: "Schools");

            entityBuilder.HasKey(t => new 
            {
                t.UserId,
                t.SchoolId
            }).HasName("UserSchool_PK");

            entityBuilder.Property(t => t.UserId).IsRequired();

            entityBuilder.Property(t => t.SchoolId).IsRequired();

            entityBuilder.HasOne(t => t.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(t => t.UserId)
                .HasConstraintName("UserSchool_User_FK")
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasOne(t => t.School)
                .WithMany()
                .IsRequired()
                .HasForeignKey(t => t.SchoolId)
                .HasConstraintName("UserSchool_School_FK")
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasOne(t => t.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(t => t.UserId)
                .HasConstraintName("UserSchool_User_FK")
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasOne(t => t.School)
                .WithMany()
                .IsRequired()
                .HasForeignKey(t => t.SchoolId)
                .HasConstraintName("UserSchool_School_FK")
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}