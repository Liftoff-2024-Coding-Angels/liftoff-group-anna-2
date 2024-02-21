using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models.BlogStyleReview;
using LaunchCodeCapstone.Models.ViewModels;
using LaunchCodeCapstone.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;



namespace LaunchCodeCapstone.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ReviewDbContext reviewDbContext;
        private readonly IReviewRepository reviewRepository;
        private readonly UserManager<IdentityUser> userManager;


        public ReviewsController(IReviewRepository reviewRepository,
                        UserManager<IdentityUser> userManager)//ReviewDbContext reviewDbContext)
        {
            //this.reviewDbContext = reviewDbContext;
            this.reviewRepository = reviewRepository;
            this.userManager = userManager;


        }

        //[Authorize]
        [HttpGet]
        [ActionName("AddReview")]

        public async Task<IActionResult> AddReview()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewRequest addReviewRequest)
        {
            //mapping the view model and review model together
            var review = new Review
            {
                Heading = addReviewRequest.Heading,
                Title = addReviewRequest.Title,
                Content = addReviewRequest.Content,
                Description = addReviewRequest.Description,
                FeaturedImageUrl = addReviewRequest.FeaturedImageUrl,
                UrlHandle = addReviewRequest.UrlHandle,
                PublishedDate = addReviewRequest.PublishedDate,
                Author = userManager.GetUserName(User),
                Visible = addReviewRequest.Visible
            };

            //await reviewDbContext.Reviews.AddAsync(review);
            //await reviewDbContext.SaveChangesAsync();
            await reviewRepository.AddAsync(review);
            return RedirectToAction("AddReview");
        }

        //READ functionality
        [HttpGet]
        [ActionName("ReviewsList")]
        public async Task<IActionResult> ReviewsList()
        {
            //call the repository to get the data from the database
            var reviews = await reviewRepository.GetAllAsync();//reviewDbContext.Reviews.ToListAsync(); //.ToList();

            return View(reviews);

        }

       // [Authorize(Roles = "Admin")]
        [HttpGet]
        [ActionName("EditReview")]
        //id in param so that it edits the correct one
        public async Task<IActionResult> EditReview(Guid id)
        {
            //you can use the find method or the first or default, or single or default
            //var tag = reviewDbContext.Tags.Find(id);
            var review = await reviewRepository.GetAsync(id); //reviewDbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id); //.FirstOrDefault(x => x.Id == id);

            if (review != null)
            {
                var editReviewRequest = new EditReviewRequest
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
                    Visible = review.Visible
                };
                return View(editReviewRequest);
            }
            return View(null);

        }

        [HttpPost]
        public async Task<IActionResult> EditReview(EditReviewRequest editReviewRequest)
        {
            var review = new Review
            {
                Id = editReviewRequest.Id,
                Heading = editReviewRequest.Heading,
                Title = editReviewRequest.Title,
                Content = editReviewRequest.Content,
                Description = editReviewRequest.Description,
                FeaturedImageUrl = editReviewRequest.FeaturedImageUrl,
                UrlHandle = editReviewRequest.UrlHandle,
                PublishedDate = editReviewRequest.PublishedDate,
                Author =  editReviewRequest.Author,
                Visible = editReviewRequest.Visible
            };
            //submitting the info to the repo to update
            var updatedReview = await reviewRepository.UpdateAsync(review);

            if (updatedReview != null)
            {
                return RedirectToAction("ReviewsList", new { id = editReviewRequest.Id });
            }

            //var existingReview = await reviewDbContext.Reviews.FindAsync(review.Id); //.Find(tag.Id);

            //if (existingReview != null)
            //{
            //    existingReview.Heading = review.Heading;
            //    existingReview.Title = review.Title;
            //    existingReview.Content = review.Content;
            //    existingReview.Description = review.Description;
            //    existingReview.FeaturedImageUrl = review.FeaturedImageUrl;
            //    existingReview.UrlHandle = review.UrlHandle;
            //    existingReview.PublishedDate = review.PublishedDate;
            //    existingReview.Author = review.Author;
            //    existingReview.Visible = review.Visible;

            //    //save changes
            //    await reviewDbContext.SaveChangesAsync(); //.SaveChanges();

            //    //sending it back to edit page and giving it the parameter
            //    return RedirectToAction("ReviewsList", new { id = editReviewRequest.Id });
            //}
            return RedirectToAction("ReviewsList", new { id = editReviewRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(EditReviewRequest editReviewRequest)
        {

            //call the repository to delete the review
            var deletedReview = await reviewRepository.DeleteAsync(editReviewRequest.Id);

            if (deletedReview != null)
            {
                return RedirectToAction("ReviewsList");
            }
            //var deleteReview = await reviewDbContext.Reviews.FindAsync(editReviewRequest.Id); //.Find(editTagRequest.Id);

            //if (deleteReview != null)
            //{
            //    reviewDbContext.Reviews.Remove(deleteReview);
            //    await reviewDbContext.SaveChangesAsync(); //.SaveChanges();

            //    return RedirectToAction("ReviewsList");
            //}

            //return the result back to the edit page according to the id
            return RedirectToAction("EditReview", new { Id = editReviewRequest.Id });
        }

    }
}