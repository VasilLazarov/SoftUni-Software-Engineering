using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;


namespace TaskBoardApp.Data.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedTasks());
        }

        private IEnumerable<Task> SeedTasks()
        {
            IEnumerable<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = ConfigurationHelper.TestUser.Id,
                    BoardId = ConfigurationHelper.OpenBoard.Id,
                },
                new Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = ConfigurationHelper.TestUser.Id,
                    BoardId = ConfigurationHelper.OpenBoard.Id,
                },
                new Task()
                {
                    Id = 3,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = ConfigurationHelper.TestUser.Id,
                    BoardId = ConfigurationHelper.InProgressBoard.Id,
                },
                new Task()
                {
                    Id = 4,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = ConfigurationHelper.TestUser.Id,
                    BoardId = ConfigurationHelper.DoneBoard.Id,
                },
            };

            return tasks;
        }

        
    }
}
