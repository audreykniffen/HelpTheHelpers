using System;
using System.Collections.Generic;
using HelpTheHelpers.Models;


namespace HelpTheHelpers.ViewModels
{
    public class TaskDetailViewModel
    {
 

        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }

        public TaskDetailViewModel(Task theTask)
        {
            Name = theTask.Name;
            Description = theTask.Description;
            CategoryName = theTask.Category.Name;
        }
    }
}