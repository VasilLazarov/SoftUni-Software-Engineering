
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.TaskConstants;

namespace TaskBoardApp.Models
{
    public class TaskFormModel
    {

        //public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredError)]
        [StringLength(TitleMaxLength, 
            MinimumLength = TitleMinLength, 
            ErrorMessage = ErrorMessages.StringLengthError)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredError)]
        [StringLength(DescriptionMaxLength, 
            MinimumLength = DescriptionMinLength,
            ErrorMessage = ErrorMessages.StringLengthError)]
        public string Description { get; set; } = string.Empty;


        public int? BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();

        //[Required(ErrorMessage = ErrorMessages.RequiredError)]
        //public string Owner { get; set; } = null!;


    }
}
