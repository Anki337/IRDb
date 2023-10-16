using IRDb.Database;
using IRDb.Models;

namespace IRDb.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MovieDbContext _context;

        public MoviesRepository(MovieDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieModel> GetAllMovies()
        {
            return _context.Movies;
        }

        public MovieModel? GetOneMovie(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void PostMovie(MovieModel movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(int id, MovieModel movie)
        {
            MovieModel? movieToUpdate = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieToUpdate != null)
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.Director = movie.Director;
                movieToUpdate.Year = movie.Year;
                movieToUpdate.Genre = movie.Genre;
                movieToUpdate.Rating = movie.Rating;
                _context.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            MovieModel? movieToDelete = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
        }
    }
}
