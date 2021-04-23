using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HelpTheHelpers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpTheHelpers.ViewModels
{
    public class AddTaskViewModel
    {
        [Required(ErrorMessage = "Information is required")]
        [StringLength(200, MinimumLength =3, ErrorMessage = "Task Must be between 3 and 200 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Information is required")]
        [StringLength(500, ErrorMessage = "Description is too long")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Please Assign this Task")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddTaskViewModel(List<TaskCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(
                    new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name
                    }
                ); ;
            }
        }

        public AddTaskViewModel() { }

    }
}
