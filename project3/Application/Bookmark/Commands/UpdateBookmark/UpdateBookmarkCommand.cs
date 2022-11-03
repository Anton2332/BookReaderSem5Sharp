using MediatR;

namespace Application.Bookmark.Commands.UpdateBookmark;

public class UpdateBookmarkCommand : IRequest<bool>
{
    public UpdateBookmarkDTO UpdateBookmarkDto { get; set; }
    
    public int Id { get; set; }
}