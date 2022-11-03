using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Notification.Queries.GetNotification;

public class GetNotificationHandler : IRequestHandler<GetNotificationQuery, NotificationDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<NotificationDTO> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.Notification entity = _unitOfWork.NotificationReadRepository.Get(request.Id);

        return _mapper.Map<Domain.Entities.Notification, NotificationDTO>(entity);
    }
}