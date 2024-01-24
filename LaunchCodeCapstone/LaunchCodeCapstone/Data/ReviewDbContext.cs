using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models.BlogStyleReview;

namespace LaunchCodeCapstone.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }
}
