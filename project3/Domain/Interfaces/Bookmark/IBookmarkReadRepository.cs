using Domain.Entities;
using Domain.QueryMapper;

namespace Domain.Interfaces.Bookmark;

public interface IBookmarkReadRepository : IReadRepository<int, Bookmarks>
{
    IEnumerable<Bookmarks> GetByTypeBookmarkId(int typeBookmarkId, QueryOptions options);
    Bookmarks GetByBookId(int BookId, int TypeBookmarkId);
    
    IEnumerable<Bookmarks> GetAllByBookId(int BookId);
}