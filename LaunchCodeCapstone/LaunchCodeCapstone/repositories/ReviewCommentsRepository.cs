using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models.BlogStyleReview;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Repositories
{
    public class ReviewCommentsRepository : IReviewCommentsRepository
    {
        private readonly ReviewDbContext reviewDbContext;

        public ReviewCommentsRepository(ReviewDbContext reviewDbContext)
        {
            this.reviewDbContext = reviewDbContext;
        }

        public async Task<ReviewComments> AddAsync(ReviewComments reviewComments)
        {
            await reviewDbContext.ReviewComments.AddAsync(reviewComments);
            await reviewDbContext.SaveChangesAsync();
            return reviewComments;
        }

        public async Task<IEnumerable<ReviewComments>> GetCommentsByReviewIdAsync(Guid reviewId)
        {
            //throw new NotImplementedException();
            return await reviewDbContext.ReviewComments.Where(x => x.ReviewId == reviewId).ToListAsync();
        }
    }
}