using AuthenticateANDAuthorize.Models;
using AuthenticateANDAuthorize.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticateANDAuthorize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_movieService.GetMovies());
        }
        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            return Ok();
        }

    }
}
