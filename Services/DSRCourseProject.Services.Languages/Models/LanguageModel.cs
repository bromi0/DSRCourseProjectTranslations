namespace DSRCourseProject.Services.Languages;

using AutoMapper;
using DSRCourseProject.Context.Entities;

public class LanguageModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class LanguageModelProfile : Profile
{
    public LanguageModelProfile()
    {
        CreateMap<Language, LanguageModel>();
    }
}
