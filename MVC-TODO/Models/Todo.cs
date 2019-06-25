using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC_TODO.Models
{
    public class Todo
    {
        public int TodoID { get; set; }

        [AllowHtml]
        [Required]
        public string Text { get; set; }

        public Boolean Complete { get; set; } 
    }
}