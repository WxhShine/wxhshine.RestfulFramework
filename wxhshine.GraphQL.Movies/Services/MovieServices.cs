using GraphQL.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Movies.Services
{
    public class MovieServices : IMovieServices
    {
        public Task<IEnumerable<Movie>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Movie> IMovieServices.Add(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
