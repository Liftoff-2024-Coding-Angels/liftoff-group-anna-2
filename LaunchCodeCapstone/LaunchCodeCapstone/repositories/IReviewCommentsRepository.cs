using LaunchCodeCapstone.Models.BlogStyleReview;
namespace LaunchCodeCapstone.Repositories
{
    public interface IReviewCommentsRepository
    {

        Task<ReviewComments> AddAsync(ReviewComments reviewComments);
        Task<IEnumerable<ReviewComments>> GetCommentsByReviewIdAsync(Guid reviewId);

    }
}