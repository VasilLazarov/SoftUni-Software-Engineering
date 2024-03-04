namespace SeminarHub.Data
{
    public static class DataConstants
    {
        //Seminar constants
        public const int SeminarTopicMaxLength = 100;
        public const int SeminarTopicMinLength = 3;

        public const int SeminarLecturerMaxLength = 60;
        public const int SeminarLecturerMinLength = 5;

        public const int SeminarDetailsMaxLength = 500;
        public const int SeminarDetailsMinLength = 10;

        public const string SeminarDateFormat = "dd/MM/yyyy HH:mm";

        public const int SeminarDurationMax = 180;
        public const int SeminarDurationMin = 30;


        //Category constants
        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 3;


        //Error messages constants
        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
        public const string SeminarDurationErrorMessage = "The field {0} must be number between {2} and {1}";


    }
}
