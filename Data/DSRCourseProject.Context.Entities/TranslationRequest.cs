namespace DSRCourseProject.Context.Entities
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
        public virtual Language SourceLanguage { get; set; } = null!;
        public int TargetLanguageId { get; set; }
        public virtual Language TargetLanguage { get; set; } = null!;

        public virtual ICollection<Tag>? Tags { get; set; }

        public virtual ICollection<TranslationAnswer>? Answers { get; set; }

    }
}
