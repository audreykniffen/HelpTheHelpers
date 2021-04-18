using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelpTheHelpers.Data;
using HelpTheHelpers.Models;


namespace HelpTheHelpers.Controllers
{
    public class TasksController : Controller
    {
      
        public IActionResult Index()
        {
            ViewBag.tasks = TaskData.GetAll();

            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
            // Any additional method code here

 
    [HttpPost]
    [Route("Tasks/Add")]
    public IActionResult NewTask (string name, string desc)
    {
        TaskData.Add(new Task(name, desc));


        return Redirect("/Tasks");
    }

    public IActionResult Delete()
    {
        ViewBag.tasks = TaskData.GetAll();

        return View();
    }

    [HttpPost]
    public IActionResult Delete(int[] eventIds)
    {
        foreach (int eventId in eventIds)
        {
           TaskData.Remove(eventId);
        }

        return Redirect("/Events");
    }

    }
}
