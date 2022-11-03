using Application.Bookmark.Queries.GetBookmark;
using FluentValidation;

namespace Application.TypeBookmark.Queries.GetTypeBookmark;

public class GetTypeBookmarkValidator : AbstractValidator<GetTypeBookmarkQuery>
{
    public GetTypeBookmarkValidator()
    {
        RuleFor(model => model.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id must be not null");
    }
}