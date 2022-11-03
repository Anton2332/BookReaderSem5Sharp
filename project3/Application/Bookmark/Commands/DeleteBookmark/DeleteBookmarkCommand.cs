using MediatR;

namespace Application.Bookmark.Commands.DeleteBookmark;

public class DeleteBookmarkCommand : IRequest<bool>
{
    public int Id { get; set; }
}