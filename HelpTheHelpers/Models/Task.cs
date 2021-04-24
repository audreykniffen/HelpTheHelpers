using System;
using Microsoft.AspNetCore.Mvc;

namespace HelpTheHelpers.Models
{
    public class ATask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public TaskCategory Category { get; set; }
        public int CategoryId { get; set; }


        public int Id { get; set; }

     
        public ATask(string name, string description, string contactNumber)
        {
            Name = name;
            Description = description;
            ContactNumber = contactNumber;
               
  
           
        }
        public ATask()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is ATask @task &&
                   Id == @task.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}