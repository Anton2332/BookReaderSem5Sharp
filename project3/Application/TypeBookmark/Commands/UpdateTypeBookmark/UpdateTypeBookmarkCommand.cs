using MediatR;

namespace Application.TypeBookmark.Commands.UpdateTypeBookmark;

public class UpdateTypeBookmarkCommand : IRequest<bool>
{
    public TypeBookmarkDTO UpdateTypeBookmarkDto { get; set; }
    
    public int Id { get; set; }
}