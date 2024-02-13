using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.ViewModels;
//using Microsoft.AspNetCore.Cors;

namespace LaunchCodeCapstone.Controllers
{
	//[EnableCors("MyAllowedOrigins")]
	public class MovieEntryController : Controller
	{

		private MovieDbContext context;

		public MovieEntryController(MovieDbContext dbContext)
		{
			context = dbContext;
		}


		[HttpGet]
		[ActionName("Index")]
		public IActionResult Index()
		{
			List<MovieEntry> movies = context.MovieEntries?.ToList();
			return View(movies);
		}

		[HttpGet]
		[ActionName("Create")]
		public IActionResult Create()
		{
			AddMovieEntryViewModel addMovieEntryViewModel = new AddMovieEntryViewModel();
			return View(addMovieEntryViewModel);
			
		}

		[HttpPost]
		//[Route("/Create")]
		public async Task<IActionResult> Create(AddMovieEntryViewModel addMovieEntryViewModel)
		{
			Console.WriteLine("before if");
			if (ModelState.IsValid)
			{
				MovieEntry aMovie = new MovieEntry
				{
					Title = addMovieEntryViewModel.Title,
					Date = addMovieEntryViewModel.Date,
					NumRating = addMovieEntryViewModel.NumRating
                };

                await context.MovieEntries.AddAsync(aMovie);
				await context.SaveChangesAsync();
				Console.WriteLine("Movie added");

				return RedirectToAction("Create");
			}
            //return RedirectToAction("Create");
            return View();
        }

		[HttpGet]
        [Route("/Edit")]
        public IActionResult Edit(int movieEntryId)
		{
			MovieEntry aMovie = context.MovieEntries.Find(movieEntryId);
			return View(aMovie);

		}

		[HttpPost]
        [Route("/Edit")]
        public async Task<IActionResult> Edit(MovieEntry aMovieEntry)
		{
			if (ModelState.IsValid)
			{
				context.Entry(aMovieEntry).State = EntityState.Modified;
				await context.SaveChangesAsync();
				return Redirect("Index");
			}

			return View(aMovieEntry);
		}

        [HttpGet]
        [Route("/Delete/{movieEntryId}")]
        public async Task<IActionResult> Delete(int movieEntryId)
        {
            MovieEntry aMovie = await context.MovieEntries.FindAsync(movieEntryId);
           // if (aMovie == null)
           // {
                // Return 404 Not Found if the movie entry does not exist
               // return NotFound();
           // }

            var movies = new List<MovieEntry> { aMovie };
            return View(movies);
			//return View(aMovie);
			//return View();
        }


        [HttpPost]
        [Route("/Delete")]
        public async Task<IActionResult> Delete(int[] movieEntryIDs)
		{
			foreach(int movieEntryId in movieEntryIDs)
			{
				MovieEntry aMovie = await context.MovieEntries.FindAsync(movieEntryId);
				context.MovieEntries.Remove(aMovie);
		
			}

           await context.SaveChangesAsync();
			Console.WriteLine("Item deleted.");
           return View();
		}

		//public IActionResult SetRating(AddMovieEntryViewModel addMovieEntryViewModel)
		//{
		//	MovieEntry rating = new AddMovieEntryViewModel;


		//}
	}
}