namespace BLL1.DTO.Requests;

public class CommentLikesRequestDTO
{
    public int UserId {get; set;}
    public int BookId { get; set; }
    public int LikeId { get; set; }
}