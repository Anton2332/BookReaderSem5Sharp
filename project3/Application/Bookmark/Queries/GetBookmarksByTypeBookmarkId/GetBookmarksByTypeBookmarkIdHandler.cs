using Application.Bookmark.Queries.GetBookmarks;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Bookmark.Queries.GetBookmarksByTypeBookmarkId;

public class GetBookmarksByTypeBookmarkIdHandler : IRequestHandler<GetBookmarksByTypeBookmarkIdQuery, IEnumerable<BookmarkDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBookmarksByTypeBookmarkIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookmarkDTO>> Handle(GetBookmarksByTypeBookmarkIdQuery request, CancellationToken cancellationToken)
    {
        var entities =
            _unitOfWork.BookmarkReadRepository.GetByTypeBookmarkId(request.TypeBookmarkId, request.QueryOptions);

        return _mapper.Map<IEnumerable<BookmarkDTO>>(entities);
    }
}