using System;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Handlers.Requests;
using Todo.Core.Repositories;

namespace Todo.Core.Handlers
{
    public class CreateTodoHandler
    {
        private readonly ITodoRepository _repository;

        public CreateTodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<TodoItem> HandleAsync(CreateTodoRequest request)
        {
            var todo = new TodoItem
            {
                Title = request.Title, 
                Done = false, 
                CreateDate = DateTime.Now, 
                LastUpdateDate = DateTime.Now
            };

            await _repository.CreateAsync(todo);
            return todo;
        }
    }
}