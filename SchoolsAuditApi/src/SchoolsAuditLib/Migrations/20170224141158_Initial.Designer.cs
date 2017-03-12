using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolsAuditDomainModel.Persistence;

namespace SchoolsAuditLib.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170224141158_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Role","Membership");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim","Membership");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("User","Membership");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim","Membership");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin","Membership");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole","Membership");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.UserToken", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken","Membership");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Schools.Document", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DocumentId");

                    b.Property<byte[]>("FileContent");

                    b.Property<string>("FileName");

                    b.Property<long?>("FileSize");

                    b.Property<string>("FileType");

                    b.Property<string>("Label")
                        .HasMaxLength(255);

                    b.Property<int?>("UserId");

                    b.HasKey("Id")
                        .HasName("Document_PK");

                    b.HasIndex("UserId");

                    b.ToTable("Document","Schools");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Schools.School", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SchoolId");

                    b.Property<int?>("Level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("Type");

                    b.HasKey("Id")
                        .HasName("School_PK");

                    b.ToTable("School","Schools");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Schools.UserSchool", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("SchoolId");

                    b.HasKey("UserId", "SchoolId")
                        .HasName("UserSchool_PK");

                    b.HasIndex("SchoolId");

                    b.ToTable("UserSchool","Schools");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.RoleClaim", b =>
                {
                    b.HasOne("SchoolsAuditDomainModel.Membership.Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.UserClaim", b =>
                {
                    b.HasOne("SchoolsAuditDomainModel.Membership.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.UserLogin", b =>
                {
                    b.HasOne("SchoolsAuditDomainModel.Membership.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Membership.UserRole", b =>
                {
                    b.HasOne("SchoolsAuditDomainModel.Membership.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolsAuditDomainModel.Membership.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Schools.Document", b =>
                {
                    b.HasOne("SchoolsAuditDomainModel.Membership.User")
                        .WithMany("Documents")
                        .HasForeignKey("UserId")
                        .HasConstraintName("User_Documents_FK");
                });

            modelBuilder.Entity("SchoolsAuditDomainModel.Schools.UserSchool", b =>
                {
                    b.HasOne("SchoolsAuditDomainModel.Schools.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .HasConstraintName("UserSchool_School_FK");

                    b.HasOne("SchoolsAuditDomainModel.Membership.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("UserSchool_User_FK");
                });
        }
    }
}
