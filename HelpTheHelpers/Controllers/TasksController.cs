using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelpTheHelpers.Controllers
{
    public class TasksController : Controller
    {
        static private List<Task> Tasks = new List<Task>();

      
        public IActionResult Index()
        {
            ViewBag.tasks = TaskData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Any additional method code here

            return View();
        }

        [HttpPost]
        [Route("/Tasks/Add")]
        public IActionResult NewTask(string name, string desc)
        {
            Tasks.Add(new Task(name, desc));

            return Redirect("/Tasks");
        }
    }
}