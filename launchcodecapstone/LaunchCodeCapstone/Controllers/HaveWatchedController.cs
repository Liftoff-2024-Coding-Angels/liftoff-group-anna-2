using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models;
using LaunchCodeCapstone.ViewModels;
using System;

namespace LaunchCodeCapstone.Controllers
{
	public class HasWatchedController : Controller
	{
		private MovieDbContext context;
		public HasWatchedController(MovieDbContext dbContext)
		{
			context = dbContext;
		}

		public IActionResult Index()
		{
			List<HaveWatched> haveOrHaveNotWatched = context.Watched.ToList();
			return View(haveOrHaveNotWatched);
		}

		public IActionResult AddHaveOrHAveNOtWatched(AddMovieEntryViewModel addMovieViewModel) 
		{
			if ()
			{

			}

		
		}
	}
}

