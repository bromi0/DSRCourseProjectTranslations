namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.TranslationRequests;
using FluentValidation;

public class UpdateTranslationRequestRequest
{
    public string Content { get; set; } = string.Empty;
    public int SourceLanguageId { get; set; }
    public int TargetLanguageId { get; set; }
    public ICollection<UpdateTagRequest>? Tags { get; set; }
}

public class UpdateTranslationRequestRequestValidator : AbstractValidator<UpdateTranslationRequestRequest>
{
    public UpdateTranslationRequestRequestValidator()
    {
        RuleFor(x => x.SourceLanguageId)
         .NotEmpty().WithMessage("Source Language is required.");
        RuleFor(x => x.TargetLanguageId)
            .NotEmpty().WithMessage("Target Language is required.");
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Request content is required.");
    }
}

public class UpdateTranslationRequestRequestProfile : Profile
{
    public UpdateTranslationRequestRequestProfile()
    {
        CreateMap<UpdateTranslationRequestRequest, UpdateTranslationRequestModel>();
    }
}
