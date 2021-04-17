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
        // GET: /<controller>/
       // [HttpGet]

        public IActionResult Index()
        {
            List<string> Tasks = new List<string>();
            Tasks.Add("Laundry");
            Tasks.Add("Get Medicine");
            Tasks.Add("Fence Repair");

            ViewBag.tasks = Tasks;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Any additional method code here

            return View();
        }
   
    }
}
