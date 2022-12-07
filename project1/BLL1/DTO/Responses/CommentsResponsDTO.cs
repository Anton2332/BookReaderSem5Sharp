namespace BLL1.DTO.Responses;

public class CommentsResponsDTO
{
    public int Id { get; set; }
    
    public string? UserId { get; set; }
    
    public int BookId { get; set; }
    public string? Body { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int? RepliesId { get; set; }
}