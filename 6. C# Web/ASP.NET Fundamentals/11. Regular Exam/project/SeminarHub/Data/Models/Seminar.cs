using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data.Models
{
    [Comment("Seminar entity class")]
    public class Seminar
    {
        public Seminar()
        {
            Topic = string.Empty;
            Lecturer = string.Empty;
            Details = string.Empty;
            OrganizerId = string.Empty;
            Organizer = null!;
            Category = null!;
            SeminarsParticipants = new List<SeminarParticipant>();
        }

        [Key]
        [Comment("Seminar identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(SeminarTopicMaxLength)]
        [Comment("Seminar topic")]
        public string Topic { get; set; }

        [Required]
        [MaxLength(SeminarLecturerMaxLength)]
        [Comment("Seminar lecturer")]
        public string Lecturer { get; set; }

        [Required]
        [MaxLength(SeminarDetailsMaxLength)]
        [Comment("Seminar details")]
        public string Details { get; set; }

        [Required]
        [Comment("Seminar organizer identifier")]
        public string OrganizerId { get; set; }

        [Required]
        [ForeignKey(nameof(OrganizerId))]
        public IdentityUser Organizer { get; set; }

        [Required]
        [Comment("Seminar date and time")]
        public DateTime DateAndTime { get; set; }

        [Comment("Seminar duration")]
        [Range(SeminarDurationMin, SeminarDurationMax)]
        public int? Duration { get; set; }

        [Required]
        [Comment("Seminar category identifier")]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<SeminarParticipant> SeminarsParticipants { get; set; }
    }
}
