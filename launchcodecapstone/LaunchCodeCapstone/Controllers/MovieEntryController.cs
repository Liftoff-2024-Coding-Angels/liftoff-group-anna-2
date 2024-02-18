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
        [ActionName("Read")]
        public async Task<IActionResult> Read()
        {
            var movies = await context.MovieEntries?.ToListAsync();
            return View(movies);
        }



        [HttpGet]
		[Route("/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
			//var movie = await context.MovieEntries.FindAsync(MovieEntryId);
           var movie = await context.MovieEntries.FirstOrDefaultAsync(x => x.MovieEntryId == id);

            if (movie != null)
			{
				var editMovie = new AddMovieEntryViewModel
				{
                    MovieEntryId = movie.MovieEntryId,
					Title = movie.Title,
					Date = movie.Date,
                    NumRating = movie.NumRating
				};

				return View(editMovie);
			}
			return View(null);


		}


		[HttpPost]
        [Route("/Edit/{id}")]
        public async Task<IActionResult> Edit(AddMovieEntryViewModel addMovieEntryViewModel)
		{
			var movie = new MovieEntry
			{
				MovieEntryId = addMovieEntryViewModel.MovieEntryId,
				Title = addMovieEntryViewModel.Title,
				Date = addMovieEntryViewModel.Date,
				NumRating = addMovieEntryViewModel.NumRating
			};

			var existingMovie = await context.MovieEntries.FindAsync(movie.MovieEntryId);

			if(existingMovie != null)
			{
				existingMovie.Title = movie.Title;
				existingMovie.Date = movie.Date;
				existingMovie.NumRating = movie.NumRating;
			}

			await context.SaveChangesAsync();

			return RedirectToAction("Read");

        }

		[HttpPost]
		public async Task<IActionResult> Delete (AddMovieEntryViewModel addMovieEntryViewModel)
		{
			var movie = new MovieEntry
			{
				MovieEntryId = addMovieEntryViewModel.MovieEntryId,
				Title = addMovieEntryViewModel.Title,
				Date = addMovieEntryViewModel.Date,
				NumRating = addMovieEntryViewModel.NumRating
			};

			var deletedMovie = await context.MovieEntries.FindAsync(movie.MovieEntryId);

			if(deletedMovie != null)
			{
				context.MovieEntries.Remove(deletedMovie);
				await context.SaveChangesAsync();
			};

			return RedirectToAction("Read");
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

	/*	//[HttpDelete]
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

			*//*if (entry != null)
			{
                context.MovieEntries.Remove(entry);
				
			}*//*
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
		}*/


	/*	[HttpPost]
		//[ActionName("/Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var movie = await context.MovieEntries.FirstOrDefaultAsync(x => x.MovieEntryId == id);


			if (movie == null)
			{
				return NotFound();
			}

			context.MovieEntries.Remove(movie);
			await context.SaveChangesAsync();

			return RedirectToAction("Read");
		}*/

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