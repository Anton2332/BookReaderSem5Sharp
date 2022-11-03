using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Bookmark.Commands.DeleteBookmark;

public class DeleteBookmarkHandler : IRequestHandler<DeleteBookmarkCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookmarkHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteBookmarkCommand request, CancellationToken cancellationToken)
    {
        Bookmarks entity = _unitOfWork.BookmarkReadRepository.Get(request.Id);

        if (entity == null) throw new ApplicationException("No Bookmarks is found to delete");

        var isSucceed = _unitOfWork.BookmarkCommandRepository.Delete(request.Id);

        if (!isSucceed) throw new ApplicationException("Bookmark is not deleted successfully");

        return true;
    }
}