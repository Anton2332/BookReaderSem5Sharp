using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Notification.Queries.GetNotifications;

public class GetNotificationsHandler : IRequestHandler<GetNotificationsQuery, IEnumerable<NotificationDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetNotificationsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotificationDTO>> Handle(GetNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var entities = _unitOfWork.NotificationReadRepository.GetAll(request.isRead, request.QueryOptions);

        return _mapper.Map<IEnumerable<NotificationDTO>>(entities);
    }
}