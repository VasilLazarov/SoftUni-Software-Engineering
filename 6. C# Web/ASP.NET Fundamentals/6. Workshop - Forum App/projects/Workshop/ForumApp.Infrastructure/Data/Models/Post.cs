using static ForumApp.Infrastructure.Constants.DataConstants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Infrastructure.Data.Models
{
    [Comment("Post table")]
    public class Post
    {

        public Post()
        {
            Title = string.Empty;
            Content = string.Empty;
        }

        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Post Title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        [Comment("Post Content")]
        public string Content { get; set; }
    }
}
