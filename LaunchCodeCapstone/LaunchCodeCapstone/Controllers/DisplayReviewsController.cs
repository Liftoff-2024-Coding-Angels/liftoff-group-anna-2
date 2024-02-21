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
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IReviewCommentsRepository reviewCommentsRepository;

        public DisplayReviewsController(IReviewRepository reviewRepository,
            ILikeReviewRepository likeReviewRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IReviewCommentsRepository reviewCommentsRepository
            )
        {
            this.reviewRepository = reviewRepository;
            this.likeReviewRepository = likeReviewRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.reviewCommentsRepository = reviewCommentsRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var liked = false;
            var review = await reviewRepository.GetByUrlHandleAsync(urlHandle);
            var reviewDetailsViewModel = new ReviewDetailsViewModel();

            //pull the likes
            if (review != null)
            {
                var totalLikes = await likeReviewRepository.GetTotalLikes(review.Id);
                //converting the viewmodel

                if (signInManager.IsSignedIn(User))
                {
                    //getting the likes for this review for this user
                    var likesForReview = await likeReviewRepository.GetLikesForReviewForUser(review.Id);
                    //check if the user has already like this particular review (check if their user id is in the above list)
                    var userId = userManager.GetUserId(User);
                    if (userId != null)
                    {
                        var likeFromUserId = likesForReview.FirstOrDefault(x => x.UserId == Guid.Parse(userId));
                        //if they liked, change liked boolean to true
                        liked = likeFromUserId != null;
                    }
                }


                //get comments for review
                var reviewCommentsModel = await reviewCommentsRepository.GetCommentsByReviewIdAsync(review.Id);

                var reviewCommentsForView = new List<Models.ViewModels.ReviewComments>();

                foreach (var reviewComments in reviewCommentsModel)
                {
                    //this needs reworking
                    reviewCommentsForView.Add(new Models.ViewModels.ReviewComments
                    {
                        Description = reviewComments.Description,
                        DateAdded = reviewComments.DateAdded,
                        Username = (await userManager.FindByIdAsync(reviewComments.UserId.ToString())).UserName
                    
                    });
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
                    TotalLikes = totalLikes,
                    Liked = liked,
                    Comments = reviewCommentsForView
                };
            }
            //passing the viewmodel to the view
            return View(reviewDetailsViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(ReviewDetailsViewModel reviewDetailsViewModel)
        {
            if (signInManager.IsSignedIn(User))
            {
                var reviewModel = new Models.BlogStyleReview.ReviewComments
                {
                    ReviewId = reviewDetailsViewModel.Id,
                    Description = reviewDetailsViewModel.Description,
                    //will want to reuse the below to assign author to user id maybe
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    DateAdded = DateTime.Now

                };
                await reviewCommentsRepository.AddAsync(reviewModel);
                //creating new object equal to the url handle and redirecting them back to it so that they can see the review with their comment posted
                return RedirectToAction("Index", "DisplayReviews", new { urlHandle = reviewDetailsViewModel.UrlHandle });
            }
            return View();
        }
    }
}