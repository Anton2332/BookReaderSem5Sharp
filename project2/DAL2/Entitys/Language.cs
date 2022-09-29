namespace DAL2.Entitys;

public class Language : EntityBase
{
    public string Name { get; set; }
    
    public ICollection<Book> Books { get; set; }
}