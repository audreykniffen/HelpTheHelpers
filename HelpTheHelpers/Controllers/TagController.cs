using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpTheHelpers.Data;
using HelpTheHelpers.Models;
using HelpTheHelpers.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpTheHelpers.Controllers
{
    public class TagController : Controller
    {
        private TaskDbContext context;

        public TagController(TaskDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();
            return View(tags);
        }

        public IActionResult Add()
        {
            Tag tag = new Tag();
            return View(tag);
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Tags.Add(tag);
                context.SaveChanges();
                return Redirect("/Tag/");
            }

            return View("Add", tag);
        }
    }
}