using AutoMapper;

namespace Application.Notification.Commands;

[AutoMap(typeof(Domain.Entities.Notification), ReverseMap = true)]
public class NotificationDTO
{
    public int Id {get;set;}
    
    public int ChapterId { get; set; }
        
    public int BookmarkId { get; set; }
        
    public bool IsRead { get; set; }
}