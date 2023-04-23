namespace DSRCourseProjectTranslations.Data.Entities
{
    /// <summary>
    /// Language, entity to use as source and target in the Request
    /// </summary>
    public class Language : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<TranslationRequest>? RequestsFromLanguage { get; internal set; }
        public ICollection<TranslationRequest>? RequestsToLanguage { get; internal set; }
    }
}
