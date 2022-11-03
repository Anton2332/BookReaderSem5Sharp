using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.TypeBookmark.Commands.DeleteTypeBookmark;

public class DeleteTypeBookmarkHandler : IRequestHandler<DeleteTypeBookmarkCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTypeBookmarkHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteTypeBookmarkCommand request, CancellationToken cancellationToken)
    {
        TypeBookmarks entity = _unitOfWork.TypeBookmarkRepository.Get(request.Id);

        if (entity == null) throw new ApplicationException("TypeBookmark is not found");

        var isSucceed = _unitOfWork.TypeBookmarkCommandRepository.Delete(request.Id);

        if (!isSucceed) throw new Exceptions.ApplicationException("TypeBookmark is not deleted");

        return true;
    }
}