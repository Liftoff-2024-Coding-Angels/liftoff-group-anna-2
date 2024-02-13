using LaunchCodeCapstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Data
{
    public class MovieDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        //need to connect to Hailey's to see all classes/tables
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public MovieDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Movie>()
                 .HasOne(p => p.Ratings)
                .WithMany(b => b.Movies);


            


        }
    }
}