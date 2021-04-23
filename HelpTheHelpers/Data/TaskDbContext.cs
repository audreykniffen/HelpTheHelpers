using System;
using HelpTheHelpers.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpTheHelpers.Data
{
    public class TaskDbContext : DbContext
    { 
        public DbSet<Task> Tasks { get; set; }
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
    }
}
