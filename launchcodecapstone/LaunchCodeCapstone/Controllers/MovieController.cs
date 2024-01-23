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
	public class MovieController : Controller
	{

		private MovieDbContext context;

		public MovieController(MovieDbContext dbContext)
		{
			context = dbContext;
		}
		

		[HttpGet]
		public IActionResult Index()
		{
			List<Movie> movies = context.Movie?.ToList();
			return View(movies);
		}

		[HttpGet]
		[Route("/Create")]
		public IActionResult Create()
		{
			AddMovieViewModel addMovieViewModel = new AddMovieViewModel();
			return View();

		}

		[HttpPost]
		[Route("/Create")]
		public IActionResult Create(AddMovieViewModel addMovieViewModel)
		{
			if (ModelState.IsValid)
			{
				Movie aMovie = new Movie
				{
					Title = addMovieViewModel.Title,
					Date = addMovieViewModel.Date,
					//
					HaveWatched = addMovieViewModel.HaveWatched,
				};

				context.Movies?.Add(aMovie);
				context.SaveChanges();

				Redirect("/Create");
			}
			return View();
		}

		[HttpPut]
		public IActionResult Update(AddMovieViewModel addMovieViewModel)
		{
			if(ModelState.IsValid)
			{
				//this needs to be set up for the table that has the linking MovieId with the date watched
				existingDate = context.Movie.Where(e => e.MovieId == movieId)

				if(existingDate != newDate)
				{
					//change the current date to the new date in the view model
				}
			}
			return View(Index);
		}

		[HttpDelete]
		public IActionResult Delete(int[] movieIDs)
		{
			foreach(int movieId in movieIDs)
			{
				Movie aMovie = context.Movie.Find(movieId);
				context.Movie.Remove(aMovie);
		
			}

            context.SaveChanges();
            return View();
		}
	}
}