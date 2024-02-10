using System;
using System.ComponentModel.DataAnnotations;
using LaunchCodeCapstone.Models;

namespace LaunchCodeCapstone.ViewModels
{
	public class AddMovieEntryViewModel
	{
		[Required(ErrorMessage = "A movie title is required.")]
        public string Title { get; set; }

		[Required(ErrorMessage = "A date is required.")]
		public DateTime Date { get; set; }

		//      [Required(ErrorMessage = "A rating is required.")]
		public int NumRating { get; set; }

		public AddMovieEntryViewModel()
		{
		}
	}
}

