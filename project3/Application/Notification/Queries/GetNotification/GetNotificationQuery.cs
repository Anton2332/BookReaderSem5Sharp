using MediatR;

namespace Application.Notification.Queries.GetNotification;

public class GetNotificationQuery : IRequest<NotificationDTO>
{
    public int Id { get; set; }
}