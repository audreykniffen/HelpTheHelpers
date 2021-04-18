using System;
using System.ComponentModel.DataAnnotations;


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
    }
}