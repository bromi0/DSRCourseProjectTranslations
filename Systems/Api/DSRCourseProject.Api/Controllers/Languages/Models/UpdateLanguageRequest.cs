namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Languages;
using FluentValidation;

public class UpdateLanguageRequest
{
    public string Name { get; set; } = string.Empty;    
}

public class UpdateLanguageRequestValidator : AbstractValidator<UpdateLanguageRequest>
{
    public UpdateLanguageRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(40).WithMessage("Name is long.");
    }
}

public class UpdateLanguageRequestProfile : Profile
{
    public UpdateLanguageRequestProfile()
    {
        CreateMap<UpdateLanguageRequest, UpdateLanguageModel>();        
    }
}
