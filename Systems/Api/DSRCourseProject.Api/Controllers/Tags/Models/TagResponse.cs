namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Tags;

public class TagResponse
{
    /// <summary>
    /// Tag Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Tag Value
    /// </summary>
    public string Value { get; set; } = string.Empty;    
}

public class TagResponseProfile : Profile
{
    public TagResponseProfile()
    {
        CreateMap<TagModel, TagResponse>();            
    }
}
