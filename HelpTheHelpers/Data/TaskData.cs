using System;
using System.Collections.Generic;
using System.Linq;
using Task.Models;


namespace HelpTheHelpers.Data
{
    public class TaskData
    {
        static private Dictionary<int, Task> Tasks = new Dictionary<int, Task>();

        // GetAll
        public static IEnumerable<Task> GetAll()
        {
            return Tasks.Values;
        }

        // Add
        public static void Add(Task newTask)
        {
            Tasks.Add(newTask.Id, newTask);
        }

        // Remove
        public static void Remove(int id)
        {
            Tasks.Remove(id);
        }

        // GetById
        public static Task GetById(int id)
        {
            return Tasks[id];
        }
    }
}