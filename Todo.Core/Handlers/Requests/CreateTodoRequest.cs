using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Handlers.Requests
{
    public class CreateTodoRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter pelo menos 3 caracteres")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter no máximo 60 caracteres")]
        public string Title { get; set; }
    }
}