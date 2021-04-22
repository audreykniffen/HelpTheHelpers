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

        public IActionResult Index()

        {
            List<Task> tasks = new List<Task>(TaskData.GetAll());

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

                TaskData.Add(newTask);
                return Redirect;


                return Redirect("/Tasks");
            }

            public IActionResult Delete()
            {
                ViewBag.tasks = TaskData.GetAll();

                return View();
            }

            [HttpPost]
            public IActionResult Delete(int[] taskIds)
            {
                foreach (int taskId in taskIds)
                {
                    TaskData.Remove(taskId);
                }

                return Redirect("/Tasks");
            }

        }
    }
}