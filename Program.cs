
using Labb3APIv2.Data;
using Labb3APIv2.Services;
using Microsoft.EntityFrameworkCore;
using PersoModels;

namespace Labb3APIv2
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

            // ADDED THIS
            builder.Services.AddScoped<IHobbyRepository<Person>, PersonRepository>();
            builder.Services.AddScoped<IHobbyRepository<Interest>, InterestRepository>();
            builder.Services.AddScoped<IHobbyRepository<Link>, LinkRepository>();

            builder.Services.AddDbContext<PersonDbConxtext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            // En läsning till serialize
            /*
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });*/

            // TO HERE
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
