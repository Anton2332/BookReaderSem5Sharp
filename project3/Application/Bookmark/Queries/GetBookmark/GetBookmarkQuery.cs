using MediatR;

namespace Application.Bookmark.Queries.GetBookmark;

public class GetBookmarkQuery : IRequest<BookmarkDTO>
{
    public int Id { get; set; }
}