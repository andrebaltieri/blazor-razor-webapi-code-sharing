using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core.Entities;

namespace Todo.Core.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<IEnumerable<TodoItem>> GetToDoAsync();
        Task<IEnumerable<TodoItem>> GetDoneAsync();
        Task<TodoItem> GetAsync(int id);
        Task CreateAsync(TodoItem item);
        Task UpdateAsync(TodoItem item);
    }
}