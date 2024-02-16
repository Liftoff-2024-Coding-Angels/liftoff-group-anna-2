using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


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

        public async Task<IActionResult> Results(string searchTerm)
        {
            //Calling API
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(searchTerm);

            //making each result an object to put it into display list
            //API info already an object

            List<MovieInfo> movieList = new List<MovieInfo>();
           //Creating List for Movie objects to go into from call to API
                foreach (MovieInfo info in response.Results)
                {
                    movieList.Add(info);

                    //Dont need extra code if defined in view?
                    //info.Title.ToList();
                    //info.Overview.ToList();

                };
               
            
            /* context.Movies.Add(movie);
             context.SaveChanges();
            */
            return View(movieList);
            //call List into View



        }


        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
       

       /* [HttpPost]
        public IActionResult Search()
        {
            //TempData[search] = searchTerm;

            return View();

        }
       */
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


