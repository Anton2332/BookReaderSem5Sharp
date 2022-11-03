using Domain.Interfaces;
using Domain.Interfaces.Bookmark;
using Domain.Interfaces.Notification;
using Domain.Interfaces.TypeBookmark;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(
        IBookmarkCommandRepository bookmarkCommandRepository,
        IBookmarkReadRepository bookmarkReadRepository,
        ITypeBookmarkCommandRepository typeBookmarkCommandRepository,
        ITypeBookmarkRepository typeBookmarkRepository,
        INotificationCommandRepository notificationCommandRepository,
        INotificationReadRepository notificationReadRepository) : base()
    {
        BookmarkCommandRepository = bookmarkCommandRepository;
        BookmarkReadRepository = bookmarkReadRepository;
        TypeBookmarkCommandRepository = typeBookmarkCommandRepository;
        TypeBookmarkRepository = typeBookmarkRepository;
        NotificationCommandRepository = notificationCommandRepository;
        NotificationReadRepository = notificationReadRepository;
    }
    
    public ITypeBookmarkCommandRepository TypeBookmarkCommandRepository { get; }
    public ITypeBookmarkRepository TypeBookmarkRepository { get; }
    public IBookmarkCommandRepository BookmarkCommandRepository { get; }
    public IBookmarkReadRepository BookmarkReadRepository { get; }
    public INotificationCommandRepository NotificationCommandRepository { get; }
    public INotificationReadRepository NotificationReadRepository { get; }
}