using System;
namespace LaunchCodeCapstone.Models
{
	public class MovieEntry
	{
		public int MovieEntryId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; } //personally set date format of MM / DD / YYYY
       
        public List<int> Rating { get; set; }


        public MovieEntry(string title, DateTime date, List<int> rating)
		{
			Title = title;
			Date = date;
			Rating = rating;
		}

		public MovieEntry()
		{

		}
	}
}

