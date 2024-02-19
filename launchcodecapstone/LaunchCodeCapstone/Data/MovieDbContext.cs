using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models;

namespace LaunchCodeCapstone.Data
{
    public class MovieDbContext : IdentityDbContext, DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        //need to connect to Hailey's to see all classes/tables
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<MovieEntry> MovieEntries { get; set; }


    }
}
