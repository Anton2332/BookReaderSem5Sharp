using FluentValidation;

namespace Application.Bookmark.Commands.DeleteBookmark;

public class DeleteBookmarkValidator : AbstractValidator<DeleteBookmarkCommand>
{
    public DeleteBookmarkValidator()
    {
        
    }
}