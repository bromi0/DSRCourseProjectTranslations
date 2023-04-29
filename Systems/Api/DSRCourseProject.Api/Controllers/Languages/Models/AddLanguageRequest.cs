namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Languages;
using FluentValidation;

public class AddLanguageRequest
{    
    public string Name { get; set; } = string.Empty;
}

public class AddLanguageResponseValidator : AbstractValidator<AddLanguageRequest>
{
    public AddLanguageResponseValidator()
    {        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Nameis too long.");
    }
}

public class AddLanguageRequestProfile : Profile
{
    public AddLanguageRequestProfile()
    {
        CreateMap<AddLanguageRequest, AddLanguageModel>();            
    }
}

