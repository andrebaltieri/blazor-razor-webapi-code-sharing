using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo.Core.Handlers;
using Todo.Core.Handlers.Requests;

namespace Todo.Web.Pages
{
    public class Create : PageModel
    {
        [BindProperty]
        public CreateTodoRequest Input { get; set; }
        
        public void OnGet()
        {
            
        }
        
        public async Task<IActionResult> OnPostAsync(
            [FromServices]CreateTodoHandler handler)
        {
            if (!ModelState.IsValid)
                return Page();
            
            await handler.HandleAsync(Input);
            return RedirectToPage("/Index");
        }
    }
}