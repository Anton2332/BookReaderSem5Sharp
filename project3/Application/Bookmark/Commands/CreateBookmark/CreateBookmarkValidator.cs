using FluentValidation;

namespace Application.Bookmark.Commands.CreateBookmark;

public class CreateBookmarkValidator : AbstractValidator<CreateBookmarkCommand>
{
    public CreateBookmarkValidator()
    {
        RuleFor(model => model.CreateBookmarkDto.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id must be not null");

        RuleFor(model => model.CreateBookmarkDto.BookId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("BookId must be not null");

        RuleFor(model => model.CreateBookmarkDto.TypeBookmarkId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("TypeBookmarkId must be not null");
    }
}