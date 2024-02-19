using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models.BlogStyleReview;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ReviewDbContext reviewDbContext;

        public ReviewRepository(ReviewDbContext reviewDbContext)
        {
            this.reviewDbContext = reviewDbContext;
        }
        public async Task<Review> AddAsync(Review review)
        {
            await reviewDbContext.AddAsync(review);
            await reviewDbContext.SaveChangesAsync();
            return review;
            //            throw new NotImplementedException();
        }

        public async Task<Review?> DeleteAsync(Guid id)
        {
            //throw new NotImplementedException();
            var existingReview = await reviewDbContext.Reviews.FindAsync(id);
            if (existingReview != null)
            {
                reviewDbContext.Reviews.Remove(existingReview);
                await reviewDbContext.SaveChangesAsync();
                return existingReview;
            }
            return null;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            //throw new NotImplementedException();
            //getting the records back from the table
            return await reviewDbContext.Reviews.ToListAsync();
        }

        public async Task<Review?> GetAsync(Guid id)
        {
            // throw new NotImplementedException();
            return await reviewDbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Review?> GetByUrlHandleAsync(string urlHandle)
        {
            //throw new NotImplementedException();
            return await reviewDbContext.Reviews.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<Review?> UpdateAsync(Review review)
        {
            //throw new NotImplementedException();
            var existingReview = await reviewDbContext.Reviews.FirstOrDefaultAsync(x => x.Id == review.Id);
            if (existingReview != null)
            {
                existingReview.Heading = review.Heading;
                existingReview.Title = review.Title;
                existingReview.Content = review.Content;
                existingReview.Description = review.Description;
                existingReview.FeaturedImageUrl = review.FeaturedImageUrl;
                existingReview.UrlHandle = review.UrlHandle;
                existingReview.PublishedDate = review.PublishedDate;
                existingReview.Author = review.Author;
                existingReview.Visible = review.Visible;

                await reviewDbContext.SaveChangesAsync();
            }
            return null;
        }
    }
}