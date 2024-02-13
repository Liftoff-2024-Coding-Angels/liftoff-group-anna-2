using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using DM.MovieApi;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models;
using Microsoft.AspNetCore.Mvc;


namespace LaunchCodeCapstone.Controllers
{
    public class MovieController : Controller
    {
        private MovieDbContext context;

        public MovieController(MovieDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Models.Movie> movie = context.Movies.ToList();
            return View(movie);
        }

         
        public IActionResult Search()
        {
          
            return View();
            
        }

        
        
    }
}
