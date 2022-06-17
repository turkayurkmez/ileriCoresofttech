using AuthenticateANDAuthorize.Models;

namespace AuthenticateANDAuthorize.Services
{
    public class MovieService
    {
        List<Movie> movies;
        public MovieService()
        {
            movies =  new List<Movie>
            {
                new Movie { Id = 1, Name = "The Shawshank Redemption", Genre = "Drama" },
                new Movie { Id = 2, Name = "The Godfather", Genre = "Drama" },
                new Movie { Id = 3, Name = "The Godfather: Part II", Genre = "Drama" },
                new Movie { Id = 4, Name = "The Dark Knight", Genre = "Action" },
                new Movie { Id = 5, Name = "12 Angry Man", Genre = "Drama" }
            };
        }
        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }
       
    }
}
