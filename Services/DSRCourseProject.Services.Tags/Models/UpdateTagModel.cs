namespace DSRCourseProject.Services.Tags;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using FluentValidation;

public class UpdateTagModel
{
    public string Value{ get; set; } = string.Empty;    
}

public class UpdateTagModelValidator : AbstractValidator<UpdateTagModel>
{
    public UpdateTagModelValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Value is required.")
            .MaximumLength(20).WithMessage("Value is too long.");        
    }
}

public class UpdateTagModelProfile : Profile
{
    public UpdateTagModelProfile()
    {
        CreateMap<UpdateTagModel, Tag>();            
    }
}