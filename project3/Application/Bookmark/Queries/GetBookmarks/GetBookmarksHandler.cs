using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Bookmark.Queries.GetBookmarks;

public class GetBookmarksHandler : IRequestHandler<GetBookmarksQuery, IEnumerable<BookmarkDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBookmarksHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookmarkDTO>> Handle(GetBookmarksQuery request, CancellationToken cancellationToken)
    {
        var entities = _unitOfWork.BookmarkReadRepository.GetAll(request.QueryOptions);

        return _mapper.Map<IEnumerable<BookmarkDTO>>(entities);
    }
}