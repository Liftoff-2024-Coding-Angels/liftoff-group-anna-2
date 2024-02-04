using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Models.BlogStyleReview;
using LaunchCodeCapstone.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaunchCodeCapstone.Controllers
{
    public class TagsController : Controller
    {
        private readonly ReviewDbContext reviewDbContext;
        public TagsController( ReviewDbContext reviewDbContext)
        {
            this.reviewDbContext = reviewDbContext;
        }

        //CREATE functionality
        [HttpGet]
        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddTag")]
        public async Task<IActionResult> AddTag(AddTagRequest addTagRequest)
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
            //cannot just add async, need to include the await keyword too
             await reviewDbContext.Tags.AddAsync(tag);  //.Add(tag);
            await reviewDbContext.SaveChangesAsync(); //.SaveChanges();
            // return View("AddTag");

            //return to the list to see that tag was added
            return RedirectToAction("List");
        }

        //READ functionality
        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tags = await reviewDbContext.Tags.ToListAsync(); //.ToList();

            return View(tags);

        }

        [HttpGet]
        [ActionName("Edit")]
        //id in param so that it edits the correct one
        public async Task<IActionResult> Edit(Guid id)
        {
            //you can use the find method or the first or default, or single or default
            //var tag = reviewDbContext.Tags.Find(id);
            var tag = await reviewDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id); //.FirstOrDefault(x => x.Id == id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagRequest);
            }
            return View(null);

        }

        //making anything that calls the database asynchronous
        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var existingTag = await reviewDbContext.Tags.FindAsync(tag.Id); //.Find(tag.Id);

            if(existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                //save changes
                await reviewDbContext.SaveChangesAsync(); //.SaveChanges();

                //sending it back to edit page and giving it the parameter
                return RedirectToAction("List", new { id = editTagRequest.Id});
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var tag = await reviewDbContext.Tags.FindAsync(editTagRequest.Id); //.Find(editTagRequest.Id);

            if(tag != null)
            {
                reviewDbContext.Tags.Remove(tag);
                await reviewDbContext.SaveChangesAsync(); //.SaveChanges();

                return RedirectToAction("List");
            }

            //return the result back to the edit page according to the id
            return RedirectToAction("Edit", new {id = editTagRequest.Id});
        }
    }
}
