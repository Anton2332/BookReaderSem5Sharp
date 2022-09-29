namespace DAL2.Entitys;

public class Author : EntityBase
{
    public string Name { get; set; }
    
    public virtual ICollection<Book> Books { get; set; }
}