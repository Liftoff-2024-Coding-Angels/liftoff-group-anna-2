using System;
using System.ComponentModel.DataAnnotations;

public class Movie		
{
	public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; } //personally set date format of MM / DD / YYYY
    public bool HaveWatched { get; set; }

	public List<int> Rating { get; set; }
 
	
	public Movie(string title, DateTime date, bool haveWatched)
	{
		Title = title;
		Date = date;
		HaveWatched = haveWatched;
	}

	public Movie()
	{
	}
}
