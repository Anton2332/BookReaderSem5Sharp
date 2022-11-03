using Application.Bookmark.Queries.GetBookmarks;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Bookmark.Queries.GetBookmarkByBookId;

public class GetBookmarkByBookIdHandler : IRequestHandler<GetBookmarkByBookIdQuery, BookmarkDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBookmarkByBookIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookmarkDTO> Handle(GetBookmarkByBookIdQuery request, CancellationToken cancellationToken)
    {
        var entity = _unitOfWork.BookmarkReadRepository.GetByBookId(request.BookId);

        return _mapper.Map<BookmarkDTO>(entity);
    }
}