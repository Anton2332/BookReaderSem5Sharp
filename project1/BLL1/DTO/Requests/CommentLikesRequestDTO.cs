namespace BLL1.DTO.Requests;

public class CommentLikesRequestDTO
{
    public int Id { get; set; }
    public string UserId {get; set;}
    public int CommentId { get; set; }
}