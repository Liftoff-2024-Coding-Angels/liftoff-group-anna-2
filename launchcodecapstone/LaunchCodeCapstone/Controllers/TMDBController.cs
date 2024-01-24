using LaunchCodeCapstone.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaunchCodeCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDBController : ControllerBase
    {
        private readonly TMDBController _context;
        public TMDBController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetAsync() => await _context.Movie.ToListAsync;
    }
}
