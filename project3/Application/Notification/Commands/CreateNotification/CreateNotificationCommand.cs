using MediatR;

namespace Application.Notification.Commands.CreateNotification;

public class CreateNotificationCommand : IRequest<bool>
{
    public NotificationDTO CreateNotificationDto { get; set; }
}