using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models.BlogStyleReview;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Repositories
{
    public class LikeReviewRepository : ILikeReviewRepository
    {
        private readonly ReviewDbContext reviewDbContext;

        public LikeReviewRepository(ReviewDbContext reviewDbContext)
        {
            this.reviewDbContext = reviewDbContext;
        }

        public async Task<LikeReview> AddLikeToReview(LikeReview likeReview)
        {
            await reviewDbContext.LikeReview.AddAsync(likeReview);
            await reviewDbContext.SaveChangesAsync();
            return likeReview;
        }

        public async Task<IEnumerable<LikeReview>> GetLikesForReviewForUser(Guid ReviewId)
        {
            //throw new NotImplementedException();
            //search the like table for the the like that matches the reviewid
            return await reviewDbContext.LikeReview.Where(x => x.ReviewId == ReviewId).ToListAsync();
            
        }

        public async Task<int> GetTotalLikes(Guid reviewId)
        {
            return await reviewDbContext.LikeReview.CountAsync(x => x.ReviewId == reviewId);
        }
    }
}