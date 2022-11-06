namespace GraphQL.Entitys;

public class UserBook
{
    public string Id { get; set; }
    
    public ICollection<Rating> Ratings { get; set; }
    public ICollection<Chapter> Chapters { get; set; }
}