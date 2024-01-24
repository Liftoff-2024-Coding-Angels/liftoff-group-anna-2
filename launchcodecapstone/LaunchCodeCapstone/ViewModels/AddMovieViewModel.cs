using System;
using System.ComponentModel.DataAnnotations;
using LaunchCodeCapstone.Models;

namespace LaunchCodeCapstone.ViewModels
{
	public class AddMovieViewModel
	{
		[Required(ErrorMessage = "A movie title is required.")]
        public string Title { get; set; }

		[Required(ErrorMessage = "A date is required.")]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = "A selection is required.")]
		public HaveWatched HaveWatched { get; set; }

        public AddMovieViewModel()
		{
		}
	}
}

