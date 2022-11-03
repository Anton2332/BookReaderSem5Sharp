using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.TypeBookmark.Queries.GetTypeBookmarks;

public class GetTypeBookmarksHandler : IRequestHandler<GetTypeBookmarksQuery, IEnumerable<TypeBookmarkDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTypeBookmarksHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypeBookmarkDTO>> Handle(GetTypeBookmarksQuery request,
        CancellationToken cancellationToken)
    {
        var entities = _unitOfWork.TypeBookmarkRepository.GetAll(request.QueryOptions);

        return _mapper.Map<IEnumerable<TypeBookmarkDTO>>(entities);
    }
}