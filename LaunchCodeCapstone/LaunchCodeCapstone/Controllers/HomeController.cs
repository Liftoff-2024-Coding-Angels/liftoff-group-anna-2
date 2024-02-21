using LaunchCodeCapstone.Models;
using LaunchCodeCapstone.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaunchCodeCapstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReviewRepository reviewRepository;

        public HomeController(ILogger<HomeController> logger, IReviewRepository reviewRepository)
        {
            _logger = logger;
            this.reviewRepository = reviewRepository;
        }

        public async Task<IActionResult> Index()
        {
            //retrieve the blogs from the database
            var reviews = await reviewRepository.GetAllAsync();

            return View(reviews);

        }

        public IActionResult Review()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}