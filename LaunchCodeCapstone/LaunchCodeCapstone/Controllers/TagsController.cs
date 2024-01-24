using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models.BlogStyleReview;
using LaunchCodeCapstone.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LaunchCodeCapstone.Controllers
{
    public class TagsController : Controller
    {
        private readonly ReviewDbContext reviewDbContext;
        public TagsController( ReviewDbContext reviewDbContext)
        {
            this.reviewDbContext = reviewDbContext;
        }


        [HttpGet]
        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
//        [ActionName("AddTag")]
        public IActionResult AddTag(AddTagRequest addTagRequest)
        {
            //removed to do model binding instead
            //checking to see if value is assigning correctly
            //var name = Request.Form["name"];
            //var displayName = Request.Form["displayName"];

            //var name = addTagRequest.Name;
            //var displayName = addTagRequest.displayName;

            //mapping AddTagRequest to Tag  model

            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            reviewDbContext.Tags.Add(tag);
            reviewDbContext.SaveChanges();
            return View("AddTag");
        }
    }
}
