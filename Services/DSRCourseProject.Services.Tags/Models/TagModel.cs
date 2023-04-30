namespace DSRCourseProject.Services.Tags;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using System.ComponentModel.DataAnnotations;

public class TagModel
{
    public int Id { get; set; }    
    public string Value { get; set; } = string.Empty;    
}

public class TagModelProfile : Profile
{
    public TagModelProfile()
    {
        CreateMap<Tag, TagModel>();           
    }
}
