using LaunchCodeCapstone.Data;
using Microsoft.AspNetCore.Mvc;
using LaunchCodeCapstone.Models;

namespace LaunchCodeCapstone.Controllers
{
    public class MovieController : Controller
    {
        private MovieDbContext _db;
        public MovieController(MovieDbContext dbcontext)
        {
            _db = dbcontext;
        }

        //GET: /Movie
        public ActionResult Index() 
        {

            return View();
        }

        //Get: /Movie/SearchBar
           public IActionResult SearchBar() {
          
            List<Movie> movies = _db.Movies.ToList();

            return View(movies);
        }
    }
}
