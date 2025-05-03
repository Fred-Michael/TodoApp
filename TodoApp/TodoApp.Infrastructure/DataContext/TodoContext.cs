using Microsoft.EntityFrameworkCore;
using TodoApp.TodoApp.Domain;

namespace TodoApp.TodoApp.Infrastructure.DataContext
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base (options) { }

        public DbSet<TodoItem> Todos { get; set; }
    }
}
