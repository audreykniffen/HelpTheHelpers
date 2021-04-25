using System;
using System.Collections.Generic;
using System.Linq;
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
            List<ATask> Atasks = context.ATask
                .Include(e => e.Category)
                .ToList();

            return View(Atasks);
        }

        public IActionResult Add()
        {
            List<TaskCategory> categories = context.Categories.ToList();
            AddTaskViewModel addTaskViewModel = new AddTaskViewModel(categories);

            return View(addTaskViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTaskViewModel addTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                TaskCategory theCategory = context.Categories.Find(addTaskViewModel.CategoryId);
                ATask newATask = new ATask
                {
                    Name = addTaskViewModel.Name,
                    Description = addTaskViewModel.Description,
                    
                    Category = theCategory
                };

                context.ATask.Add(newATask);
                context.SaveChanges();

                return Redirect("/Tasks");
            }

            return View(addTaskViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.ATask.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] taskIds)
        {
            foreach (int taskId in taskIds)
            {
                ATask theTask = context.ATask.Find(taskId);
                context.ATask.Remove(theTask);
            }

            context.SaveChanges();

            return Redirect("/Tasks");
        }

        public IActionResult Detail(int id)
        {
            ATask theTask = context.ATask
               .Include(e => e.Category)
               .Single(e => e.Id == id);

            List<TaskTag> taskTags = context.TaskTags
                .Where(et => et.TaskId == id)
                .Include(et => et.Tag)
                .ToList();

            TaskDetailViewModel viewModel = new TaskDetailViewModel(theTask, taskTags);
            return View(viewModel);
        }
    }
}
