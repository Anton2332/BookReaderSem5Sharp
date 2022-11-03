using MediatR;

namespace Application.Notification.Commands.UpdateNotification;

public class UpdateNotificationCommand : IRequest<bool>
{
    public NotificationDTO UpdateNotificationDto { get; set; }
    
    public int Id { get; set; }
}