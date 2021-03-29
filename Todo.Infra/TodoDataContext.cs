using Microsoft.EntityFrameworkCore;
using Todo.Core.Entities;

namespace Todo.Infra
{
    public class TodoDataContext : DbContext
    {
        public TodoDataContext(DbContextOptions<TodoDataContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }
    }
}