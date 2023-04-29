namespace DSRCourseProject.Services.TranslationRequests;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using FluentValidation;

public class AddTranslationRequestModel
{
    public string Content { get; set; } = string.Empty;
    public int SourceLanguageId { get; set; }    
    public int TargetLanguageId { get; set; }    
}

public class AddTranslationRequestModelValidator : AbstractValidator<AddTranslationRequestModel>
{
    public AddTranslationRequestModelValidator()
    {
        RuleFor(x => x.SourceLanguageId)
            .NotEmpty().WithMessage("Source Language is required.");
        RuleFor(x => x.TargetLanguageId)
            .NotEmpty().WithMessage("Target Language is required.");
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Request content is required.");            
    }
}

public class AddTranslationRequestModelProfile : Profile
{
    public AddTranslationRequestModelProfile()
    {
        CreateMap<AddTranslationRequestModel, TranslationRequest>();            
    }
}