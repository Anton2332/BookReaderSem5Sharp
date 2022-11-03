using MediatR;

namespace Application.Bookmark.Queries.GetBookmarkByBookId;

public class GetBookmarkByBookIdQuery : IRequest<BookmarkDTO>
{
    public int BookId { get; set; }
}