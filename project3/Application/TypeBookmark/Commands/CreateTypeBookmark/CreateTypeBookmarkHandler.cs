using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.TypeBookmark.Commands.CreateTypeBookmark;

public class CreateTypeBookmarkHandler : IRequestHandler<CreateTypeBookmarkCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTypeBookmarkHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateTypeBookmarkCommand request, CancellationToken cancellationToken)
    {
        TypeBookmarks entity = _mapper.Map<TypeBookmarks>(request.CreateTypeBookmarkDto);
        
        entity.CreatedAt = DateTime.Now;
        entity.UpdateAt = DateTime.Now;

        try
        {
            _unitOfWork.TypeBookmarkCommandRepository.Create(entity);
        }
        catch (Exception e)
        {
            throw e;
        }

        return true;
    }

}