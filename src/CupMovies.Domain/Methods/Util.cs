using CupMovies.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CupMovies.Domain.Methods
{
    public static class Util
    {
        public static List<Movie> PlayoffsMovies(List<Movie> selectedMovies)
        {
            selectedMovies = selectedMovies.OrderBy(c => c.Titulo).ToList();

            var winners = new List<Movie>();

            for (int i = 0, j = selectedMovies.Count; i < j; i++, j--)
            {
                var movieOne = selectedMovies[i];
                var movieTwo = selectedMovies[j - 1];

                winners.Add(Comparison(movieOne, movieTwo));
            }

            for (int i = 0; i < winners.Count; i++)
            {
                var movieOne = winners[i];
                var movieTwo = winners[i + 1];

                winners.Remove(Comparison(movieOne, movieTwo) == movieOne ? movieTwo : movieOne);
            }

            return winners.OrderByDescending(c => c.Nota).ToList();
        }

        private static Movie Comparison(Movie movieOne, Movie movieTwo)
        {
            var winner = new Movie();

            if (movieOne.Nota == movieTwo.Nota)
            {
                var movies = new List<Movie>() { movieOne, movieTwo };
                winner = movies.OrderBy(c => c.Titulo).First();
            }
            else
                winner = movieOne.Nota > movieTwo.Nota ? movieOne : movieTwo;

            return winner;
        }
    }
}
