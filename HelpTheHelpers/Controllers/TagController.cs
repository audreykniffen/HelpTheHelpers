using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpTheHelpers.Data;
using HelpTheHelpers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HelpTheHelpers.ViewModels;


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
        public IActionResult AddTask(int id)
        {
            ATask theTask = context.ATask.Find(id);
            List<Tag> possibleTags = context.Tags.ToList();

            AddTaskTagViewModel viewModel = new AddTaskTagViewModel(theTask, possibleTags);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(AddTaskTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int taskId = viewModel.TaskId;
                int tagId = viewModel.TagId;

                List<TaskTag> existingItems = context.TaskTags
                    .Where(et => et.TaskId == taskId)
                    .Where(et => et.TagId == tagId)
                    .ToList();

                if (existingItems.Count == 0)
                {

                    TaskTag taskTag = new TaskTag
                    {
                        TaskId = taskId,
                        TagId = tagId
                    };

                    context.TaskTags.Add(taskTag);
                    context.SaveChanges();
                }

                return Redirect("/Tasks/Detail/" + taskId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            List<TaskTag> eventTags = context.TaskTags
                .Where(et => et.TagId == id)
                .Include(et => et.ATask)
                .Include(et => et.Tag)
                .ToList();

            return View(eventTags);
        }
    }
}