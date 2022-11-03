using AutoMapper;

namespace Application.TypeBookmark.Commands;

[AutoMap(typeof(Domain.Entities.Notification), ReverseMap = true)]
public class TypeBookmarkDTO
{
    public int Id {get;set;}
    
    public string UserId { get; set; }
    
    public string Name { get; set; }
}