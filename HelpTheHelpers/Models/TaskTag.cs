using System;
namespace HelpTheHelpers.Models
{
    public class TaskTag
    {
        public int TaskId { get; set; }
        public ATask Task { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }


        public TaskTag(int taskId, int tagId, string contactNumber,
            Tag tag, ATask task)
        {
            TaskId = taskId;
            TagId = tagId;
            Tag = tag;
            Task = task;
        }
        public TaskTag()
        {
        }
    }
}