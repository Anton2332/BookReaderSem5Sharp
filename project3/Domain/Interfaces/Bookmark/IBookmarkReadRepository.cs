using Domain.Entities;
using Domain.QueryMapper;

namespace Domain.Interfaces.Bookmark;

public interface IBookmarkReadRepository : IReadRepository<int, Bookmarks>
{
    IEnumerable<Bookmarks> GetByUserId(int typeBookmarkId, QueryOptions options);
}