using System;
using Microsoft.AspNetCore.Mvc;

namespace HelpTheHelpers.Models
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public TaskCategory Category { get; set; }
        public int CategoryId { get; set; }


        public int Id { get; }

     
        public Task(string name, string description, string contactNumber)
        {
            Name = name;
            Description = description;
            ContactNumber = contactNumber;
               
  
           
        }
        public Task()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Task @task &&
                   Id == @task.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}