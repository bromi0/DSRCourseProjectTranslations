using System.ComponentModel.DataAnnotations;

namespace DSRCourseProject.Context.Entities
{    
    /// <summary>
    /// Every Request for translation can have some tags, to make searching for them easier.
    /// </summary>
    public class Tag : BaseEntity
    {     
        public string Value { get; set; } = null!;

        public virtual ICollection<TranslationRequest>? Translations { get; set; }
    }
}
