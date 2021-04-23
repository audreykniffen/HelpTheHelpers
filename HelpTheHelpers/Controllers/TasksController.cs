using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpTheHelpers.Data;
using HelpTheHelpers.Models;
using HelpTheHelpers.ViewModels;

namespace HelpTheHelpers.Controllers
{
    public class TasksController : Controller
    {
        private TaskDbContext context;

        public TasksController(TaskDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Task> tasks = context.Tasks
                .Include(e => e.Category)
                .ToList();

            return View(tasks);
        }

        public IActionResult Add()
        {
            List<TaskCategory> categories = context.Categories.ToList();
            AddTaskViewModel addTaskViewModel = new AddTaskViewModel(categories);

            return View(addTaskViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTaskViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                TaskCategory theCategory = context.Categories.Find(addTaskViewModel.CategoryId);
                Task newTask = new Task
                {
                    Name = addEventViewModel.Name,
                    Description = addTaskViewModel.Description,
                    ContactEmail = addTaskViewModel.DueDate,
                    Category = theCategory
                };

                context.Tasks.Add(newTask);
                context.SaveChanges();

                return Redirect("/Tasks");
            }

            return View(addTaskViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Tasks.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] taskIds)
        {
            foreach (int taskId in taskIds)
            {
                Task theTask = context.Tasks.Find(taskId);
                context.Tasks.Remove(theTask);
            }

            context.SaveChanges();

            return Redirect("/Tasks");
        }

        public IActionResult Detail(int id)
        {
            Task theTask = context.Tasks
               .Include(e => e.Category)
               .Single(e => e.Id == id);

            TaskDetailViewModel viewModel = new TaskDetailViewModel(theTask);
            return View(viewModel);
        }
    }
}