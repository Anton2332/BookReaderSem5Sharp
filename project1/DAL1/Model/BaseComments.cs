namespace DAL1.Model;

public class BaseComments
{
    public string? UserId { get; set; }
    public int BookId { get; set; }
    public string? Body { get; set; }
    public int? RepliesId { get; set; }
}