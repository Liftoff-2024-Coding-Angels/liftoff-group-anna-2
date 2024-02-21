
namespace LaunchCodeCapstone.Models.WatchList
{
    public class WatchList
    {
        public Guid Id { get; set; }
        public string UserId { get; set;}
        public string MovieTitle { get; set; }

        public class wlList
        {
            public List<WatchList> WatchList { get; set; }

        }
    }
}
