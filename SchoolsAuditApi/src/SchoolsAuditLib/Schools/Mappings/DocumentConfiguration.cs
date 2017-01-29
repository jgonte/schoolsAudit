using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolsAuditDomainModel.Schools.Persistence
{
    public static class DocumentConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Document>();

            entityBuilder.ToTable("Document", schema: "Schools");

            entityBuilder.HasKey(t => t.Id).HasName("Document_PK");

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("DocumentId");

            entityBuilder.Property(t => t.Label)
                .IsRequired(false)
                .HasMaxLength(255);

            entityBuilder.Property(t => t.UserId).IsRequired(false);
        }

    }
}