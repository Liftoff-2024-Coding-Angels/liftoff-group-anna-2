using System;
using System.ComponentModel.DataAnnotations;
using LaunchCodeCapstone.Models;

namespace LaunchCodeCapstone.ViewModels
{
	public class AddMovieEntryViewModel
	{
		[Key]
		public int MovieEntryId { get; set; }

		[Required(ErrorMessage = "A movie title is required.")]
        public string Title { get; set; }

		[Required(ErrorMessage = "A date is required.")]
        [DataType(DataType.Date)] // Specify the DataType for Date
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int NumRating { get; set; }	

  //      [Required(ErrorMessage = "A rating is required.")]
		//public List<int> Rating { get; set; }

		public AddMovieEntryViewModel()
		{
		}
	}
}

