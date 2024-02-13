using LaunchCodeCapstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Data
{
    public class MovieDbContext : IdentityDbContext
    {

       public DbSet<Movie> Movies { get; set; }
             
        //need to connect to Hailey's to see all classes/tables
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }
       
        public MovieDbContext() 
        {
        }

        
                
        }
}