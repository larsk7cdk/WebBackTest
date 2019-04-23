using Microsoft.EntityFrameworkCore;
using WebBackTest.web.ApplicationCore.Entities;

namespace WebBackTest.web.Infrastructure.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}