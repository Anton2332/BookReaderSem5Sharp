using FluentValidation;

namespace Application.Bookmark.Queries.GetBookmark;

public class GetBookmarkValidator : AbstractValidator<GetBookmarkQuery>
{
    public GetBookmarkValidator()
    {
        RuleFor(model => model.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id must be not null");
    }
}