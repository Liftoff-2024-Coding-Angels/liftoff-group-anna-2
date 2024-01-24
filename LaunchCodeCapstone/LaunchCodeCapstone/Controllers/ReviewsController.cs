using Microsoft.AspNetCore.Mvc;

namespace LaunchCodeCapstone.Controllers
{
    public class ReviewsController :Controller
    {
        [HttpGet]
        public IActionResult AddReview()
        {
            return View();
        }
    }
}
