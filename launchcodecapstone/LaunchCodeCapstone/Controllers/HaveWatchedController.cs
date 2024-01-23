using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			List<HaveWatched> haveOrHaveNotWatched = context.Watchd.ToList();
			return View(haveOrHaveNotWatched);
		}

		public IActionResult AddHaveOrHAveNOtWatched() 
		{
		
		}
	}
}

