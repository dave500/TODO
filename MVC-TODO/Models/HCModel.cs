using System.Collections.Generic;

namespace MVC_TODO.Models
{
    public class HCModel : IHCModel
    {
       public List<Todo> GetTodos()
        {
            //Mock datasource getting existing TO DO items

            return new List<Todo>();
        }
    }
}