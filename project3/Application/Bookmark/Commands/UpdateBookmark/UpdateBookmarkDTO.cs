using AutoMapper;
using Domain.Entities;

namespace Application.Bookmark.Commands.UpdateBookmark;


[AutoMap(typeof(Bookmarks), ReverseMap = true)]
public class UpdateBookmarkDTO
{
    public int Id { get; set; }
    public int TypeBookmarkId { get; set; }
    public int BookId { get; set; }
}