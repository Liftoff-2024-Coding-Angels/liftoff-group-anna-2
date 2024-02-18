using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Data 
{
    public class UserRolesDbContext : IdentityDbContext
    {
        public UserRolesDbContext(DbContextOptions<UserRolesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seeding the roles

            //created through view>other windows>C# interactive>Console.WriteLine(Guid.NewGuid())>store in variables
            var adminRoleId = "3d46d0ff-d3b5-4beb-a544-d7576643d717";
            var superAdminRoleId = "d980268f-7565-4941-a598-368ab2cea6cb";
            var userRoleId = "ecd445ad - 9d58 - 49ef - 908d - a05ad1e64fa2";

            var roles = new List<IdentityRole>{
                //admin
                new IdentityRole()
                {
                    Name = "Admin",
                    //"Normalization stops people registering user names which only differ in letter casing."
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId //a concurrency stamp prevents concurrent update conflict (two admins trying to update the same piece of data)
                },

                //super admin
                new IdentityRole()
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                 //user
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            //pass the parameters of the role to the has data method and when it runs itll insert the seeded roles into the database
            builder.Entity<IdentityRole>().HasData(roles);

            //var adminId = "7d949bee-2a90-4b79-a577-e23030b3d15d";
            var superAdminId = "408be4a1-f6ab-47e7-a035-4032256da7fa";
            //var userId = "2bf3dcd0-7f5d-4b23-ad6a-033f618aba9c";

            var superAdminUser = new IdentityUser
            {
                UserName = "superAdmin",
                Email = "mendozacolonx@gmail.com",
                NormalizedEmail = "superAdmin".ToUpper(),
                NormalizedUserName = "mendozacolonx@gmail.com".ToUpper(),
                Id = superAdminId
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "SuperAdmin1!");

            builder.Entity<IdentityUser>().HasData(superAdminUser);
            //giving super admin access toall the roles of the other user types
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                },
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }
    }
}
