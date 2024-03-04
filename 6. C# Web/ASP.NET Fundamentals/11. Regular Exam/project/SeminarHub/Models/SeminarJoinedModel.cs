namespace SeminarHub.Models
{
    public class SeminarJoinedModel
    {
        public SeminarJoinedModel()
        {
            Topic = string.Empty;
            Lecturer = string.Empty;
            DateAndTime = string.Empty;
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string DateAndTime { get; set; }

    }
}
