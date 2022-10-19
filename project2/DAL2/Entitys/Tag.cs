namespace DAL2.Entitys;

public class Tag : EntityBase
{
    public string Name { get; set; }
    
    public virtual ICollection<BookTag> BookTags { get; set; }
}