namespace DAL2.Entitys;

public class UserBook
{
    public string Id { get; set; }
    
    public virtual ICollection<Rating> Ratings { get; set; }
    public virtual ICollection<Chapter> Chapters { get; set; }
}