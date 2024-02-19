using LaunchCodeCapstone.Models.BlogStyleReview;
namespace LaunchCodeCapstone.Repositories
{
    public interface IReviewRepository
    {

        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review?> GetAsync(Guid id);
        Task<Review> AddAsync(Review review);
        Task<Review?> UpdateAsync(Review review);
        Task<Review?> DeleteAsync(Guid id);
        Task<Review?> GetByUrlHandleAsync(string urlHandle);


    }
}