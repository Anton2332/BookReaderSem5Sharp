using FluentValidation;

namespace Application.TypeBookmark.Commands.CreateTypeBookmark;

public class CreateTypeBookmarkValidator : AbstractValidator<CreateTypeBookmarkCommand>
{
    public CreateTypeBookmarkValidator()
    {
        RuleFor(model => model.CreateTypeBookmarkDto.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id must be not null");

        RuleFor(model => model.CreateTypeBookmarkDto.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Name in TypeBookmark must be not null")
            .NotEmpty().WithMessage("Name in TypeBookmark must be not empty");

        RuleFor(model => model.CreateTypeBookmarkDto.UserId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("ChapterId must be not null");

    }
}