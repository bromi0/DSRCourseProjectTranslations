namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.TranslationRequests;

public class TranslationRequestResponse
{
    /// <summary>
    /// TranslationRequest Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// TranslationRequest Content
    /// </summary>
    public string Content { get; set; } = string.Empty;
    public int SourceLanguageId { get; set; }
    public string SourceLanguageName { get; set; } = string.Empty;
    public int TargetLanguageId { get; set; }
    public string TargetLanguageName { get; set; } = string.Empty;
    public ICollection<TagResponse>? Tags { get; set; }
    public ICollection<AnswerResponse>? Answers { get; set; }
}

public class TranslationRequestResponseProfile : Profile
{
    public TranslationRequestResponseProfile()
    {
        CreateMap<TranslationRequestModel, TranslationRequestResponse>();
    }
}
