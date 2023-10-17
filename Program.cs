using IRDb.Data;
using IRDb.Database;
using IRDb.Repositories;
using Microsoft.EntityFrameworkCore;
namespace IRDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("IRDbConnection");
            builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DbSeeder.SeedData(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowOrigin");

            app.Run();
        }
    }
}





