using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using Microsoft.AspNetCore.Mvc;

namespace LaunchCodeCapstone.Controllers
{
    public class MovieController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Results()
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync("Cinderella");

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
            return View("Search");
        }
        /*
       
        /*public async Task<IActionResult> Results(string search)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(search);

            foreach (MovieInfo info in response.Results)
            {
                return View("APIdisplay", info);
            }
            return View("Search");
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


