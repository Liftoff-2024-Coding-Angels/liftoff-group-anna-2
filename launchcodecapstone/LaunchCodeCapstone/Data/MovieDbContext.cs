using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models;

namespace LaunchCodeCapstone.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) 
        { 
        }

        public DbSet<MovieEntry> MovieEntries { get; set; }

        public DbSet<MovieData> Movies { get; set; }
    }
}
