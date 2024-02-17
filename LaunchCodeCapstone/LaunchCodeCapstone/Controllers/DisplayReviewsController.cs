using Microsoft.AspNetCore.Mvc;
using LaunchCodeCapstone.Repositories;
namespace LaunchCodeCapstone.Controllers
{
    public class DisplayReviewsController : Controller
    {
        private readonly IReviewRepository reviewRepository;

        public DisplayReviewsController(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }


        [HttpGet]
        public async Task< IActionResult> Index(string urlHandle)
        {
            var review = await reviewRepository.GetByUrlHandleAsync(urlHandle);

            return View(review);
        }
    }
}
