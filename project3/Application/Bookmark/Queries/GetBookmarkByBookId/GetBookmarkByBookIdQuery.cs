using MediatR;

namespace Application.Bookmark.Queries.GetBookmarkByBookId;

public class GetBookmarkByBookIdQuery : IRequest<IEnumerable<BookmarkDTO>>
{
    public int BookId { get; set; }
}