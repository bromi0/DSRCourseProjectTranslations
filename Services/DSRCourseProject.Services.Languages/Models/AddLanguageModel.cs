namespace DSRCourseProject.Services.Languages;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using FluentValidation;

public class AddLanguageModel
{    
    public string Name { get; set; } = string.Empty;
}

public class AddLanguageModelValidator : AbstractValidator<AddLanguageModel>
{
    public AddLanguageModelValidator()
    {        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(40).WithMessage("Name is too long.");        
    }
}

public class AddLanguageModelProfile : Profile
{
    public AddLanguageModelProfile()
    {
        CreateMap<AddLanguageModel, Language>();            
    }
}