using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Notification.Commands.CreateNotification;

public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Notification entity = _mapper.Map<Domain.Entities.Notification>(request.CreateNotificationDto);
        
        entity.CreatedAt = DateTime.Now;
        entity.UpdateAt = DateTime.Now;

        try
        {
            _unitOfWork.NotificationCommandRepository.Create(entity);
        }
        catch (Exception e)
        {
            throw e;
        }

        return true;
    }
}