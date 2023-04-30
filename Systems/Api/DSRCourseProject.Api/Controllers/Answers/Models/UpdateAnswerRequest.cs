namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Answers;
using FluentValidation;

public class UpdateAnswerRequest
{
    public string Content { get; set; } = string.Empty;
}

public class UpdateAnswerRequestValidator : AbstractValidator<UpdateAnswerRequest>
{
    public UpdateAnswerRequestValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");
    }
}

public class UpdateAnswerRequestProfile : Profile
{
    public UpdateAnswerRequestProfile()
    {
        CreateMap<UpdateAnswerRequest, UpdateAnswerModel>();
    }
}
