using Domain.QueryMapper;

namespace Domain.Interfaces.Notification;

public interface INotificationReadRepository : IReadRepository<int, Entities.Notification>
{
    IEnumerable<Entities.Notification> GetByBookmarkId(int bookmarkId, bool isRead, QueryOptions options);

    IEnumerable<Entities.Notification> GetAll(bool isRead, QueryOptions options);
}