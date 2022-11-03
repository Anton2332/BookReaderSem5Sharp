using MediatR;

namespace Application.TypeBookmark.Commands.CreateTypeBookmark;

public class CreateTypeBookmarkCommand : IRequest<bool>
{
    public TypeBookmarkDTO CreateTypeBookmarkDto { get; set; }
}