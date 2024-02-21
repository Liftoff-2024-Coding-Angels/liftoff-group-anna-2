using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaunchCodeCapstone.Models.ViewModels;
using LaunchCodeCapstone.Repositories;
using LaunchCodeCapstone.Models.BlogStyleReview;

namespace LaunchCodeCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeReviewController : ControllerBase
    {
        private readonly ILikeReviewRepository likeReviewRepository;

        public LikeReviewController(ILikeReviewRepository likeReviewRepository)
        {
            this.likeReviewRepository = likeReviewRepository;
        }

        //this is triggered from javaascript body

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
        {
            var model = new LikeReview
            {
                ReviewId = addLikeRequest.ReviewId,
                UserId = addLikeRequest.UserId
            };
            await likeReviewRepository.AddLikeToReview(model);
            //return success response
            return Ok();
        }


        [HttpGet]
        [Route("{reviewId:Guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikes([FromRoute] Guid reviewId)
        {
            var totalLikes = await likeReviewRepository.GetTotalLikes(reviewId);

            return Ok(totalLikes);
        }
    }
}