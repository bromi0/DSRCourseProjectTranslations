namespace DSRCourseProjectTranslations.Data.Entities
{
    public class TranslationAnswer : BaseEntity
    {
        public string Content { get; set; } = null!;

        public int TranslationRequestId { get; set; }
        public TranslationRequest Request { get; set; } = null!;

    }
}
