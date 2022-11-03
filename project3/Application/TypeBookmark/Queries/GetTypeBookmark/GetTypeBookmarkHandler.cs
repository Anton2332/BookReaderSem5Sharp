using Application.Bookmark.Queries.GetBookmark;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.TypeBookmark.Queries.GetTypeBookmark;

public class GetTypeBookmarkHandler : IRequestHandler<GetTypeBookmarkQuery, TypeBookmarkDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTypeBookmarkHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TypeBookmarkDTO> Handle(GetTypeBookmarkQuery request, CancellationToken cancellationToken)
    {
        TypeBookmarks entity = _unitOfWork.TypeBookmarkRepository.Get(request.Id);

        return _mapper.Map<TypeBookmarks, TypeBookmarkDTO>(entity);
    }

}