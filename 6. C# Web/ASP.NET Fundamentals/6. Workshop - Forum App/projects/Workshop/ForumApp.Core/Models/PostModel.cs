using System.ComponentModel.DataAnnotations;
using static ForumApp.Infrastructure.Constants.DataConstants;

namespace ForumApp.Core.Models
{
    /// <summary>
    /// Post data transfer model
    /// </summary>
    public class PostModel
    {
        public PostModel()
        {
            Title = string.Empty;
            Content = string.Empty;
        }

        /// <summary>
        /// Post identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post title
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TitleMaxLength, 
            MinimumLength = TitleMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; }

        /// <summary>
        /// Post Content
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ContentMaxLength, 
            MinimumLength = ContentMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; }

    }
}
