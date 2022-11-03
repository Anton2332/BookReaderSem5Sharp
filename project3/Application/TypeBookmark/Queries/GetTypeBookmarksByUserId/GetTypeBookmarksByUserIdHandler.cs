
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.TypeBookmark.Queries.GetTypeBookmarksByUserId;

public class GetTypeBookmarksByUserIdHandler : IRequestHandler<GetBookmarksByUserIdQuery, IEnumerable<TypeBookmarkDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTypeBookmarksByUserIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypeBookmarkDTO>> Handle(GetBookmarksByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var entities = _unitOfWork.TypeBookmarkRepository.GetByUserId(request.Id, request.QueryOptions);

        return _mapper.Map<IEnumerable<TypeBookmarkDTO>>(entities);
    }
}