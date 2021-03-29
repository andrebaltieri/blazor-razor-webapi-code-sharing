using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo.Core.Entities;
using Todo.Core.Repositories;

namespace Todo.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<TodoItem> Todos { get; set; }
        
        public async Task OnGet([FromServices]ITodoRepository repository)
        {
            Todos = await repository.GetAllAsync();
        }
    }
}
