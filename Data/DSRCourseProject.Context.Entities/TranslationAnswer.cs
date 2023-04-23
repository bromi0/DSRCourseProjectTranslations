namespace DSRCourseProject.Context.Entities
{
    public class TranslationAnswer : BaseEntity
    {
        public string Content { get; set; } = null!;

        public int TranslationRequestId { get; set; }
        public virtual TranslationRequest Request { get; set; } = null!;

    }
}
