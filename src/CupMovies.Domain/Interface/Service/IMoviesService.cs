using CupMovies.Domain.Models;
using System.Collections.Generic;

namespace CupMovies.Domain.Interface.Service
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetMoviesList();
        List<Movie> GetMoviesQualifiers(List<Movie> selectedMovies);
    }
}
