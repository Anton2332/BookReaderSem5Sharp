using Domain.Entities;

namespace Domain.Interfaces.TypeBookmark;

public interface ITypeBookmarkCommandRepository : ICommandRepository<int, TypeBookmarks>
{
}