namespace DsrCourseProjectTranslations.Data.Entities
{
    /// <summary>
    /// Request for the translation. Contains the links to source and target languages, 
    /// the text of the request, and the link to the author (user).
    /// Optional list of tags.
    /// </summary>
    public class TranslationRequest : BaseEntity
    {
        public string Content { get; set; } = null!;

        public int SourceLanguageId { get; set; }
        public Language SourceLanguage { get; set; } = null!;
        public int TargetLanguageId { get; set; }
        public Language TargetLanguage { get; set; } = null!;

        public ICollection<Tag>? Tags { get; set; }

    }
}
