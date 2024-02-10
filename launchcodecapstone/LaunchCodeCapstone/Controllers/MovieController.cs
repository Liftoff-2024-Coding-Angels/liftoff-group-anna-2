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
            return View();
        }

        public IActionResult SearchBar()

        {
            List<Movie> movies = context.Movies.ToList();

            return View(movies);
        }
    }
}
