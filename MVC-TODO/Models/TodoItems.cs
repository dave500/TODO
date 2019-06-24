using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TODO.Models
{
    public class TodoItems
    {
        public Todo Item { get; set; }
        public List<Todo> Todos { get; set; }
    }
}