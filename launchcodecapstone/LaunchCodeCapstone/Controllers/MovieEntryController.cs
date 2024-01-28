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

		[HttpGet]
        [Route("/Edit")]
        public IActionResult Edit(int movieEntryId)
		{
			MovieEntry aMovie = context.MovieEntry.Find(movieEntryId);
			return View(aMovie);

		}

		[HttpPost]
        [Route("/Edit")]
        public IActionResult Edit(MovieEntry aMovieEntry)
		{
			if (ModelState.IsValid)
			{
				context.Entry(aMovieEntry).State = EntityState.Modified;
				context.SaveChanges();
				return Redirect("Index");
			}

			return View(aMovieEntry);
		}

		[HttpGet]
        [Route("/Delete")]
        public IActionResult Delete(int movieEntryId)
		{
            MovieEntry aMovie = context.MovieEntry.Find(movieEntryId);
            return View(aMovie);
        }

		[HttpPost]
        [Route("/Delete")]
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