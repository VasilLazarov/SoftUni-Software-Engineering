﻿namespace TaskBoardApp.Models
{
    public class TaskDetailsViewModel : TaskViewModel
    {

        public string? CreatedOn { get; set; }

        public string Board { get; set; } = string.Empty;
    }
}
