using System;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Handlers.Requests;
using Todo.Core.Repositories;

namespace Todo.Core.Handlers
{
    public class MarkAsDoneHandler
    {
        private readonly ITodoRepository _repository;

        public MarkAsDoneHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItem> HandleAsync(MarkAsDoneRequest request)
        {
            var todo = await _repository.GetAsync(request.Id);
            todo.Done = true;
            todo.LastUpdateDate = DateTime.Now;

            await _repository.UpdateAsync(todo);
            return todo;
        }
    }
}