using Domain.QueryMapper;
using MediatR;

namespace Application.Bookmark.Queries.GetBookmarksByTypeBookmarkId;

public class GetBookmarksByTypeBookmarkIdQuery : IRequest<IEnumerable<BookmarkResponseDTO>>
{
    public int TypeBookmarkId { get; set; }
    public QueryOptions QueryOptions { get; set; }
}