using Microsoft.AspNetCore.Identity;
using SchoolsAuditDomainModel.Membership.Stores;
using SchoolsAuditDomainModel.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsAuditDomainModel.Membership
{
    public static class UserSeeder
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            var context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));

            var roleManager = (RoleManager<Role>)serviceProvider.GetService(typeof(RoleManager<Role>));

            var roleNames = new []{
                "Administrator",
                "Auditor"
            };

            foreach (var roleName in roleNames)
            {
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    await roleManager.CreateAsync(new Role(roleName));
                }
            }

            var userManager = (UserManager<User>)serviceProvider.GetService(typeof(UserManager<User>));

            var userStore = new MembershipUserStore(context);

            var passwordHasher = new PasswordHasher<User>();

            var admin = new User
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@myorg.com",
                NormalizedEmail = "ADMIN@MYORG.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == admin.UserName))
            {
                admin.PasswordHash = passwordHasher.HashPassword(admin, "secret");

                await userStore.CreateAsync(admin);
            }

            admin = await userManager.FindByEmailAsync(admin.Email);

            await userManager.AddToRolesAsync(admin, new []{
                "Administrator"
            });
        }

    }
}