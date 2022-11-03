using Domain.Interfaces;
using MediatR;

namespace Application.Notification.Commands.DeleteNotification;

public class DeleteNotificationHandler : IRequestHandler<DeleteNotificationCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Notification entity = _unitOfWork.NotificationReadRepository.Get(request.Id);

        if (entity == null) throw new ApplicationException("Notification is not found");

        var isSucceed = _unitOfWork.NotificationCommandRepository.Delete(request.Id);

        if (!isSucceed) throw new ApplicationException("Notification is not deleted successfully");

        return true;
    }
    
}