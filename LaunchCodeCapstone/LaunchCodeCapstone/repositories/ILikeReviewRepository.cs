using LaunchCodeCapstone.Models.BlogStyleReview;

namespace LaunchCodeCapstone.Repositories
{
    public interface ILikeReviewRepository
    {
        Task<int> GetTotalLikes(Guid ReviewId);
        Task<LikeReview> AddLikeToReview(LikeReview likeReview);
    }
}