namespace DSRCourseProject.Services.TranslationRequests;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using DSRCourseProject.Services.Tags;

public class TranslationRequestModel
{
    public int Id { get; set; }    
    public string Content { get; set; } = string.Empty;
    public int SourceLanguageId { get; set; }
    public string SourceLanguageName{ get; set; } = string.Empty;
    public int TargetLanguageId { get; set; }
    public string TargetLanguageName { get; set; } = string.Empty;
    public ICollection<TagModel>? Tags { get; set; }
}

public class TranslationRequestModelProfile : Profile
{
    public TranslationRequestModelProfile()
    {
        CreateMap<TranslationRequest, TranslationRequestModel>()
            .ForMember(dest => dest.TargetLanguageName, opt => opt.MapFrom(src => src.TargetLanguage.Name))
            .ForMember(dest => dest.SourceLanguageName, opt => opt.MapFrom(src => src.SourceLanguage.Name));
    }
}
