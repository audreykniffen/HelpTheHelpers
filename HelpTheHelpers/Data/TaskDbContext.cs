using System;
using HelpTheHelpers.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpTheHelpers.Data
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskCategory> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskTag> EventTags { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskTag>().HasKey(et => new { et.TaskId, et.TagId });
        }
    }
}