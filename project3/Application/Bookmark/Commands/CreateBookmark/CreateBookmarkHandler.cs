using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Bookmark.Commands.CreateBookmark;

public class CreateBookmarkHandler : IRequestHandler<CreateBookmarkCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBookmarkHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
    {
        Bookmarks entity = _unitOfWork.BookmarkReadRepository.GetByBookId(request.CreateBookmarkDto.BookId, request.CreateBookmarkDto.TypeBookmarkId);

        if (entity != null) throw new ApplicationException($"Bookmarks with Bookid {request.CreateBookmarkDto.BookId} is found ");
        
        entity = _mapper.Map<Bookmarks>(request.CreateBookmarkDto);
        entity.CreatedAt = DateTime.Now;
        entity.UpdateAt = DateTime.Now;

        try
        {
            _unitOfWork.BookmarkCommandRepository.Create(entity);
        }
        catch (Exception e)
        {
            throw e;
        }

        return true;
    }

}