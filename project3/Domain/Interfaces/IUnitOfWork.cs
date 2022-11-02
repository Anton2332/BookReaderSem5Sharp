using Domain.Interfaces.Bookmark;
using Domain.Interfaces.Notification;
using Domain.Interfaces.TypeBookmark;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    public ITypeBookmarkCommandRepository TypeBookmarkCommandRepository { get; }
    public ITypeBookmarkRepository TypeBookmarkRepository { get; }
    public IBookmarkCommandRepository BookmarkCommandRepository { get; }
    public IBookmarkReadRepository BookmarkReadRepository { get; }
    public INotificationCommandRepository NotificationCommandRepository { get; }
    public INotificationReadRepository NotificationReadRepository { get; }
}