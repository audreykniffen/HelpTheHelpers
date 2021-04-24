using System;
using System.Collections.Generic;
using HelpTheHelpers.Models;


namespace HelpTheHelpers.ViewModels
{
    public class TaskDetailViewModel
    {

        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string CategoryName { get; set; }
        public string TagText { get; set; }

        public TaskDetailViewModel(ATask theTask, List<TaskTag> taskTags)
        {
            TaskId = theTask.Id;
            Name = theTask.Name;
            Description = theTask.Description;
          
            CategoryName = theTask.Category.Name;

            TagText = "";

            for (var i = 0; i < taskTags.Count; i++)
            {
                TagText += "#" + taskTags[i].Tag.Name;

                if (i < taskTags.Count - 1)
                {
                    TagText += ", ";
                }
            }
        }
    }
}

