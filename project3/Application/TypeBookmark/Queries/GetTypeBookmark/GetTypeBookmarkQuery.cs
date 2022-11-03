using MediatR;

namespace Application.TypeBookmark.Queries.GetTypeBookmark;

public class GetTypeBookmarkQuery : IRequest<TypeBookmarkDTO>
{
    public int Id { get; set; }
}