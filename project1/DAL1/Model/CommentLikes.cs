namespace DAL1.Model;

public class CommentLikes : Base
{
    public int UserId {get; set;}
    public int CommentId { get; set; }
    public int LikeId { get; set; }
}