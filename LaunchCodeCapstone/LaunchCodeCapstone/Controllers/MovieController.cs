using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net.Http.Headers;
using RestSharp;
using static Microsoft.ClearScript.V8.V8CpuProfile;
using System.Runtime.Intrinsics.X86;
using LaunchCodeCapstone.Models.WatchList;
using LaunchCodeCapstone.Models.BlogStyleReview;
using LaunchCodeCapstone.Repositories;
using Microsoft.AspNetCore.Identity;
using SendGrid;
using LaunchCodeCapstone.Models.WatchListViewModels;
using CloudinaryDotNet.Actions;
using LaunchCodeCapstone.Models.WatchListViewModels;
using LaunchCodeCapstone.Models.WatchList;
namespace LaunchCodeCapstone.Controllers
{
    public class MovieController : Controller
    {
        private MovieDbContext context;
        private readonly WatchListDbContext watchListDbContext;
        private readonly IWatchListRepository watchListRepository;
        private readonly UserManager<IdentityUser> userManager;

        public MovieController(MovieDbContext dbContext,
            IWatchListRepository watchListRepository,
            UserManager<IdentityUser> userManager)
        {
            context = dbContext;
            this.watchListRepository = watchListRepository;
            this.userManager = userManager;
            this.watchListDbContext = watchListDbContext;

        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult RandomMovie(MovieWatchList.id)
        //{
        //    var random = new Random();
        //    //List of movie Ids from movies added to watchList
        //    // List<int> movies.Id = new List<int>();
        //    //Console.WriteLine($"Random integer: {RandMovie}");
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public async Task<IActionResult> Results(string title)
        //input parameter for Title of movie

        {

            //search Term to go to API 

            if (string.IsNullOrEmpty(title))
            //validate searchTerm
            {
                TempData["Message"] = "Please provide Movie Title!";
                //if no term, message will print
                return View("Search");
                //return to Search Bar if no term present
            }
            else
            {

                //Calling API
                var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

                ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(title);


                //API info already an object


                List<MovieInfo> movieList = new List<MovieInfo>();
                //Creating List for Movie objects to go into from call to API
                foreach (MovieInfo info in response.Results)
                {
                    movieList.Add(info);

                    //Don't need extra code if
                    //defined in view?
                    //info.Title.ToList();
                    //info.Overview.ToList();

                };

                /* context.Movies.Add(movie);
                 context.SaveChanges();
                */
                //call List into View
                return View(movieList);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBySearch(AddToWatchListVM addToWatchListVM)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync((addToWatchListVM.MovieTitle).ToString());

            List<MovieInfo> movieList = new List<MovieInfo>();

            var model = new WatchList
            {
                MovieTitle = addToWatchListVM.MovieTitle,
                UserId = userManager.GetUserId(User)
            };
            await watchListRepository.AddAsync(model);
            return RedirectToAction("WatchList/List");

            //return View("WatchList/List");
        }


        public async Task<IActionResult> WatchProviderAsync(int movieId)
        {
            if (movieId.Equals(null))
            {
                return View("");
            }
            else
            {

                var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/{movieId}/watch/providers");

                var client = new RestClient(options);

                var request = new RestRequest("");

                //Do i need if I have in Program file?
                request.AddHeader("accept", "application/json");
                request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjkyOWMxY2Q5MTgzOWNkYWU5MzZhNjEzMmNmNGUyNyIsInN1YiI6IjY1YWMwMjliYWQ1OWI1MDBlYjc4NTFkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.TKw26QnxggH6qX2MFMraVlrRetVSCODmGMBX_L6WTJw");

                var response = await client.GetAsync(request);


                return View("WatchProvider", response.Content);

                //    List<RestClientOptions> ProviderInfo = new List<RestClientOptions>();
                //    var response = await client.GetAsync(request);
                //    foreach (RestClientOptions WatchListP in response.Content)
                //    {
                //        ProviderInfo.Add(WatchListP);

                //        //Don't need extra code if
                //        //defined in view?
                //        //info.Title.ToList();
                //        //info.Overview.ToList();

                //    };

                //    return View("WatchProvider", response.Content);

                //    //return View("{0}", response.Content);
                //}

            }

            //[HttpPost]
            //public IActionResult Search(string searchTerm)
            //{
            //    //search Term to go to API 
            //    //parameter in search view? 
            //    if (searchTerm == null)
            //    {

            //    }
            //    return View();
            //}

            //public async Task<IActionResult> WheretowatchAsync()
            //     {
            //         var client = new HttpClient();
            //         var request = new HttpRequestMessage

            //         {
            //             Method = HttpMethod.Get,
            //             //Uses Movie Id to search watch provider
            //             RequestUri = new Uri("https://api.themoviedb.org/3/movie/${}/watch/providers")
            //             //            Headers =
            //             //{
            //             //    { "accept", "application/json" },
            //             //    { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjkyOWMxY2Q5MTgzOWNkYWU5MzZhNjEzMmNmNGUyNyIsInN1YiI6IjY1YWMwMjliYWQ1OWI1MDBlYjc4NTFkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.TKw26QnxggH6qX2MFMraVlrRetVSCODmGMBX_L6WTJw" },
            //             //},
            //         };
            //         using (var response = await client.SendAsync(request))
            //         {
            //             response.EnsureSuccessStatusCode();
            //             var body = await response.Content.ReadAsStringAsync();
            //             Console.WriteLine(body);

            //         }
            //         return View();

            //     }
        }

        [HttpGet]
        public IActionResult Search()
        {
            //TempData[search] = searchTerm;
                        return View();
        }


        //[HttpPost]
        //[ActionName("AddToWatchList")]
        //public async Task<IActionResult> AddToWatchList(AddToWatchList addToWatchList)
        //{
        //    var movie = await WatchListRepository.GetAsync();
        //    List<WatchList> wlList = new List<WatchList>();
        //    foreach (var item in wlList)
        //    {
        //        Id = addToWatchList.Id,
        //        Title = addToWatchList.Title,
        //        Overview = addToWatchList.Overview
        //    };

        //    return View(wlList);
        //}
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


