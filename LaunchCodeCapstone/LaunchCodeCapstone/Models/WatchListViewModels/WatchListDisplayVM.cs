namespace LaunchCodeCapstone.Models.WatchListViewModels
{
    public class WatchListDisplayVM
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string MovieTitle { get; set; }
        public IEnumerable<AddToWatchListVM> WatchList { get; set; }


    }
}
