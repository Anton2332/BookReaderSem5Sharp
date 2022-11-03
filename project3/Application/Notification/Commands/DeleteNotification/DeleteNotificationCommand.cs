using MediatR;

namespace Application.Notification.Commands.DeleteNotification;

public class DeleteNotificationCommand : IRequest<bool>
{
    public int Id { get; set; }
}