using System.ComponentModel.DataAnnotations;
using Task = TaskBoardApp.Data.Models.Task;
using static TaskBoardApp.Data.DataConstants.BoardConstants;

namespace TaskBoardApp.Models

{
    public class BoardViewModel
    {

        public BoardViewModel()
        {
            Tasks = new List<TaskViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
