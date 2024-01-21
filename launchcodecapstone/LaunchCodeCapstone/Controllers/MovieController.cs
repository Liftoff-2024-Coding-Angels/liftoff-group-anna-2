using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaunchCodeCapstone.Models;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.ViewModels;

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
		return View();

	}

	[HttpPost]
	(Route("/Create")]
	public IactionResult Create()
	{
		if (ModelState.IsValid)
		{
			Movie aMovie = new Movie
			{
				Title = context.Movie.Title
			}
		}

	}

	[HttpPut]
    public IActionResult Update()
    {
        return View();
    }

	[HttpDelete]
    public IActionResult Delete()
    {
        return View();
    }
}
