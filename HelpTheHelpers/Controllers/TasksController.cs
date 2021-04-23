using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelpTheHelpers.Data;
using HelpTheHelpers.Models;
using HelpTheHelpers.ViewModels;

namespace HelpTheHelpers.Controllers
{
    public class TasksController : Controller
    {
        private TaskDbContext contex;

        public TasksController(TaskDbContext dBContext)
        {
            context = dBContext;
        }

        public IActionResult Index()

        {
            List<Task> tasks = context.Tasks.ToList();

            return View(tasks);
        }

        public IActionResult Add()
        {
            AddTaskViewModel addTaskViewModel = new AddTaskViewModel();

            return View(addTaskViewModel);
        }

        [HttpPost]
        [Route("Tasks/Add")]
        public IActionResult Add(AddTaskViewModel addTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                Task newTask = new Task

                {
                    Name = addTaskViewModel.Name,
                    Description = addTaskViewModel.Description,
                    ContactNumber = addTaskViewModel.ContactNumber,
                    date = addTaskViewModel.date,
                };

                context.Tasks.Add(newTask);
                context.SaveChanges();

                return Redirect("/Tasks");
            }

            return View(addTaskViewModel);

        }

        public IActionResult Delete()
        {
            ViewBag.tasks = context.Events.ToList();

            return View();
        }

        public IActionResult Delete(int[] taskIds)
        {
            foreach (int taskId in taskIds)
            {
                Task theTask = context.Tasks.Find(taskId);
                context.Tasks.Remove(theTask);
            }
            context.SaveChages();

            return Redirect("/Tasks");
        }
    }
}