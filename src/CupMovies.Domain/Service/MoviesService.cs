using CupMovies.Domain.Interface.Repository;
using CupMovies.Domain.Interface.Service;
using CupMovies.Domain.Methods;
using CupMovies.Domain.Models;
using System.Collections.Generic;

namespace CupMovies.Domain.Service
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<Movie> GetMoviesList()
        {
            var movies = _moviesRepository.GetMoviesList();
            return movies;
        }

        public List<Movie> GetMoviesQualifiers(List<Movie> selectedMovies)
        {
            var movies = Util.PlayoffsMovies(selectedMovies);
            return movies;
        }
    }
}
