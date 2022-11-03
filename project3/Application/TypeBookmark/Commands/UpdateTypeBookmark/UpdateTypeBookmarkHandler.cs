using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.TypeBookmark.Commands.UpdateTypeBookmark;

public class UpdateTypeBookmarkHandler : IRequestHandler<UpdateTypeBookmarkCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTypeBookmarkHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateTypeBookmarkCommand request, CancellationToken cancellationToken)
    {
        
         TypeBookmarks entity = _unitOfWork.TypeBookmarkRepository.Get(request.Id);

         if (entity == null) throw new Exception("No TypeBookmark is fount to update");

         var createdAt = entity.CreatedAt;

         entity = _mapper.Map<TypeBookmarks>(request.UpdateTypeBookmarkDto);

         entity.CreatedAt = createdAt;
         entity.UpdateAt = DateTime.Now;

         var isSucceed = _unitOfWork.TypeBookmarkCommandRepository.Update(request.Id, entity);

         if (!isSucceed) throw new ApplicationException("TypeBookmark is not updated successfully");
        
        return true;
    }
}