using FluentValidation;

namespace Application.TypeBookmark.Commands.DeleteTypeBookmark;

public class DeleteTypeBookmarkValidator : AbstractValidator<DeleteTypeBookmarkCommand>
{
    public DeleteTypeBookmarkValidator()
    {
        RuleFor(model => model.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id must be not null");
    }
}