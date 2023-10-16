using IRDb.Models;

namespace IRDb.Repositories
{
    public interface IMoviesRepository
    {       
            public IEnumerable<MovieModel>GetAllMovies();
            public MovieModel? GetOneMovie(int id);
            public void PostMovie(MovieModel movie);
            public void UpdateMovie(int id, MovieModel movie);
            public void DeleteMovie(int id);      
    }
}