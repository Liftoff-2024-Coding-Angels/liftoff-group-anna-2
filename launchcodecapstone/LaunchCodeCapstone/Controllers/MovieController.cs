using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net.Http.Headers;


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

        /*using RestSharp;


var options = new RestClientOptions("https://api.themoviedb.org/3/movie/638/watch/providers");
var client = new RestClient(options);
var request = new RestRequest("");
request.AddHeader("accept", "application/json");
request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjkyOWMxY2Q5MTgzOWNkYWU5MzZhNjEzMmNmNGUyNyIsInN1YiI6IjY1YWMwMjliYWQ1OWI1MDBlYjc4NTFkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.TKw26QnxggH6qX2MFMraVlrRetVSCODmGMBX_L6WTJw");
var response = await client.GetAsync(request);

Console.WriteLine("{0}", response.Content);
*/
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> WheretowatchAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                //Uses Movie Id to search watch provider
                RequestUri = new Uri("https://api.themoviedb.org/3/movie/${}/watch/providers")
    //            Headers =
    //{
    //    { "accept", "application/json" },
    //    { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjkyOWMxY2Q5MTgzOWNkYWU5MzZhNjEzMmNmNGUyNyIsInN1YiI6IjY1YWMwMjliYWQ1OWI1MDBlYjc4NTFkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.TKw26QnxggH6qX2MFMraVlrRetVSCODmGMBX_L6WTJw" },
    //},
          };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

            }
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


