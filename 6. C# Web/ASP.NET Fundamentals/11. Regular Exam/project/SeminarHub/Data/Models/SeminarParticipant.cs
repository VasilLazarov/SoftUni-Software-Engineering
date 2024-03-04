using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{
    [Comment("Mapping table class for entity classes Seminar and IdentityUser participant")]
    public class SeminarParticipant
    {
        public SeminarParticipant()
        {
            Seminar = null!;
            ParticipantId = string.Empty;
            Participant = null!;
        }

        [Required]
        [Comment("Seminar identifier")]
        public int SeminarId { get; set; }

        [ForeignKey(nameof(SeminarId))]
        public Seminar Seminar { get; set; }

        [Required]
        [Comment("Participant identifier")]
        public string ParticipantId { get; set; }

        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; }


    }
}
