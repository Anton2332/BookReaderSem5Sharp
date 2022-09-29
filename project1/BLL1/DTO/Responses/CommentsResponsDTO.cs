namespace BLL1.DTO.Responses;

public class CommentsResponsDTO
{
    public int Id { get; set; }
    
    public string? UserId { get; set; }
    public string? Firstname {get; set;}
    public string? Lastname {get ;set;}
    
    public int BookId { get; set; }
    public string? Body { get; set; }
    public DateTime CreateAt { get; set; }
    public int? RepliesId { get; set; }
}