namespace DSRCourseProject.Services.Tags;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using FluentValidation;

public class AddTagModel
{    
    public string Value { get; set; } = string.Empty;
}

public class AddTagModelValidator : AbstractValidator<AddTagModel>
{
    public AddTagModelValidator()
    {        
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Value is required.")
            .MaximumLength(20).WithMessage("Value is too long.");        
    }
}

public class AddTagModelProfile : Profile
{
    public AddTagModelProfile()
    {
        CreateMap<AddTagModel, Tag>();        
    }
}