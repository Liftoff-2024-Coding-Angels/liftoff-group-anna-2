using LaunchCodeCapstone.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            //throw new NotImplementedException();

            var users = await applicationDbContext.Users.ToListAsync();
            //we dont want the super admin to show up in the admin's user list, so we'll search for the seeded email and then exclude them
            var superAdminUser = await applicationDbContext.Users.FirstOrDefaultAsync(x => x.Email == "mendozacolonx@gmail.com");
            if(superAdminUser != null)
            {
                users.Remove(superAdminUser);
            }
            return users;
        }
    }
}
