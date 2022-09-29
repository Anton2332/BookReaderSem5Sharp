namespace BLL1.DTO.Requests;

public class CommentsRequestDTO
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int BookId { get; set; }
    public string Body { get; set; }   
    public DateTime CreateAt { get; set; }
    public int? RepliesId { get; set; }
}