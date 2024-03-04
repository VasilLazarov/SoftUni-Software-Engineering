namespace ForumApp.Infrastructure.Constants
{
    /// <summary>
    /// Validation Constants
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Maximal Post Title length
        /// </summary>
        public const int TitleMaxLength = 50;

        /// <summary>
        /// Minimal Post Title length
        /// </summary>
        public const int TitleMinLength = 10;

        /// <summary>
        /// Maximal Post Content length
        /// </summary>
        public const int ContentMaxLength = 1500;

        /// <summary>
        /// Minimal Post Content length
        /// </summary>
        public const int ContentMinLength = 30;

        /// <summary>
        /// Required Error message text
        /// </summary>
        public const string RequiredErrorMessage = "The {0} field is required";

        /// <summary>
        /// 
        /// </summary>
        public const string StringLengthErrorMessage = "Text in field {0} must be between {2} and {1} characters long";

    }
}
