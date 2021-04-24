using System;
using System.Collections.Generic;
using HelpTheHelpers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpTheHelpers.ViewModels
{
    public class AddTaskTagViewModel
    {

        public int TaskId { get; set; }
        public ATask ATask { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public int TagId { get; set; }

        public AddTaskTagViewModel(ATask theTask, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            ATask = theTask;
        }

        public AddTaskTagViewModel()
        {
        }
    }
}
