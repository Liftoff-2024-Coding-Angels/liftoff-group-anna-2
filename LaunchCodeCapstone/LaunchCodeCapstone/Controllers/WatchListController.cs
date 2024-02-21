using Microsoft.AspNetCore.Mvc;
using LaunchCodeCapstone.Data;
using Microsoft.AspNetCore.Identity;
using LaunchCodeCapstone.Repositories;
using LaunchCodeCapstone.Models.WatchListViewModels;
using LaunchCodeCapstone.Models.WatchList;
using LaunchCodeCapstone.Models.ViewModels;
using LaunchCodeCapstone.Models;
using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;

namespace LaunchCodeCapstone.Controllers
{
    public class WatchListController : Controller
    {
        private readonly MovieDbContext movieDbContext;
        private readonly WatchListDbContext watchListDbContext;
        private readonly IWatchListRepository watchListRepository;
        private readonly UserManager<IdentityUser> userManager;

        private MovieDbContext context;

        public WatchListController(
            IWatchListRepository watchListRepository,
            UserManager<IdentityUser> userManager,
            MovieDbContext context)
        {
            this.watchListRepository = watchListRepository;
            this.userManager = userManager;
            this.movieDbContext = movieDbContext;
            this.watchListDbContext = watchListDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchAPI(string title)
        {
            if (string.IsNullOrEmpty(title))
            //validate searchTerm
            {
                TempData["Message"] = "Please provide Movie Title!";
                return View("Search");
            }
            else
            {
                //adding
                var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
                ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(title);

                //this is the code that's returning the list
                List<MovieInfo> movieList = new List<MovieInfo>();
                foreach (MovieInfo info in response.Results)
                {
                    movieList.Add(info);
                };
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
            return RedirectToAction("List"); 
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddToWatchListVM addToWatchListVM)
        {
            //adding
            var model = new WatchList
            {
                 MovieTitle = addToWatchListVM.MovieTitle,
                 UserId = userManager.GetUserId(User)
            };
            await watchListRepository.AddAsync(model);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var watchList = await watchListRepository.GetAllAsync();
            return View(watchList);

        }


        [HttpPost]
        public async Task<IActionResult> Delete(DeleteFromWatchListVM deleteFromWatchListVM)
        {

            //call the repository to delete the review
            var deletedWatchListItem = await watchListRepository.DeleteAsync(deleteFromWatchListVM.Id);

            if (deletedWatchListItem != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("List", new { Id = deleteFromWatchListVM.Id });


        }

    //[HttpPost]
    //public async Task<IActionResult> Delete(DeleteFromWatchList deleteFromWatchList)
    //{

    //    //call the repository to delete the review
    //    var deletedWatchListItem = await watchListRepository.DeleteAsync(deleteFromWatchList.Id);

    //    if (deletedWatchListItem != null)
    //    {
    //        return RedirectToAction("DisplayWatchList");
    //    }
    //    return RedirectToAction("DisplayWatchList", new { Id = deleteFromWatchList.Id });


    //    //Or 
    //    /*
    //     Create a form for submitting a POST request for delete action.

    //            <td>
    //                @using (Html.BeginForm("Delete", "Admin", new { id = row.Id }, FormMethod.Post))
    //                {
    //                    <button type="submit" data-bs-togle="modal" data-bs-target="#IdModal" class="btn btn-danger" data-toggle="tooltip" data-placement="right" title="Delete User" id="@row.Id">
    //                        <i class="fas fa-trash"></i>
    //                    </button>
    //                }
    //            </td>
    //            In AdminController, you need a Delete with [HttpPost] method to perform the delete operation and then return View.

    //            public class AdminController : BaseController
    //            {
    //                ...

    //                [HttpPost]
    //                public ActionResult Delete(int id)
    //                {
    //                    delete_by_id(id);

    //                    // Return desired view
    //                    return Index();
    //                }
    //            } 
    //     */

    //}

}
}
