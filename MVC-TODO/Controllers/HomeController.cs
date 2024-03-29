﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TODO.Helpers;
using MVC_TODO.Models;
using static MVC_TODO.Models.Todo;

namespace MVC_TODO.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHCModel _hcModel;
        private readonly List<Todo> _todos;


        public HomeController(IHCModel hcModel)
        {
            _hcModel = hcModel;
            // Mimics decoupled dependancy on external data source
            _todos = _hcModel.GetTodos();
        }

        
        public ActionResult Index()
        {
            var todoItems = new TodoItems();
            todoItems.Todos = _todos;

            // This is just a POCO to capture the screen input
            todoItems.Item = new Todo();

            return View(todoItems);
        }

        [HttpPost]
        public ActionResult AddItem(Models.Todo item)
        {
            ModelState.Clear();
            var currentItems = (List<Todo>)TempData["CurrentItems"] ?? new List<Todo>();

            currentItems.Add(item);

            TempData["CurrentItems"] = currentItems;

            TodoItems todoItems = HomeControllerHelper.CreateModel(currentItems);

            return View("Index", todoItems);
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