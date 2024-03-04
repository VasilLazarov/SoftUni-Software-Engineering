using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data.Models
{
    [Comment("Category entity class")]
    public class Category
    {
        public Category()
        {
            Name = string.Empty;
            Seminars = new List<Seminar>();
        }
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; }

        public ICollection<Seminar> Seminars { get; set; }
    }
}
