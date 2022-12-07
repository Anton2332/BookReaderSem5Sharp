using System.Data;

namespace DAL2.Entitys;

public class Chapter : EntityBase
{
    public string? UserId { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public int ChapterId { get; set; }
    public string ChapterName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PublishDateTime { get; set; }
    public DateTime PremiumPublishDateTime { get; set; }
    
    public ICollection<Page> Pages { get; set; }

}