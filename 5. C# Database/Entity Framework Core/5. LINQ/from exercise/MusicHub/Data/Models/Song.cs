using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models
{
    public class Song
    {

        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SongNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public TimeSpan Duration { get; set; } // In the DB this will be stored as BIGINT <=> Ticks count

        [Required]
        //[Column("CreatedOn", TypeName = "date")]
        public DateTime CreatedOn { get; set; }


        // Enumeration are stored in DB as INT
        
        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public virtual Album? Album { get; set; }

        [Required]
        public int WriterId { get; set; }

        [ForeignKey(nameof(WriterId))]
        public virtual Writer Writer { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        
        public virtual ICollection<SongPerformer> SongPerformers { get; set; }

    }
}
