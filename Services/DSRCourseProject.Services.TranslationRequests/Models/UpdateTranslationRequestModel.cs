namespace DSRCourseProject.Services.TranslationRequests;

using AutoMapper;
using DSRCourseProject.Context.Entities;
using DSRCourseProject.Services.Tags;
using FluentValidation;

public class UpdateTranslationRequestModel
{
    public string Content { get; set; } = string.Empty;
    public int SourceLanguageId { get; set; }
    public int TargetLanguageId { get; set; }
    public ICollection<UpdateTagModel>? Tags { get; set; }
}

public class UpdateTranslationRequestModelValidator : AbstractValidator<UpdateTranslationRequestModel>
{
    public UpdateTranslationRequestModelValidator()
    {
        RuleFor(x => x.SourceLanguageId)
                 .NotEmpty().WithMessage("Source Language is required.");
        RuleFor(x => x.TargetLanguageId)
            .NotEmpty().WithMessage("Target Language is required.");
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Request content is required.");
    }
}

public class UpdateTranslationRequestModelProfile : Profile
{
    public UpdateTranslationRequestModelProfile()
    {
        CreateMap<UpdateTranslationRequestModel, TranslationRequest>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore());
    }
}