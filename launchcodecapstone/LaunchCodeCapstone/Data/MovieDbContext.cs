using LaunchCodeCapstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Data
{
    public class MovieDbContext : IdentityDbContext
    {

        public DbSet<Movie>? Movies { get; set; }
        //need to connect to Hailey's to see all classes/tables
        public DbSet<Users>? User {  get; set; }
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }
       public MovieDbContext()
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Movie>()
                .HasMany(a => a.User)
                .WithMany(b => b.Rating)
        }

    }
}