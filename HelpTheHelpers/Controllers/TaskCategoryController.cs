using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpTheHelpers.Data;
using HelpTheHelpers.Models;
using Microsoft.AspNetCore.Mvc;
using HelpTheHelpers.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpTheHelpers.Controllers
{
    public class TaskCategoryController : Controller
    {
        private TaskDbContext context;

        public TaskCategoryController(TaskDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<TaskCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddTaskCategoryViewModel addTaskCategoryViewModel = new AddTaskCategoryViewModel();
            return View(addTaskCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEventCategoryForm(AddTaskCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                TaskCategory newCategory = new TaskCategory
                {
                    Name = addEventCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View("Create", addEventCategoryViewModel);
        }
    }
}