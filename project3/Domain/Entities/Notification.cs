namespace Domain.Entities;

public class Notification : BaseEntity
{
    public int ChapterId { get; set; }
    
    public int BookmarkId { get; set; }
    
    public bool IsRead { get; set; }
}