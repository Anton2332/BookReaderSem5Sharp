using AutoMapper;
using Domain.Entities;

namespace Application.Bookmark.Queries.GetBookmarksByTypeBookmarkId;

[AutoMap(typeof(Bookmarks), ReverseMap = true)]
public class BookmarkResponseDTO
{
    public int Id { get; set; }
    public int TypeBookmarkId { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public string BookDescription { get; set; }
}