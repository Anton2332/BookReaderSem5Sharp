namespace BLL1.DTO.Requests;

public class CommentsRequestDTO
{
    public string UserId { get; set; }
    public int BookId { get; set; }
    public string Body { get; set; }   
    public int? RepliesId { get; set; }
}