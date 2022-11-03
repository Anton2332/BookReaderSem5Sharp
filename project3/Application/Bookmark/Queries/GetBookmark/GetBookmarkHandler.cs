using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Bookmark.Queries.GetBookmark;

public class GetBookmarkHandler : IRequestHandler<GetBookmarkQuery, BookmarkDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBookmarkHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookmarkDTO> Handle(GetBookmarkQuery request, CancellationToken cancellationToken)
    {
        Bookmarks entity = _unitOfWork.BookmarkReadRepository.Get(request.Id);

        return _mapper.Map<Bookmarks, BookmarkDTO>(entity);
    }

}