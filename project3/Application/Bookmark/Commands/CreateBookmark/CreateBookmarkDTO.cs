using System.Text.Json.Serialization;
using AutoMapper;
using Domain.Entities;

namespace Application.Bookmark.Commands.CreateBookmark;

[AutoMap(typeof(Bookmarks), ReverseMap = true)]
public class CreateBookmarkDTO
{
    public int Id { get; set; }
    public int TypeBookmarkId { get; set; }
    public int BookId { get; set; }

    public CreateBookmarkDTO(CreateBookmarkDTO createBookmarkDto)
    {
        Id = createBookmarkDto.Id;
        TypeBookmarkId = createBookmarkDto.TypeBookmarkId;
        BookId = createBookmarkDto.BookId;
    }

    [JsonConstructor]
    public CreateBookmarkDTO()
    {
    }
}