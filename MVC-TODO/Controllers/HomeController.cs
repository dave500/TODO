using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using MVC_TODO.Helpers;
using MVC_TODO.Models;
using static MVC_TODO.Models.Todo;

namespace MVC_TODO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var todoItems = new TodoItems();
            todoItems.Todos = new List<Todo>();
            todoItems.Item = new Todo();

            return View(todoItems);
        }

        [HttpPost]
        public ActionResult AddItem(Models.Todo item)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                var currentItems = (List<Todo>)TempData["CurrentItems"] ?? new List<Todo>();

                currentItems.Add(item);

                TempData["CurrentItems"] = currentItems;

                TodoItems todoItems = HomeControllerHelper.CreateModel(currentItems);

                return View("Index", todoItems);
            }

            return View("Error");
        }

        

        public ActionResult RemoveItem(int itemID)
        {
            var currentItems = (List<Todo>)TempData["CurrentItems"];

            var item = currentItems.FirstOrDefault(x => x.TodoID == itemID);
            currentItems.Remove(item);
            TempData["CurrentItems"] = currentItems;

            ModelState.Clear();

            TodoItems todoItems = HomeControllerHelper.CreateModel(currentItems);

            return View("Index", todoItems);
        }

        
        [HttpPost]
        public ActionResult AmendCompleteTask(int itemID, bool isComplete)
        {

            var currentItems = (List<Todo>)TempData["CurrentItems"];

            var item = currentItems.FirstOrDefault(x => x.TodoID == itemID);
            item.Complete = isComplete;

            currentItems.Replace(x => x.TodoID == Convert.ToInt32(itemID), item);

            TempData["CurrentItems"] = currentItems;

            ModelState.Clear();

            TodoItems todoItems = HomeControllerHelper.CreateModel(currentItems);

            return Json(new { success = true });
        }

        public ActionResult CongratsMessage()
        {
            return PartialView("_CongratsMessage");
        }

        public ActionResult MessageReset()
        {
            return PartialView("_MessageReset");
        }
    }
}