namespace DSRCourseProject.Services.Answers;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using System.ComponentModel.DataAnnotations;

public class AnswerModel
{
    public int Id { get; set; }    
    public string Content { get; set; } = string.Empty;
    public int TranslationRequestId { get; set; }

}

public class AnswerModelProfile : Profile
{
    public AnswerModelProfile()
    {
        CreateMap<TranslationAnswer, AnswerModel>();           
    }
}
