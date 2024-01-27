using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaunchCodeCapstone.Models;
using System.Net.Http.Headers;


namespace LaunchCodeCapstone.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri("https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1"),
        //        Headers =
        //    {
        //        { "accept", "application/json" },
        //        { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzZmFmYmI2NzU5NTJmNjZkODBlMWE1Y2MyM2FmN2VlMyIsInN1YiI6IjY1YjFiYzczNmVlY2VlMDE2MjMzZjRmYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.vEJUScrm282EjN3PhWzDB2tvlUFPHHgPDIhlHU2ym1o" },
        //    },
        //    };
        //using (var response = await client.SendAsync(request))
        //{
        //    response.EnsureSuccessStatusCode();
        //    var body = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine(body);
}


    }
}
