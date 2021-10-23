using CupMovies.Domain.Models;
using System.Collections.Generic;

namespace CupMovies.Domain.Interface.Repository
{
    public interface IMoviesRepository
    {
        IEnumerable<Movie> GetMoviesList();
    }
}
