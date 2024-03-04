using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.BoardConstants;

namespace TaskBoardApp.Data.Models
{
    [Comment("Boards")]
    public class Board
    {

        public Board()
        {
            Tasks = new List<Task>();
        }

        [Key]
        [Comment("Board identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Board Name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Task> Tasks { get; set; }
    }
}
