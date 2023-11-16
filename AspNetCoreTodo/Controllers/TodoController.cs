using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            // get data from db
            var items = await _todoItemService.GetIncompleteItemsAsync();
            // store data in model
            var model = new TodoViewModel()
            {
                Items = items
            };

            // rendering view with model
            return View(model);
            // return View();
            // return Ok(0);
        }
    }
}
