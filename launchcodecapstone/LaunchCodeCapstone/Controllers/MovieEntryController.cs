using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.ViewModels;

namespace LaunchCodeCapstone.Controllers
{
	public class MovieEntryController : Controller
	{

		private MovieDbContext context;

		public MovieEntryController(MovieDbContext dbContext)
		{
			context = dbContext;
		}
		

		[HttpGet]
		public IActionResult Index()
		{
			List<MovieEntry> movies = context.MovieEntry?.ToList();
			return View(movies);
		}

		[HttpGet]
		[Route("/Create")]
		public IActionResult Create()
		{
			AddMovieEntryViewModel addMovieEntryViewModel = new AddMovieEntryViewModel();
			return View();

		}

		[HttpPost]
		[Route("/Create")]
		public IActionResult Create(AddMovieEntryViewModel addMovieEntryViewModel)
		{
			if (ModelState.IsValid)
			{
				MovieEntry aMovie = new MovieEntry
				{
					Title = addMovieEntryViewModel.Title,
					Date = addMovieEntryViewModel.Date,
					Rating = addMovieEntryViewModel.Rating
                };

				context.Movies?.Add(aMovie);
				context.SaveChanges();

				Redirect("/Create");
			}
			return View();
		}

		[HttpPut]
		public IActionResult Update(AddMovieEntryViewModel addMovieEntryViewModel)
		{
			if(ModelState.IsValid)
			{
				if(context.MovieEntryId == )
				// if
				// HaveWatched goes from False to True
				// Update the form
				// DATE required
				// RATING ?required?

				//this needs to be set up for the table that has the linking MovieId with the date watched
				existingDate = context.Movie.Where(e => e.MovieId == movieId)

				if(context.Watched.Where(e => e.MovieId) != )
				{
					//change the current date to the new date in the view model
				}
			}
			return View(Index);
		}

		[HttpDelete]
		public IActionResult Delete(int[] movieEntryIDs)
		{
			foreach(int movieEntryId in movieEntryIDs)
			{
				MovieData aMovie = context.MovieEntry.Find(movieEntryId);
				context.MovieEntry.Remove(aMovie);
		
			}

            context.SaveChanges();
            return View();
		}

		public IActionResult SetRating(AddMovieEntryViewModel addMovieEntryViewModel)
		{
			MovieEntry rating = new AddMovieEntryViewModel;


		}
	}
}