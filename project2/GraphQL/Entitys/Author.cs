namespace GraphQL.Entitys;

public class Author : EntityBase
{
    public string Name { get; set; }
    
    public ICollection<BookAuthor> BookAuthor { get; set; }
}