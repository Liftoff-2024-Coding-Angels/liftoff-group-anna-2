using LaunchCodeCapstone.Models.WatchList;
using LaunchCodeCapstone.Models.WatchListViewModels;

namespace LaunchCodeCapstone.Repositories
{
    public interface IWatchListRepository
    {
        Task<IEnumerable<WatchList>> GetAllAsync();
        Task<WatchList?> GetAsync(Guid id);
        Task<WatchList?> AddAsync(WatchList watchList);
        Task<WatchList?> UpdateAsync(WatchList watchList);
        Task<WatchList?> DeleteAsync(Guid id);

    }
}
