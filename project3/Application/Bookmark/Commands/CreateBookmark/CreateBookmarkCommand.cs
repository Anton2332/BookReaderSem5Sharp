using MediatR;

namespace Application.Bookmark.Commands.CreateBookmark;

public class CreateBookmarkCommand : IRequest<bool>
{
    public CreateBookmarkDTO CreateBookmarkDto { get; set; }
}