using Microsoft.EntityFrameworkCore;
using IRDb.Models;
namespace IRDb.Database
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<MovieModel> Movies {get; set; }



                
    }
}
