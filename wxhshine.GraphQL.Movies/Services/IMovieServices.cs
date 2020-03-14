using GraphQL.Movies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Movies.Services
{
    public interface IMovieServices
    {
        Task<Movie> GetByIdAsync(int id);

        Task<IEnumerable<Movie>> GetAsync();

        Task<Movie> Add(Movie movie);
    }
}