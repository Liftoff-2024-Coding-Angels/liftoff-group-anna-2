using Microsoft.AspNetCore.Identity;

namespace LaunchCodeCapstone.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
