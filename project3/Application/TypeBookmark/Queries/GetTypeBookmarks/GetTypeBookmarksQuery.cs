using Domain.QueryMapper;
using MediatR;

namespace Application.TypeBookmark.Queries.GetTypeBookmarks;

public class GetTypeBookmarksQuery : IRequest<IEnumerable<TypeBookmarkDTO>>
{
    public QueryOptions QueryOptions { get; set; }
}