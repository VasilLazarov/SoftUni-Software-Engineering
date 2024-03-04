using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.TaskConstants;

namespace TaskBoardApp.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;


        public int? BoardId { get; set; }

        [Required]
        public string Owner { get; set; } = null!;
    }
}
