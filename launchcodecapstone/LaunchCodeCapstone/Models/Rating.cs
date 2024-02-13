namespace LaunchCodeCapstone.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int StarRating { get; set; }


        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }
        public int MovieId { get; set; }
        public Rating()
        {
        }
    }
}
