using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models.BlogStyleReview;
using LaunchCodeCapstone.Models.WatchList;
using LaunchCodeCapstone.Models.WatchListViewModels;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {
        private readonly WatchListDbContext watchListDbContext;


        public WatchListRepository(WatchListDbContext watchListDbContext)
        {
            this.watchListDbContext = watchListDbContext;
        }

        public async Task<WatchList?> AddAsync(WatchList watchList)
        {
            // throw new NotImplementedException();
            await watchListDbContext.AddAsync(watchList);
            await watchListDbContext.SaveChangesAsync();
            return watchList;
        }
        
        public async Task<WatchList?> DeleteAsync(Guid id)
        {
            //throw new NotImplementedException();
            var existingWatchListItem = await watchListDbContext.WatchList.FindAsync(id);
            if (existingWatchListItem != null)
            {
                watchListDbContext.WatchList.Remove(existingWatchListItem);
                await watchListDbContext.SaveChangesAsync();
                return existingWatchListItem;
            }
            return null;
        }

        public async Task<IEnumerable<WatchList>> GetAllAsync()
        {
               return await watchListDbContext.WatchList.ToListAsync();

            //throw new NotImplementedException();
        }

        public async Task<WatchList?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<WatchList?> UpdateAsync(WatchList watchList)
        {
            throw new NotImplementedException();
        }
    }
}
