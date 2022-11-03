namespace Domain.Entities;

public class Bookmarks : BaseEntity
{
    public int TypeBookmarkId { get; set; }
    
    public int BookId { get; set; }
}