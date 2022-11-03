using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Notification.Queries.GetNotificationsByBookmarkId;

public class GetNotificationsByBookmarkIdHandler : IRequestHandler<GetNotificationsByBookmarkIdQuery, IEnumerable<NotificationDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetNotificationsByBookmarkIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotificationDTO>> Handle(GetNotificationsByBookmarkIdQuery request,
        CancellationToken cancellationToken)
    {
        var entities =
            _unitOfWork.NotificationReadRepository.GetByBookmarkId(request.BookmarkId, request.IsRead,
                request.QueryOptions);

        return _mapper.Map<IEnumerable<NotificationDTO>>(entities);
    }
}