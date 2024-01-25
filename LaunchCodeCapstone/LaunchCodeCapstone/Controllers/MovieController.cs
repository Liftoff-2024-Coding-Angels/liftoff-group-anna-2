using LaunchCodeCapstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaunchCodeCapstone.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult GetMembers()
        {
            IEnumerable<MovieViewModel> movies = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/movie/popular");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("movie");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MovieViewModel>>();
                    readTask.Wait();

                    movies = readTask.Result;
                }
                else
                {
                    //Error response received   
                    movies = Enumerable.Empty<MovieViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(movies);
        }
        //var responseTask = client.GetAsync("movie");

    }
}
