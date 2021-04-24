using Microsoft.EntityFrameworkCore;
using HelpTheHelpers.Models;

namespace HelpTheHelpers.Data
{
    public class TaskDbContext : DbContext
    {
        public DbSet<ATask> ATask { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskCategory> Categories { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }


        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskTag>().HasKey(c => new { c.TaskId, c.TagId });
        }
    }
}



//public class EventDbContext : IdentityDbContext<IdentityUser>
