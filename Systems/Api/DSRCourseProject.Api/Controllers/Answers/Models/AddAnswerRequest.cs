namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Answers;
using FluentValidation;

public class AddAnswerRequest
{    
    public string Content { get; set; } = string.Empty;
    public int TranslationRequestId { get; set; }
}

public class AddAnswerRequestValidator : AbstractValidator<AddAnswerRequest>
{
    public AddAnswerRequestValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");
        RuleFor(x => x.TranslationRequestId)
            .NotEmpty().WithMessage("TranslationRequestId for linking to Translation request is required");
          
    }
}

public class AddAnswerRequestProfile : Profile
{
    public AddAnswerRequestProfile()
    {
        CreateMap<AddAnswerRequest, AddAnswerModel>();            
    }
}

