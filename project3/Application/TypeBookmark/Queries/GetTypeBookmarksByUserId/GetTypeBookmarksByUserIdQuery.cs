using Domain.QueryMapper;
using MediatR;

namespace Application.TypeBookmark.Queries.GetTypeBookmarksByUserId;

public class GetTypeBookmarksByUserIdQuery : IRequest<IEnumerable<TypeBookmarkDTO>>
{
    public string Id { get; set; }
    public QueryOptions QueryOptions { get; set; }
}