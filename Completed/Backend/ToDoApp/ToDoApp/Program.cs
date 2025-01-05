
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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
