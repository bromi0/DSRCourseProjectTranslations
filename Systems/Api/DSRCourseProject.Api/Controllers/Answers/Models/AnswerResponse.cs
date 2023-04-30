namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Answers;

public class AnswerResponse
{
    /// <summary>
    /// Answer Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Answer Content
    /// </summary>
    /// 
    public string Content { get; set; } = string.Empty;    
    public int TranslationRequestId { get; set; }
}

public class AnswerResponseProfile : Profile
{
    public AnswerResponseProfile()
    {
        CreateMap<AnswerModel, AnswerResponse>();            
    }
}
