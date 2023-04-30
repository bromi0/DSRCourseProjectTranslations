namespace DSRCourseProject.Services.Answers;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using FluentValidation;

// We can only change content, we can't change to which item did we answer.
public class UpdateAnswerModel
{
    public string Content { get; set; } = string.Empty;
}

public class UpdateAnswerModelValidator : AbstractValidator<UpdateAnswerModel>
{
    public UpdateAnswerModelValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");
    }
}

public class UpdateAnswerModelProfile : Profile
{
    public UpdateAnswerModelProfile()
    {
        CreateMap<UpdateAnswerModel, TranslationAnswer>();            
    }
}