namespace SeminarHub.Models
{
    public class SeminarDeleteModel
    {
        public SeminarDeleteModel()
        {
            Topic = string.Empty;
            DateAndTime = string.Empty;
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string DateAndTime { get; set; }

    }
}
