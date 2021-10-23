using CupMovies.Domain.Interface.Service;
using CupMovies.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CupMovies.API.Movies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            var moviesList = _moviesService.GetMoviesList();
            return Ok(moviesList);
        }

        [HttpPost("Qualifiers")]
        public ActionResult<IEnumerable<Movie>> GetMoviesQualifiers([FromBody] List<Movie> selectedMovies)
        {
            var winners = _moviesService.GetMoviesQualifiers(selectedMovies);
            return Ok(winners);
        }
    }
}
