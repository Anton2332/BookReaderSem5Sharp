namespace DAL1.Model;

public class Comments : Base
{
    public string? UserId { get; set; }
    public UserComments User { get; set; }
    public int BookId { get; set; }
    public string? Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public int RepliesId { get; set; }
}