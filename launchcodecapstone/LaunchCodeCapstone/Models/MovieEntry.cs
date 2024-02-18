using System;
using System.ComponentModel.DataAnnotations;

namespace LaunchCodeCapstone.Models
{
	public class MovieEntry
	{
		[Key]
		public int MovieEntryId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; } //personally set date format of MM / DD / YYYY

        public int NumRating { get; set; }
        //public ICollection<Rating> Ratings { get; set; }


        public MovieEntry(int movieEntryId, string title, DateTime date, int numRating)
		{
			MovieEntryId = movieEntryId;
			Title = title;
			Date = date;
			NumRating = numRating;
            //Ratings = new List<Rating>();F

        }

		public MovieEntry()
		{

		}
	}
}

