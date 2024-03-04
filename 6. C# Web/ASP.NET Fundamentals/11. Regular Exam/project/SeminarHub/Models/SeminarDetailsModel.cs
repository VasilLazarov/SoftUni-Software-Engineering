using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    public class SeminarDetailsModel
    {
        public SeminarDetailsModel()
        {
            Topic = string.Empty;
            Lecturer = string.Empty;
            Details = string.Empty;
            DateAndTime = string.Empty;
            Category = string.Empty;
            Organizer = string.Empty;
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string Details { get; set; }

        public string DateAndTime { get; set; }

        public int? Duration { get; set; }

        public string Category { get; set; }

        public string Organizer { get; set; }
    }
}
