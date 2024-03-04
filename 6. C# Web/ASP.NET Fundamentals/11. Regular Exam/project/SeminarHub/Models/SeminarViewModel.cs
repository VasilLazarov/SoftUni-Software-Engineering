namespace SeminarHub.Models
{
    public class SeminarViewModel
    {

        public SeminarViewModel()
        {
            Topic = string.Empty;
            Lecturer = string.Empty;
            Category = string.Empty;
            Organizer = string.Empty;
            DateAndTime = string.Empty;
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string Category { get; set; }

        public string DateAndTime { get; set; }

        public string Organizer { get; set; }

    }
}
