using System.Collections.Generic;

namespace MVC_TODO.Models
{
    public class TodoItems
    {
       public Todo Item { get; set; }
       public List<Todo> Todos { get; set; }
    }
}