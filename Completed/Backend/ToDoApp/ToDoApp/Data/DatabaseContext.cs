using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities;

namespace ToDoApp.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }
    }
}
