namespace LaunchCodeCapstone.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public string Overview { get; internal set; }

        public Rating Ratings { get; set; }
    }
}
