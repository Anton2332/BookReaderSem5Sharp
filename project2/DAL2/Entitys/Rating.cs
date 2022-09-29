namespace DAL2.Entitys;

public class Rating : EntityBase
{
    public int UserId { get; set; }
    public UserBook User { get; set; }
    
    public float Ball { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }
}