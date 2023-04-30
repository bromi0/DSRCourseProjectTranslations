namespace DSRCourseProject.Services.Answers;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using FluentValidation;

public class AddAnswerModel
{    
    public string Content { get; set; } = string.Empty;
    public int TranslationRequestId { get; set; }
}

public class AddAnswerModelValidator : AbstractValidator<AddAnswerModel>
{
    public AddAnswerModelValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");
        RuleFor(x => x.TranslationRequestId)
            .NotEmpty().WithMessage("Link to translation (TranslationRequestId) is required.");
    }
}

public class AddAnswerModelProfile : Profile
{
    public AddAnswerModelProfile()
    {
        CreateMap<AddAnswerModel, TranslationAnswer>();        
    }
}