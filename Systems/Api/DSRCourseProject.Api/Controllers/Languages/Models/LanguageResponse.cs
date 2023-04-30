namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Languages;

public class LanguageResponse
{
    /// <summary>
    /// Language Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Language Value
    /// </summary>
    public string Name { get; set; } = string.Empty;
}

public class LanguageResponseProfile : Profile
{
    public LanguageResponseProfile()
    {
        CreateMap<LanguageModel, LanguageResponse>();
    }
}
