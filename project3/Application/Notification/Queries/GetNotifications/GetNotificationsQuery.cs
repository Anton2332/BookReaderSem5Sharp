using Domain.QueryMapper;
using MediatR;

namespace Application.Notification.Queries.GetNotifications;

public class GetNotificationsQuery : IRequest<IEnumerable<NotificationDTO>>
{
    public bool isRead { get; set; }
    public QueryOptions QueryOptions { get; set; }
}