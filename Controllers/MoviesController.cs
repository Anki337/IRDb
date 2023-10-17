using IRDb.Database;
using IRDb.Models;
using IRDb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _repo;

        public MoviesController(IMoviesRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IEnumerable<MovieModel> Get()
        {
            return _repo.GetAllMovies();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            MovieModel? foundMovie = _repo.GetOneMovie(id);

            if (foundMovie != null)
            {
                return Ok(foundMovie);
            }
            return NotFound("Could not find Movie!");
        }
        [HttpPost]
        public void Post([FromBody] MovieModel movie)
        {
            if (movie != null) 
            {
                _repo.PostMovie(movie);
            }
        }
        [HttpPut("{id}")]
        public void Update(int id, MovieModel movie)
        {
            _repo.UpdateMovie(id, movie);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteMovie(id);
        }




    }
}
