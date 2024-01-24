using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models.BlogStyleReview;
using LaunchCodeCapstone.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LaunchCodeCapstone.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ReviewDbContext reviewDbContext;
        public ReviewsController(ReviewDbContext reviewDbContext)
        {
            this.reviewDbContext = reviewDbContext;
        }


        [HttpGet]
        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        //        [ActionName("AddTag")]
        public IActionResult AddReview(AddReviewRequest addReviewRequest)
        {
            var review = new Review
            {
                Heading = addReviewRequest.Heading,
                Title = addReviewRequest.Title,
                Content = addReviewRequest.Content,
                Description = addReviewRequest.Description,
                FeaturedImageUrl = addReviewRequest.FeaturedImageUrl,
                UrlHandle = addReviewRequest.UrlHandle,
                PublishedDate = addReviewRequest.PublishedDate,
                Author = addReviewRequest.Author,
                Visible = addReviewRequest.Visible

    };

            reviewDbContext.Reviews.Add(review);
            reviewDbContext.SaveChanges();
            return View("AddReview");
        }
    }
}