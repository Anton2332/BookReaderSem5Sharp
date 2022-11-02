using Domain.Entities;
using Domain.QueryMapper;

namespace Domain.Interfaces.TypeBookmark;

public interface ITypeBookmarkRepository : IReadRepository<int,TypeBookmarks>
{
    IEnumerable<TypeBookmarks> GetByUserId(string userId, QueryOptions options);
}