namespace DAL2.Entitys;

public class Category : EntityBase
{
    public string Name { get; set; }
    
    public virtual ICollection<Book> Books { get; set; }
}