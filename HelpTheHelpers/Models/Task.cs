using System;
namespace HelpTheHelpers.Models
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }

        public int Id { get; }
        static private int nextId = 1;

        public Task()
        {
            Id = nextId;
            nextId++;
        }

        public Task(string name, string description, string contactNumber) : this()
        {
            Name = name;
            Description = description;
            ContactNumber = contactNumber;
            Id = nextId;
            nextId++;
           
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