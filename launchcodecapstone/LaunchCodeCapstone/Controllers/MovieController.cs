using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
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

        [HttpGet]

        public async Task<IActionResult> Results()
        {
            //Calling API
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync("Cinderella");

            //making each result an object to put it into display list
            //API info already an object
            List<MovieInfo> movieList = new List<MovieInfo>();
            foreach (MovieInfo info in response.Results)
            {
                movieList.Add(info);
                info.Title.ToList();
                info.Overview.ToList();

            };
                    /* context.Movies.Add(movie);
                     context.SaveChanges();
                    */
                    return View(response.Results);
        
            

        }



        public IActionResult Search()
        {
            return View();
        }

    }
}

        
/*public IActionResult AddMovie(response)
      {
          if (ModelState.IsValid)
            {
               List<Movie> movies = _db.Movies.ToList();
                _db.SaveChanges();
        
                return Redirect("/Movie/");
    }
          else
          {
              return View("/SearchBar/");
}

          return View("Index");
          }*/


