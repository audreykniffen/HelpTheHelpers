using System;
using Microsoft.AspNetCore.Mvc;

namespace HelpTheHelpers.Models
{
    public class ATask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskCategory Category { get; set; }
        public int CategoryId { get; set; }


        public int Id { get; set; }

     
        public ATask(string name, string description)
        {
            Name = name;
            Description = description;
            
           
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
            return obj is ATask @Atask &&
                   Id == @Atask.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}