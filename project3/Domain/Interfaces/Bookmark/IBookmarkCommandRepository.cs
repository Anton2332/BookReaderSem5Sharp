using Domain.Entities;

namespace Domain.Interfaces.Bookmark;

public interface IBookmarkCommandRepository : ICommandRepository<int, Bookmarks>
{
    
}