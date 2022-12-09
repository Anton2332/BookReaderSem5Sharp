using Application.Bookmark.Queries.GetBookmarkByBookId;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Notification.Commands.CreateNotification;

public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private IMediator _mediator;
    
    public CreateNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<bool> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Notification entity = _mapper.Map<Domain.Entities.Notification>(request.CreateNotificationDto);

        entity.IsRead = false;
        entity.CreatedAt = DateTime.Now;
        entity.UpdateAt = DateTime.Now;

        var bookId = request.CreateNotificationDto.BookId;

        var resultBookmark = await _mediator.Send(new GetBookmarkByBookIdQuery()
        {
            BookId = bookId,
        });

        try
        {
            foreach (var itemBookmark in resultBookmark)
            {
                entity.BookmarkId = itemBookmark.Id;
                _unitOfWork.NotificationCommandRepository.Create(entity);
            }
        }
        catch (Exception e)
        {
            throw e;
        }

        return true;
    }
}