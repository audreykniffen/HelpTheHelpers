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
        public string ContactNumber { get; set; }

        public DueDate date { get; set; }

        /* public List<SelectListItem> DueDate { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(DueDate.ASAP.ToString(), ((int)DueDate.ASAP).ToString()),
            new SelectListItem(DueDate.Today.ToString(), ((int)DueDate.Today).ToString()),
            new SelectListItem(DueDate.Tomorrow.ToString(), ((int)DueDate.Tomorrow).ToString()),
            new SelectListItem(DueDate.ThisWeek.ToString(), ((int)DueDate.ThisWeek).ToString()),
            new SelectListItem(DueDate.ThisMonth.ToString(), ((int)DueDate.ThisMonth).ToString()),
            new SelectListItem(DueDate.ThisYear.ToString(), ((int)DueDate.ThisYear).ToString()),

        };
        */
    }
}