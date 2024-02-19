using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models.BlogStyleReview;

namespace LaunchCodeCapstone.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options)
        {

        }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<LikeReview> LikeReview { get; set; }

        public DbSet<ReviewComments> ReviewComments { get; set; }

    }
}
