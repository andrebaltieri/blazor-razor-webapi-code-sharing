using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Core.Entities;
using Todo.Core.Repositories;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDataContext _context;

        public TodoRepository(TodoDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context
                .Todos
                .AsNoTracking()
                .OrderByDescending(x => x.LastUpdateDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetToDoAsync()
        {
            return await _context
                .Todos
                .AsNoTracking()
                .Where(x => x.Done == false)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetDoneAsync()
        {
            return await _context
                .Todos
                .AsNoTracking()
                .Where(x => x.Done)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToListAsync();
        }

        public async Task<TodoItem> GetAsync(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(TodoItem item)
        {
            await _context.Todos.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoItem item)
        {
            _context.Todos.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}