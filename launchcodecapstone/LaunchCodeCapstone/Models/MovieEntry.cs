using System;
namespace LaunchCodeCapstone.Models
{
	public class MovieEntry
	{
		public int MovieEntryId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; } //personally set date format of MM / DD / YYYY


        public ICollection<Rating> Ratings { get; set; }


        public MovieEntry(string title, DateTime date)
		{
			Title = title;
			Date = date;
            Ratings = new List<Rating>();

        }

		public MovieEntry()
		{

		}
	}
}

