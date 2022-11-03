using AutoMapper;
using Domain.Entities;

namespace Application.Bookmark.Queries;

[AutoMap(typeof(Bookmarks), ReverseMap = true)]
public class BookmarkDTO
{
    public int Id { get; set; }
    public int TypeBookmarkId { get; set; }
    public int BookId { get; set; }
}