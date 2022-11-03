using Domain.QueryMapper;
using MediatR;

namespace Application.Notification.Queries.GetNotificationsByBookmarkId;

public class GetNotificationsByBookmarkIdQuery : IRequest<IEnumerable<NotificationDTO>>
{
    public bool IsRead { get; set; }
    
    public int BookmarkId { get; set; }
    
    public QueryOptions QueryOptions { get; set; }
}