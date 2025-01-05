
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Services.Abstract;
using ToDoApp.Services.Concrete;

namespace ToDoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // postgresql configurations
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            // postgresql configurations

            // Add services to the container.
            builder.Services.AddScoped<ITodoService, TodoService>();
            // Add services to the container.

            //CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()   // Tüm originlere izin ver
                          .AllowAnyMethod()   // Tüm HTTP metodlarýna izin ver (GET, POST, PUT, DELETE, vb.)
                          .AllowAnyHeader();  // Tüm baþlýklara izin ver
                });
            });
            //CORS

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //USE CORS
            app.UseCors("AllowAll");
            //USE CORS

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
