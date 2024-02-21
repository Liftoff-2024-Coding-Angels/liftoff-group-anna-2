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


namespace LaunchCodeCapstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieEntryController : Controller
	{

		private MovieDbContext context;

		public MovieEntryController(MovieDbContext dbContext)
		{
			context = dbContext;
		}


		[HttpGet]
		[Route("/Index")]
		public IActionResult Index()
		{
			List<MovieEntry> movies = context.MovieEntries?.ToList();
			return View(movies);
		}

		[HttpGet]
		[Route("/Create")]
		public IActionResult Create()
		{
			AddMovieEntryViewModel addMovieEntryViewModel = new AddMovieEntryViewModel();
			return View(addMovieEntryViewModel);
			
		}

		[HttpPost]
		[Route("/Create")]
		public async Task<IActionResult> Create(AddMovieEntryViewModel addMovieEntryViewModel)
		{
			Console.WriteLine("before if");
			if (ModelState.IsValid)
			{
				MovieEntry aMovie = new MovieEntry
				{
					MovieEntryId = addMovieEntryViewModel.MovieEntryId,
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
      /*  [ActionName("Read")]*/
		[Route("Read")]
        public async Task<IActionResult> Read()
        {
            var movies = await context.MovieEntries?.ToListAsync();
			/*return View(movies);*/
            return Json(movies);
        }


/*
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
                   *//* MovieEntryId = movie.MovieEntryId,*//*
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
				*//*MovieEntryId = addMovieEntryViewModel.MovieEntryId,*//*
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

        }*/


        [HttpPut]
        [Route("/MovieEntry/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, AddMovieEntryViewModel addMovieEntryViewModel)
        {
			var editedMovieData = new MovieEntry
			{
				MovieEntryId = id,
				Title = addMovieEntryViewModel.Title,
				Date = addMovieEntryViewModel.Date,
				NumRating = addMovieEntryViewModel.NumRating
			};

			var existingMovie = await context.MovieEntries.FirstOrDefaultAsync(x => x.MovieEntryId == id);

			if (existingMovie != null)
			{

				existingMovie.MovieEntryId = editedMovieData.MovieEntryId;
				existingMovie.Title = editedMovieData.Title;
				existingMovie.Date = editedMovieData.Date;
				existingMovie.NumRating = editedMovieData.NumRating;
			
			}
           // await context.MovieEntries.AddAsync(editedMovieData);
            await context.SaveChangesAsync();

			//return Json(editedMovieData);
			return NoContent(); // No Content response on successful update
		}


		/*   [HttpPost]
		   public async Task<IActionResult> Delete(AddMovieEntryViewModel addMovieEntryViewModel)
		   {
			   var movie = new MovieEntry
			   {
				   MovieEntryId = addMovieEntryViewModel.MovieEntryId,
				   Title = addMovieEntryViewModel.Title,
				   Date = addMovieEntryViewModel.Date,
				   NumRating = addMovieEntryViewModel.NumRating
			   };

			   var deletedMovie = await context.MovieEntries.FindAsync(movie.MovieEntryId);

			   if (deletedMovie != null)
			   {
				   context.MovieEntries.Remove(deletedMovie);
				   await context.SaveChangesAsync();
			   };

			   return RedirectToAction("Read");
		   }*/



		[HttpDelete]
		[Route("/Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var movie = await context.MovieEntries.FirstOrDefaultAsync(x => x.MovieEntryId == id);


			if (movie == null)
			{
				return NotFound();
			}

			context.MovieEntries.Remove(movie);
			await context.SaveChangesAsync();

			return NoContent();
			//return RedirectToAction("Read");
		}



	}
}