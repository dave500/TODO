using System.Collections.Generic;

namespace MVC_TODO.Models
{
    public interface IHCModel
    {
        List<Todo> GetTodos();
    }
}