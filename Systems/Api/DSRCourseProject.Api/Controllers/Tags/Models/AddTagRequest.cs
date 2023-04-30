namespace DSRCourseProject.API.Controllers.Models;

using AutoMapper;
using DSRCourseProject.Services.Tags;
using FluentValidation;

public class AddTagRequest
{
    public string Value { get; set; } = string.Empty;
}

public class AddTagResponseValidator : AbstractValidator<AddTagRequest>
{
    public AddTagResponseValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Value is required.")
            .MaximumLength(50).WithMessage("Value is too long.");
    }
}

public class AddTagRequestProfile : Profile
{
    public AddTagRequestProfile()
    {
        CreateMap<AddTagRequest, AddTagModel>();
    }
}

