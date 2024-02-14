using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using Microsoft.AspNetCore.Mvc;

namespace LaunchCodeCapstone.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Results(string searchTerm)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(searchTerm);

            foreach (MovieInfo info in response.Results)
            {

                if (ModelState.IsValid)
                {
                    Models.Movie movie = new Models.Movie()
                    {
                        Title = info.Title,
                        Overview = info.Overview
                    };
                    /* context.Movies.Add(movie);
                     context.SaveChanges();
                    */
                    return View(Results);



                }
            }
            return View("Index");
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


