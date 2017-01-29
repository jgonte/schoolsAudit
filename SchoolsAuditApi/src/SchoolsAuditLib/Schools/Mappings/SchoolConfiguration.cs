using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolsAuditDomainModel.Schools.Persistence
{
    public static class SchoolConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<School>();

            entityBuilder.ToTable("School", schema: "Schools");

            entityBuilder.HasKey(t => t.Id).HasName("School_PK");

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("SchoolId");

            entityBuilder.Property(t => t.Type).IsRequired(false);

            entityBuilder.Property(t => t.Level).IsRequired(false);

            entityBuilder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

    }
}