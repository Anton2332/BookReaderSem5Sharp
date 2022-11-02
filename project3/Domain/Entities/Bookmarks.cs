namespace Domain.Entities;

public class Bookmarks : BaseEntity
{
    public int BookmarkId { get; set; }
    
    public int BookId { get; set; }
}