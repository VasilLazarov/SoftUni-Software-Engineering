using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Models
{
    public class SeminarFormModel
    {

        public SeminarFormModel()
        {
            Topic = string.Empty;
            Lecturer = string.Empty;
            Details = string.Empty;
            DateAndTime = string.Empty;
            Categories = new List<CategoryViewModel>();
        }


        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarTopicMaxLength,
            MinimumLength = SeminarTopicMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Topic { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarLecturerMaxLength,
            MinimumLength = SeminarLecturerMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Lecturer { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarDetailsMaxLength,
            MinimumLength = SeminarDetailsMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Details { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public string DateAndTime { get; set; }

        [Range(SeminarDurationMin, 
            SeminarDurationMax, 
            ErrorMessage = SeminarDurationErrorMessage)]
        public int? Duration { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

    }
}
