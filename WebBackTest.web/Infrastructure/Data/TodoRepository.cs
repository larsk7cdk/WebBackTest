using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBackTest.web.ApplicationCore.Entities;
using WebBackTest.web.ApplicationCore.Interfaces;

namespace WebBackTest.web.Infrastructure.Data
{
    public interface ITodoRepository : IRepository<Todo>
    {
        Task<IReadOnlyList<Todo>> GetAllAsync();
    }

    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(TodoDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Todo>> GetAllAsync() =>
             await Context.Todos.ToListAsync();
    }
}