using Microsoft.AspNetCore.Mvc;
using LaunchCodeCapstone.Repositories;
using LaunchCodeCapstone.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using LaunchCodeCapstone.Models.BlogStyleReview;

namespace LaunchCodeCapstone.Controllers
{
    public class DisplayReviewsController : Controller
    {
        private readonly IReviewRepository reviewRepository;
        private readonly ILikeReviewRepository likeReviewRepository;
        private readonly IReviewCommentsRepository reviewCommentsRepository;

        public DisplayReviewsController(IReviewRepository reviewRepository,
            ILikeReviewRepository likeReviewRepository,
            IReviewCommentsRepository reviewCommentsRepository
            )
        {
            this.reviewRepository = reviewRepository;
            this.likeReviewRepository = likeReviewRepository;
            this.reviewCommentsRepository = reviewCommentsRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var review = await reviewRepository.GetByUrlHandleAsync(urlHandle);
            var reviewDetailsViewModel = new ReviewDetailsViewModel();

            //pull the likes
            if (review != null)
            {
                var totalLikes = await likeReviewRepository.GetTotalLikes(review.Id);
                //converting the viewmodel

                //if (SignInManager.IsSignedIn(User))
                //{
                //    var reviewLikes = await likeReviewRepository.GetTotalLikes(review.Id);
                //    var userId = UserManager.GetUserId(User);
                //    if(userId != null)
                //    {
                //        var userLikes = reviewLikes.FirstOrDefault(x => x.UserId == Guid.Parse(userId));
                //        liked = userLikes != null;
                //    }
                //}


                //get comments for review
                var reviewCommentsModel = await reviewCommentsRepository.GetCommentsByReviewIdAsync(review.Id);

                var reviewCommentsForView = new List<Models.BlogStyleReview.ReviewComments>();

                foreach (var reviewComment in reviewCommentsModel)
                {
                    //this needs reworking
                    //reviewCommentsForView.Add(new reviewComments)
                    //    {
                    //    Description = ReviewComments.Description,
                    //        DateAdded = reviewComment.DateAdded,
                    //        Username = await.userManager.FindByIdAsync(reviewComment.UserId.ToString())).UserName
                    //};
                }
                reviewDetailsViewModel = new ReviewDetailsViewModel
                {
                    Id = review.Id,
                    Heading = review.Heading,
                    Title = review.Title,
                    Content = review.Content,
                    Description = review.Description,
                    FeaturedImageUrl = review.FeaturedImageUrl,
                    UrlHandle = review.UrlHandle,
                    PublishedDate = review.PublishedDate,
                    Author = review.Author,
                    Visible = review.Visible,
                    TotalLikes = totalLikes
                    //this needs reworking
                    //,
                    //Liked = liked,
                    //Comments = reviewCommentsForView
                };
            }
            //passing the viewmodel to the view
            return View(reviewDetailsViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(ReviewDetailsViewModel reviewDetailsViewModel)
        {
            ///TODO
            //if (SignInManager.IsSignedIn(User))
            //{
            var Model = new Models.BlogStyleReview.ReviewComments
            {
                ReviewId = reviewDetailsViewModel.Id,
                Description = reviewDetailsViewModel.Description,
                //UserId = Guid.Parse(userManager.GetUserId(User)),
                DateAdded = DateTime.Now

            };
            await reviewCommentsRepository.AddAsync(Model);
            return RedirectToAction("Index", "Reviews", new { urlHandle = reviewDetailsViewModel.UrlHandle });
            //}
            //return View();
        }
    }
}