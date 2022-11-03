using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Bookmark.Commands.UpdateBookmark;

public class UpdateBookmarkHandler : IRequestHandler<UpdateBookmarkCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookmarkHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateBookmarkCommand request, CancellationToken cancellationToken)
    {
        Bookmarks entity = _unitOfWork.BookmarkReadRepository.Get(request.Id);

        if (entity == null) throw new Exception("No Bookmarks is found to update");
        
        entity.UpdateAt = DateTime.Now;

        var isSucceed = _unitOfWork.BookmarkCommandRepository.Update(request.Id, entity);

        if (!isSucceed) throw new ApplicationException("Bookmark is not updated successfully");

        return true;
    }
}