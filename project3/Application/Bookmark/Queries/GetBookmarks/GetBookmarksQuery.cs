using Domain.QueryMapper;
using MediatR;

namespace Application.Bookmark.Queries.GetBookmarks;

public class GetBookmarksQuery : IRequest<IEnumerable<BookmarkDTO>>
{
    public QueryOptions QueryOptions { get; set; }
}