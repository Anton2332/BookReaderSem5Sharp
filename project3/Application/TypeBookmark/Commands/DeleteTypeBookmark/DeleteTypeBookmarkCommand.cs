using MediatR;

namespace Application.TypeBookmark.Commands.DeleteTypeBookmark;

public class DeleteTypeBookmarkCommand : IRequest<bool>
{
    public int Id { get; set; }
}