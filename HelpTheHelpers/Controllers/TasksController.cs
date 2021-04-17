using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpTheHelpers.Controllers
{
    public class TasksController : Controller
    {
         static private List<string> Tasks = new List<string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.tasks = Tasks;

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
        public IActionResult NewTask(string name)
        {
            Tasks.Add(name);

            return Redirect("/Tasks");
        }
    }
}