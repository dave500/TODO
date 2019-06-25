using System;
using System.ComponentModel.DataAnnotations;
namespace MVC_TODO.Models
{
    public class Todo
    {
        public int TodoID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string Text { get; set; }

        public Boolean Complete { get; set; } 
    }
}