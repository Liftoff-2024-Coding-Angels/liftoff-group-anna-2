using System;
namespace LaunchCodeCapstone.Models
{
	public class Rating
	{

		public int RatingId { get; set; }
		public int NumStars { get; set; }

		public MovieEntry? MovieEntry { get; set; }
		public int MovieEntryId { get; set; }

        public Rating(int numStars, int movieEntryId)
        {
            NumStars = numStars;
            MovieEntryId = movieEntryId;
        }

        public Rating()
		{
		}
	}
}
