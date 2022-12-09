namespace SharedProject.Models;

public class ChapterModel
{
    public int BookId { get; set; }
    
    public int ChapterId { get; set; }
    public string ChapterName { get; set; }
    public DateTime CreatedAt { get; set; }
}