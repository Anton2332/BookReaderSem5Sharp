namespace GraphQL.Entitys;

public class Category : EntityBase
{
    public string Name { get; set; }
    
    public virtual ICollection<BookCategory> BooksCategories { get; set; }
}