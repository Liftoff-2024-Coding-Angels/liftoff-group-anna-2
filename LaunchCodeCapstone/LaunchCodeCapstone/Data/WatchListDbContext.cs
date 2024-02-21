using LaunchCodeCapstone.Models.BlogStyleReview;
using LaunchCodeCapstone.Models.WatchList;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Data
{
    public class WatchListDbContext : DbContext
    {
        public WatchListDbContext(DbContextOptions<WatchListDbContext> options) : base(options)
        {

        }

        public DbSet<WatchList> WatchList { get; set; }

    }
}
