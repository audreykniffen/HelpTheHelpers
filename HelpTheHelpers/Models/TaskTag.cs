﻿using System;
namespace HelpTheHelpers.Models
{
    public class TaskTag
    {
        public int TaskId { get; set; }
        public ATask ATask { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public TaskTag()
        {
        }
    }
}