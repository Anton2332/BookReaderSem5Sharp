namespace DAL2.Entitys;

public class Rating : EntityBase
{
    public string UserId { get; set; }
    
    public float Ball { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }
}