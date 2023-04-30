namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.TranslationRequests;
using FluentValidation;

public class AddTranslationRequestRequest
{
    public string Content { get; set; } = string.Empty;
    public int SourceLanguageId { get; set; }
    public int TargetLanguageId { get; set; }
    public ICollection<AddTagRequest>? Tags { get; set; }
}

public class AddTranslationRequestResponseValidator : AbstractValidator<AddTranslationRequestRequest>
{
    public AddTranslationRequestResponseValidator()
    {
        RuleFor(x => x.SourceLanguageId)
         .NotEmpty().WithMessage("Source Language is required.");
        RuleFor(x => x.TargetLanguageId)
            .NotEmpty().WithMessage("Target Language is required.");
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Request content is required.");
    }
}

public class AddTranslationRequestRequestProfile : Profile
{
    public AddTranslationRequestRequestProfile()
    {
        CreateMap<AddTranslationRequestRequest, AddTranslationRequestModel>();            
    }
}

