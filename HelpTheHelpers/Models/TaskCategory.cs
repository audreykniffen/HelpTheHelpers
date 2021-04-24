using System;
using System.Collections.Generic;

namespace HelpTheHelpers.Models
{
    public class TaskCategory
    {
        
        public string Name { get; set; }

        public int Id { get; set; }

        public List<ATask> events { get; set; }

        public TaskCategory(string name)
        {
            Name = name;
        }

        public TaskCategory()
        {
        }
    }
}
