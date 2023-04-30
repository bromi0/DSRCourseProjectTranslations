namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Tags;
using FluentValidation;

public class UpdateTagRequest
{
    public string Value { get; set; } = string.Empty;    
}

public class UpdateTagRequestValidator : AbstractValidator<UpdateTagRequest>
{
    public UpdateTagRequestValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Value is required.")
            .MaximumLength(20).WithMessage("Value is long.");
    }
}

public class UpdateTagRequestProfile : Profile
{
    public UpdateTagRequestProfile()
    {
        CreateMap<UpdateTagRequest, UpdateTagModel>();                  
    }
}
