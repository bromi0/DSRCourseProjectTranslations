namespace DSRCourseProject.Services.Languages;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using FluentValidation;

public class UpdateLanguageModel
{
    public string Name { get; set; } = string.Empty;
}

public class UpdateLanguageModelValidator : AbstractValidator<UpdateLanguageModel>
{
    public UpdateLanguageModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(40).WithMessage("Name is too long.");
    }
}

public class UpdateLanguageModelProfile : Profile
{
    public UpdateLanguageModelProfile()
    {
        CreateMap<UpdateLanguageModel, Language>();
    }
}