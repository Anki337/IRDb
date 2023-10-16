using IRDb.Database;
using IRDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace IRDb.Data
{
    public static class DbSeeder
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var context = new MovieDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieDbContext>>()))
            {
                
                if (context.Movies.Any())
                {
                    
                    return;
                }

                
                var movies = new MovieModel[]
                {
                    new MovieModel { Title = "The Shawshank Redemption", Director = "Frank Darabont", Year = 1994, Genre = "Drama", Duration = 142, Rating = 9.3 },
                    new MovieModel { Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972, Genre = "Crime, Drama", Duration = 175, Rating = 9.2 },
                    new MovieModel { Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008, Genre = "Action, Crime, Drama", Duration = 152, Rating = 9.0 },
                    new MovieModel { Title = "Pulp Fiction", Director = "Quentin Tarantino", Year = 1994, Genre = "Crime, Drama", Duration = 154, Rating = 8.9 },
                    new MovieModel { Title = "Fight Club", Director = "David Fincher", Year = 1999, Genre = "Drama", Duration = 139, Rating = 8.8 },
                    new MovieModel { Title = "Forrest Gump", Director = "Robert Zemeckis", Year = 1994, Genre = "Drama, Romance", Duration = 142, Rating = 8.8 },
                    new MovieModel { Title = "Inception", Director = "Christopher Nolan", Year = 2010, Genre = "Action, Adventure, Sci-Fi", Duration = 148, Rating = 8.7 },
                    new MovieModel { Title = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", Year = 1999, Genre = "Action, Sci-Fi", Duration = 136, Rating = 8.7 },
                    new MovieModel { Title = "Interstellar", Director = "Christopher Nolan", Year = 2014, Genre = "Adventure, Drama, Sci-Fi", Duration = 169, Rating = 8.6 },
                    new MovieModel { Title = "The Lord of the Rings: The Fellowship of the Ring", Director = "Peter Jackson", Year = 2001, Genre = "Adventure, Drama, Fantasy", Duration = 178, Rating = 8.8 }
                };

                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }
    }
}
