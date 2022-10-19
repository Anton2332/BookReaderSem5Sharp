namespace DAL2.Entitys;

public class BookTag : EntityBase
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}