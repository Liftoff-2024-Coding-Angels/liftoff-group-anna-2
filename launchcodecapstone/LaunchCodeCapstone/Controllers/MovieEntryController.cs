using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.ViewModels;
using DM.MovieApi.MovieDb.Movies;
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
        [Route("/Edit/{id}")]
        public async Task<IActionResult> Edit (int id)
		{
			MovieEntry? aMovie = await context.MovieEntries.FirstOrDefaultAsync(m => m.MovieEntryId == id);
			return View(aMovie);

		}

       /* [HttpGet]
        [Route("/Edit")]
        public IActionResult Edit()
        {
            List<MovieEntry> aMovie = context.MovieEntries.Find(movieEntryId);
            return View(aMovie);

        }*/


        [HttpPost]
        public async Task<IActionResult> Edit(AddMovieEntryViewModel addMovieEntryViewModel)
		{
            MovieEntry aMovie = new MovieEntry
            {
                Title = addMovieEntryViewModel.Title,
                Date = addMovieEntryViewModel.Date,
                NumRating = addMovieEntryViewModel.NumRating
            };

            if (ModelState.IsValid)
			{
				context.Entry(aMovie).State = EntityState.Modified;
				await context.SaveChangesAsync();
				return Redirect("Index");
			}

			return View(aMovie);
		}

		/*[HttpGet]
		[Route("/Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			MovieEntry aMovie = await context.MovieEntries.FindAsync(id);
			if (aMovie == null)
			{
				//Return 404 Not Found if the movie entry does not exist
			 return NotFound();
			}

			var movies = new List<MovieEntry> { aMovie };
			return View(movies);
            //return View(aMovie);
            //return View();
        }*/

		/*[HttpGet]
		[Route("/Delete")]
		public async Task<IActionResult> Delete(int? id)
		{
			MovieEntry? aMovie = await context.MovieEntries.FirstOrDefaultAsync(m => m.MovieEntryId == id);
			Console.WriteLine(aMovie);
		*//*	if (aMovie == null)
			{
				Console.WriteLine("A movie not in database");
				return NotFound();

			}*/


		/*	var movie = await context.MovieEntries
			.FirstOrDefaultAsync(m => m.MovieEntryId == id);
			if (movie == null)
			{
				return NotFound();
			}
*//*
			//return View(movie);
			return View(aMovie);
		}*/

		//[HttpDelete]
		[HttpPost]
		//[Route("/Delete")]

		public async Task<IActionResult> Delete(int[] movieEntryIds)
		{
			foreach(int movieEntryId in movieEntryIds)
			{
                MovieEntry? aMovie = await context.MovieEntries.FindAsync(movieEntryId);
				context.MovieEntries.Remove(aMovie);
                Console.WriteLine(aMovie);
            }
			
			//var entry = await context.MovieEntries.FindAsync(addMovieEntryViewModel.MovieEntryId);

			/*if (entry != null)
			{
                context.MovieEntries.Remove(entry);
				
			}*/
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
		}



       /* [HttpDelete]
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
		}*/

		//public IActionResult SetRating(AddMovieEntryViewModel addMovieEntryViewModel)
		//{
		//	MovieEntry rating = new AddMovieEntryViewModel;


		//}
	}
}