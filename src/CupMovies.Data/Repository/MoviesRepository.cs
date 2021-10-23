using CupMovies.Domain.Interface.Repository;
using CupMovies.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CupMovies.Data.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly ToolServices _toolServices;

        public MoviesRepository(ToolServices toolServices)
        {
            _toolServices = toolServices;
        }
        public IEnumerable<Movie> GetMoviesList()
        {
            var url = _toolServices.URL_API_Movies;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    var listaFilmes = streamReader.ReadToEnd();
                    streamReader.Close();

                    var convert = JsonConvert.DeserializeObject<IEnumerable<Movie>>(listaFilmes);
                    return convert;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
