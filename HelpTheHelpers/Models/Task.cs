using System;
namespace HelpTheHelpers.Models
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public DueDate Date { get; set; }

        public int Id { get; }
        static private int nextId = 1;

        public Task()
        {
           
        }

        public Task(string name, string description, string contactNumber)
        {
            Name = name;
            Description = description;
            ContactNumber = contactNumber;
  
           
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