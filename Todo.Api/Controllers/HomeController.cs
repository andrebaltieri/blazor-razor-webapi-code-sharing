using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Core.Entities;
using Todo.Core.Handlers;
using Todo.Core.Handlers.Requests;
using Todo.Core.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("v1/todos")]
        public async Task<IEnumerable<TodoItem>> Get([FromServices] ITodoRepository repository)
        {
            return await repository.GetAllAsync();
        }

        [HttpGet("v1/todos/done")]
        public async Task<IEnumerable<TodoItem>> GetDone([FromServices] ITodoRepository repository)
        {
            return await repository.GetDoneAsync();
        }

        [HttpGet("v1/todos/todo")]
        public async Task<IEnumerable<TodoItem>> GetTodo([FromServices] ITodoRepository repository)
        {
            return await repository.GetToDoAsync();
        }

        [HttpPost("v1/todos")]
        public async Task<TodoItem> Post(
            [FromBody] CreateTodoRequest request,
            [FromServices] CreateTodoHandler handler)
        {
            var result = await handler.HandleAsync(request);
            return result;
        }

        [HttpPut("v1/todos/{id}")]
        public async Task<TodoItem> Put(
            [FromRoute] int id,
            [FromServices] MarkAsDoneHandler handler)
        {
            var result = await handler.HandleAsync(new MarkAsDoneRequest
            {
                Id = id
            });
            return result;
        }
    }
}