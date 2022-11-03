using Application.Exceptions;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Application.Notification.Commands.UpdateNotification;

public class UpdateNotificationHandler : IRequestHandler<UpdateNotificationCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Notification entity = _unitOfWork.NotificationReadRepository.Get(request.Id);

        if (entity == null) throw new Exception("No Notification is found to update");

        var createdAt = entity.CreatedAt;

        entity = _mapper.Map<Domain.Entities.Notification>(request.UpdateNotificationDto);

        entity.CreatedAt = createdAt;
        entity.UpdateAt = DateTime.Now;

        var isSucceed = _unitOfWork.NotificationCommandRepository.Update(request.Id, entity);

        if (!isSucceed) throw new ApplicationException("Notification is not updated successfully");

        return true;
    }
}