using FluentValidation;

namespace Application.Bookmark.Commands.UpdateBookmark;

public class UpdateBookmarkValidator : AbstractValidator<UpdateBookmarkCommand>
{
    public UpdateBookmarkValidator()
    {
    }
}