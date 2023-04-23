namespace DSRCourseProject.Context.Entities
{
    /// <summary>
    /// Language, entity to use as source and target in the Request
    /// </summary>
    public class Language : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<TranslationRequest>? RequestsFromLanguage { get; internal set; }
        public virtual ICollection<TranslationRequest>? RequestsToLanguage { get; internal set; }
    }
}
