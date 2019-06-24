using MVC_TODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TODO.Helpers
{
    public static class HomeControllerHelper
    {
        public static TodoItems CreateModel(List<Todo> currentItems)
        {
            var todoItems = new TodoItems();

            if (!currentItems.Any())
            {
                todoItems.Item = new Todo();
                todoItems.Todos = new List<Todo>();
            }
            else
            {
                todoItems.Item = new Todo();
                todoItems.Todos = currentItems;
            }

            return todoItems;
        }
    }
}