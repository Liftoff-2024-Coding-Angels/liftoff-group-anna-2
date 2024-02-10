using System;
using System.ComponentModel.DataAnnotations;
using LaunchCodeCapstone.Models;

public class MovieData		
{
	[Key]
	public int MovieId { get; set; }
    public string Title { get; set; }
	public DateTime	DateCreated { get; set; }
	public string Director { get; set; }
	public string LeadActor { get; set; }

	public MovieData()
	{
	}

}
