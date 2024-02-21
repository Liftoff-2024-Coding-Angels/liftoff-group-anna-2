using LaunchCodeCapstone.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LaunchCodeCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //when you have an api controller it doesn't expect a view to come back, it expects http responses
    public class ImagesController : ControllerBase
    {
        //testing
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    //ok response is the 200 success response
        //    return Ok("This is the Get Images API call.");
        //}
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //call a repository
            var imageURL = await imageRepository.UploadAsync(file);

            if (imageURL == null)
            {
                return Problem("Image upload unsuccessful", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageURL });
        }
    }
}