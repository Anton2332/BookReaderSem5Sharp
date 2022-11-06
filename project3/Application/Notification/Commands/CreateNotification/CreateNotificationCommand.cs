using MediatR;

namespace Application.Notification.Commands.CreateNotification;

public class CreateNotificationCommand : IRequest<bool>
{
    public CreateNotificationDTO CreateNotificationDto { get; set; }
}