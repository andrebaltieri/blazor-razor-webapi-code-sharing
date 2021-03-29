using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Handlers.Requests
{
    public class MarkAsDoneRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Id { get; set; }
    }
}